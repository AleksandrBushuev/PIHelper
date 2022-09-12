using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Pi.Client;
using PIHelperSample.Logger;
using PIHelperSample.Simulators;
using PISDK;
using PIPoint = PISDK.PIPoint;

namespace PIHelperSample
{
    public partial class Form1 : Form
    {
        private PISDK.PISDK SDK;
        private Server _serverPISDK;
        private PIClient _piClient;
        private ISimulator _simulator;
        private bool isConnect;
        private ILogger _logger;

        public Form1()
        {
            InitializeComponent();
            _logger = new FormLogger(textBoxLog);
        }

        private void buttonWrite_Click(object sender, EventArgs e)
        {          
            string tagName = textBoxTag.Text;
            object value = textBoxValue.Text;
            DateTime date = dateTimePicker1.Value;

            if (_piClient.IsConnected)
            {
                try
                {
                    _piClient.UpdateValue(tagName, value, date);
                    _logger.LogDebug("Запись выполнена успешно!");
                }catch(NullReferenceException ex)
                {
                    _logger.LogError(ex.Message);
                }               
            }         
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                SDK = new PISDK.PISDK();             
                textBoxServer.Text = SDK.Servers.DefaultServer.Name;
            }
            catch(COMException ex)
            {
                textBoxServer.Text = string.Empty;
                _logger.LogError("Отсутствует библиотека PISDK!", ex);
            }
            
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "dd.MM.yyyy HH:mm:ss";

            dateTimePickerStart.Format = DateTimePickerFormat.Custom;
            dateTimePickerStart.CustomFormat= "dd.MM.yyyy HH:mm:ss";
           
            dateTimePickerEnd.Format = DateTimePickerFormat.Custom;
            dateTimePickerEnd.CustomFormat= "dd.MM.yyyy HH:mm:ss";

            btnStop.Enabled = false;
            textBox4.Enabled = false;
        }

        private void btnTagSearch_Click(object sender, EventArgs e)
        {
            PISDKDlg.TagSearch tagSearch = new PISDKDlg.TagSearch();
            PointList tags = tagSearch.Show();

            if (tags.Count != 0)
            {
                PIPoint tag = tags[1];
                textBoxTag.Text = tag.Name;
            }
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            if (SDK == null)
            {
                _logger.LogError("Отсутствует библиотека калассов PISDK");
                return;
            }

           string serverName = string.Empty;
            if (isDefaultConnection.Checked)
            {
                serverName = SDK.Servers.DefaultServer.Name;
                ConnectDefault(serverName);
            }
            else
            {
                if (string.IsNullOrEmpty(textBoxServer.Text))
                {
                    _logger.LogError("Не указано имя сервера");
                    return;
                }
                if (string.IsNullOrEmpty(inputUserName.Text))
                {
                    _logger.LogError("Не указано имя пользователя");
                    return;
                }
                if (string.IsNullOrEmpty(inputPassword.Text))
                {
                    _logger.LogError("Не указан пароль");
                    return;
                }
                serverName = textBoxServer.Text;
                 Connect(serverName, inputUserName.Text, inputPassword.Text);
            }

            indicateConnection();
        }

        private void indicateConnection()
        {
            if (isConnect)
            {
                textBoxServer.ForeColor = Color.Green;
                textBoxServer.BackColor = textBoxServer.BackColor;
                _logger.LogDebug(string.Format("Подключение успешно выполенено!"));
            }
            else
            {
               
                textBoxServer.ForeColor = Color.Red;
                textBoxServer.BackColor = textBoxServer.BackColor;
                _logger.LogError(string.Format("Не удалось выполнить подключение!"));
            }
        }

        private void ConnectDefault(string serverName)
        {            
            try
            {
                _serverPISDK = SDK.Servers.DefaultServer;
                _serverPISDK.Open();
                _piClient = new PIClient();
                _piClient.Connect();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Не удалось выполнить подключение к серверу {serverName}\n\n {ex.Message}");
            }
            isConnect = _serverPISDK != null && _serverPISDK.Connected && _piClient.IsConnected;
                                  
        }

        private void Connect(string serverName, string userName, string password)
        {
            try
            {
                _serverPISDK = SDK.Servers[serverName];
                _serverPISDK.Open($"UID={userName};PWD={password}"); //PISDK

                _piClient = new PIClient();
                _piClient.Connect(serverName, userName, password); //AFSDK
                isConnect = _serverPISDK != null && _serverPISDK.Connected && _piClient.IsConnected;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Не удалось выполнить подключение к серверу {serverName}\n\n {ex.Message}", ex);
                isConnect = false;
            }                  
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (!isConnect)
            {
                _logger.LogError("Отсутствует подключение с сервером!!!");
                return;
            }

            _simulator = GetSimulator();

            PIPoint tag = searchPoint(textBoxTag.Text);
           
            if (tag == null)            
                return;
            
            double min = 0;
            double max = 0;
            int step = 0;

            if (comboBox1.SelectedIndex == 0 && !double.TryParse(textBox4.Text, out min))
            {
                _logger.LogError("Укажите минимальное значение в цифровом формате!");
                return;
            }

            if (!double.TryParse(textBox5.Text, out max))
            {
                _logger.LogError("Укажите максимальное значение в цифровом формате!");
                return;
            }

            if (!int.TryParse(textBox6.Text, out step))
            {
                _logger.LogError("Укажите интервал записи в цифровом формате!");
                return;
            }

            if (step >= 43200)
            {
                textBox6.Text = step.ToString();
                step = 43200;
            };


            var param = new SimulatorParam()
            {
                Max = max,
                Min = min,
                StepTime = step,
                Tag = tag
            };


            if (_simulator != null)
            {
                _simulator.Start(param);
                _logger.LogDebug("Simulator запущен!");
                btnStart.Enabled = false;
                btnStop.Enabled = true;
            }
            else
            {
                _logger.LogError("Не удалось определить тип Simulator!!!");
            }

        }

        private ISimulator GetSimulator()
        {           
            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    return new SimulatorRandom();                  
                case 1:
                   return new SimulatorSinusoid();
                default:
                    return new SimulatorRandom();
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            _simulator.Stop();
            _logger.LogDebug("Simulator остановлен!");
            btnStart.Enabled = true;
            btnStop.Enabled = false;
        }

        private PIPoint searchPoint(string tagName)
        {           
            try
            {
                PIPoint tag = _serverPISDK.GetPoints("tag = '" + tagName + "'")[1];
                return tag;
            }
            catch (Exception ex) {
               _logger.LogError($"Не удалось найти тег {tagName}\n", ex);
                return null;
            }
        }
       
        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                textBox4.Enabled = true;
            }else{
                textBox4.Enabled = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PIPoint tag = null;
            int min, max,stepTime;

            DateTime dateStart = dateTimePickerStart.Value;
            DateTime dateEnd = dateTimePickerEnd.Value;

            if (!isConnect)
            {
                _logger.LogError("Отсутствует подключение с сервером!!!");
                return;
            }

            if (dateStart > dateEnd)
            {
                _logger.LogError("Введите начальную дату больше конечной!!!");
                return;
            }

            tag = searchPoint(textBoxTag.Text);
            if (tag == null)
            {
                return;
            }

            if (!int.TryParse(textBox3.Text, out min))
            {
                _logger.LogError("Не удалось распознать формат данных поля Min!!!");
                return;
            }

            if (!int.TryParse(textBox2.Text, out max))
            {
                _logger.LogError("Не удалось распознать формат данных поля Max!!!");
                return;
            }

            if (min >= max)
            {
                _logger.LogError("Min не должно быть больше или равно Max!!!");
                return;
            }

            if(!int.TryParse(textBox1.Text, out stepTime))
            {
                _logger.LogError("Не удалось распознать формат данных поля StepTime!!!");
                return;
            }
            TimeSpan interval = ConvertSecond(stepTime);

            SortedList<DateTime, int> values = GenerateValuesByTime(min, max, interval, dateStart, dateEnd);

            btWriteValues.Enabled = false;
            WriteRangeAsync(tag,values);
            _logger.LogDebug("Выполняется запись данных...");
        }


        private async void WriteRangeAsync(PIPoint tag, SortedList<DateTime, int> values)
        {
            int sucssesCount = 0;
            int errorCount = 0;
            var status= await Task<bool>.Run(() =>
            {
                foreach (var iteam in values)
                {                    
                    try
                    {
                       tag.Data.UpdateValue(iteam.Value, iteam.Key);
                        sucssesCount += 1;
                    }
                    catch(Exception ex)
                    {
                        errorCount += 1;
                    }
                   
                }
                return true;
            });

            if (status)
            {
                _logger.LogDebug($"Запись {sucssesCount} из {values.Count} выполнена успешно! С ошибками {errorCount}");
            }
            btWriteValues.Enabled = true;
        }

        private async void WriteRangeAsync(PIPoint tag, List<CSVDataRow> values, Button btn)
        {
            btn.Enabled = false;
            var status = await Task<bool>.Run(() =>
            {
                foreach (var iteam in values)
                {
                    try
                    {
                        tag.Data.UpdateValue(iteam.Value, iteam.Timestamp);
                    }
                    catch (Exception ex)
                    {
                        _logger.LogError("Ошибка записи данных", ex);
                        return false;
                    }

                }
                return true;
            });

            if (status)
                _logger.LogDebug("Запись выполнена успешно!");              
            

            btn.Enabled = true;

        }
        private SortedList<DateTime, int> GenerateValuesByTime(int min, int max, TimeSpan interval, DateTime start, DateTime end)
        {
            SortedList<DateTime, int> values = new SortedList<DateTime, int>();
            Random random = new Random();        

            DateTime currentTime = start; 
              
            do
            {
                int currentValue = random.Next(min, max);
                values.Add(currentTime, currentValue);               
                currentTime += interval;

            } while (currentTime < end);

            values.Add(end, random.Next(min,max));


            return values;
        }

        private TimeSpan ConvertSecond(int seconds)
        {            
            int s = seconds % 60;
            int m = seconds / 60;
            int h = 0;
            int d = 0;

            if (m >= 60)
            {
                h = m / 60;
                m = m - h * 60;
            }
            if (h >= 24)
            {
                d = h % 24;
                h = h - d * 24;
            }

            return new TimeSpan(d, h, m, s);
        }

        private async void btnImport_ClickAsync(object sender, EventArgs e)
        {            
            string tagName = textBoxTag.Text;
            if (string.IsNullOrEmpty(tagName))
            {
                _logger.LogError("Укажите тег в который необходимо выполнить запись значений");
                return;
            }

            string filePath = GetFilePath("csv files (*.csv)|*.csv");
            
            if(string.IsNullOrEmpty(filePath))
            {
                _logger.LogError("Не указан файл импорта!");
                return;
            }

            IEnumerable<IValueData> values = await GetDataImportAsync(filePath);
            
            int count = _piClient.ImportCsv(textBoxTag.Text, values);

           _logger.LogDebug($"Выполнена запись {count} значений");
        }

        

        private async Task<IEnumerable<IValueData>> GetDataImportAsync(string filePath)
        {
            SystemStateHelper stateHelper = new SystemStateHelper();
            CSVHelper helper = new CSVHelper();
            var configuration = helper.GetCsvConfiguration(Encoding.UTF8, CultureInfo.CreateSpecificCulture("ru-RU"), ";");
            List<CSVDataRow> dataRows = await helper.GetDataFileAsync<CSVDataRow>(filePath, configuration);    
            
            IEnumerable<IValueData> values = dataRows.Select(row => new ValueData(stateHelper.GetValue(row.Value), row.Timestamp));
            return values;
        }
     

        private string GetFilePath(string filter)
        {
            string filePath = string.Empty;
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "csv files (*.csv)|*.csv";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    filePath = openFileDialog.FileName;
                }
            }
            return filePath;
        }

      

        private async void btnDeleteValues_Click(object sender, EventArgs e)
        {            
            var tagName = textBoxTag.Text;
            if (string.IsNullOrEmpty(tagName))            
                _logger.LogError("Укажите тег в который необходимо выполнить запись значений");
            
            _logger.LogDebug($"Выполняется удаление значений из тега {tagName}");
            await Task.Run(() =>
            {
                var tag = searchPoint(tagName);
                if (tag == null)
                      return;
                
                tag.Data.RemoveValues(dateTimePickerStart.Value, dateTimePickerEnd.Value, DataRemovalConstants.drRemoveAll);
            });
            _logger.LogDebug($"Значения удалены из {tagName}");
        }

        private void IsDefaultConnection_CheckedChanged(object sender, EventArgs e)
        {
            if (isDefaultConnection.Checked)
            {
                panelAuth.Hide();
                textBoxServer.ReadOnly = true;
            }
            else
            {
                panelAuth.Show();
                textBoxServer.ReadOnly = false;
            }
        }
    }
}
