using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Pi.Client;
using PISDK;
using PIPoint = PISDK.PIPoint;

namespace PIHelperSample
{
    public partial class Form1 : Form
    {
        private PISDK.PISDK SDK;
        private Server server;
        private PIClient _server;
        private ISimulator simulator;
        private bool isConnect;
               
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonWrite_Click(object sender, EventArgs e)
        {          
            string tagName = textBoxTag.Text;
            object value = textBoxValue.Text;
            DateTime date = dateTimePicker1.Value;

            if (_server.IsConnected)
            {
                try
                {
                    _server.UpdateValue(tagName, value, date);
                    notify("Запись выполнена успешно!");
                }catch(NullReferenceException ex)
                {
                    notify(ex.Message);
                }               
            }         
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SDK = new PISDK.PISDK();
            string defaultServerName = SDK.Servers.DefaultServer.Name;

            if (!string.IsNullOrEmpty(defaultServerName))
            {
                textBoxServer.Text = defaultServerName;
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
                    notify("Не указано имя сервера");
                    return;
                }
                if (string.IsNullOrEmpty(inputUserName.Text))
                {
                    notify("Не указано имя пользователя");
                    return;
                }
                if (string.IsNullOrEmpty(inputPassword.Text))
                {
                    notify("Не указан пароль");
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
                notify(string.Format("Подключение успешно выполенено!"));
            }
            else
            {
               
                textBoxServer.ForeColor = Color.Red;
                textBoxServer.BackColor = textBoxServer.BackColor;
                notify(string.Format("Не удалось выполнить подключение!"));
            }
        }

        private void ConnectDefault(string serverName)
        {            
            try
            {
                server = SDK.Servers.DefaultServer;
                server.Open();
                _server = new PIClient();
                _server.Connect();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Не удалось выполнить подключение к серверу {serverName}\n\n {ex.Message}", "Ошибка подключения", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (server != null && server.Connected && _server.IsConnected)
            {            
                isConnect = true;
            }
            else
            {           
                isConnect = false;
            }                         
        }

        private void Connect(string serverName, string userName, string password)
        {
            try
            {
                server = SDK.Servers[serverName];
                server.Open($"UID={userName};PWD={password}"); //PISDK

                _server = new PIClient();
                _server.Connect(serverName, userName, password); //AFSDK
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Не удалось выполнить подключение к серверу {serverName}\n\n {ex.Message}", "Ошибка подключения", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (server != null && server.Connected && _server.IsConnected)
            {
                isConnect = true;
            }
            else
            {
                isConnect = false;
            }
        }


        private void notify(string message)
        {
            lbMessage.Text = message;
        }



        private void btnStart_Click(object sender, EventArgs e)
        {
            if (!isConnect)
            {
                notify("Отсутствует подключение с сервером!!!");
                return;
            }

            

            switch (comboBox1.SelectedIndex)
            {
                case 0:                    
                    simulator = new SimulatorRandom();                    
                    break;   
                case 1:
                    simulator = new SimulatorSinusoid();
                    break;
            }
                

            PIPoint tag = searchPoint(textBoxTag.Text);
            if (tag == null)
            {
                return;
            }

            SimulatorParam param = new SimulatorParam();
            try
            {
                if (comboBox1.SelectedIndex == 0)
                {
                    param.min = double.Parse(textBox4.Text);
                }               
                param.max = double.Parse(textBox5.Text);
                param.stepTime = int.Parse(textBox6.Text);

                if (param.stepTime >= 43200)
                {
                    throw new Exception("Step Time не может быть больше 12 часов!!!"); 
                };
                param.tag = tag;

            }
            catch(Exception ex)
            {
                MessageBox.Show(string.Format("{0}", ex.Message), "Ошибка ввода данных", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }    

            if (simulator != null)
            {                 
                simulator.Start(param);
                notify("Simulator запущен!");
                btnStart.Enabled = false;
                btnStop.Enabled = true;
            }
            else
            {
                notify("Не удалось определить тип Simulator!!!");
            }       

        }       

        private void btnStop_Click(object sender, EventArgs e)
        {
            simulator.Stop();
            notify("Simulator остановлен!");
            btnStart.Enabled = true;
            btnStop.Enabled = false;
        }

        private PIPoint searchPoint(string tagName)
        {
            PIPoint tag=null;
            try
            {
                 tag= server.GetPoints("tag = '" + tagName + "'")[1];
            }
            catch (Exception ex) {
                MessageBox.Show(string.Format("Не удалось найти тег {0}\n\n {1}", tagName, ex.Message), "Ошибка поиска", MessageBoxButtons.OK, MessageBoxIcon.Error);
               
            }
            return tag;
           
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
                notify("Отсутствует подключение с сервером!!!");
                return;
            }

            if (dateStart > dateEnd)
            {
                MessageBox.Show(string.Format("Начальная дата не может быть больше или равна конечной!!!"), "Ошибка ввода данных", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            tag = searchPoint(textBoxTag.Text);
            if (tag == null)
            {
                return;
            }

            if (!int.TryParse(textBox3.Text, out min))
            {
                MessageBox.Show(string.Format("Не удалось распознать формат данных поля Min!!!"), "Ошибка ввода данных", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!int.TryParse(textBox2.Text, out max))
            {
                MessageBox.Show(string.Format("Не удалось распознать формат данных поля Max!!!"), "Ошибка ввода данных", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (min >= max)
            {
                MessageBox.Show(string.Format("Min не должно быть больше или равно Max!!!"), "Ошибка ввода данных", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if(!int.TryParse(textBox1.Text, out stepTime))
            {
                MessageBox.Show(string.Format("Не удалось распознать формат данных поля StepTime!!!"), "Ошибка ввода данных", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            TimeSpan interval = ConvertSecond(stepTime);

            SortedList<DateTime, int> values = GenerateValuesByTime(min, max, interval, dateStart, dateEnd);

            btWriteValues.Enabled = false;
            WriteRangeAsync(tag,values);
            notify("Выполняется запись данных...");
            

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
                notify($"Запись {sucssesCount} из {values.Count} выполнена успешно! С ошибками {errorCount}");
                btWriteValues.Enabled = true;
            }
            else
            {
                btWriteValues.Enabled = true;
            }

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
                        MessageBox.Show(ex.Message, "Ошибка записи данных", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }

                }
                return true;
            });

            if (status)
            {
                notify("Запись выполнена успешно!");              
            }

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
                MessageBox.Show("Укажите тег в который необходимо выполнить запись значений", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string filePath = GetFilePath("csv files (*.csv)|*.csv");
            
            if(string.IsNullOrEmpty(filePath))
            {
                notify("Не указан файл импорта!");
                return;
            }

            IEnumerable<IValueData> values = await GetDataImportAsync(filePath);
            
            int count = _server.ImportCsv(textBoxTag.Text, values);

            MessageBox.Show($"Выполнена запись {count} значений");
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
            string tagName = textBoxTag.Text;
            if (string.IsNullOrEmpty(tagName))
            {
                MessageBox.Show("Укажите тег в который необходимо выполнить запись значений", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            notify($"Выполняется удаление значений из тега {tagName}");
            await Task.Run(() =>
            {
                PIPoint tag = searchPoint(tagName);
                if (tag == null)
                {

                }
                tag.Data.RemoveValues(dateTimePickerStart.Value, dateTimePickerEnd.Value, DataRemovalConstants.drRemoveAll);
              
            });
            notify($"Значения удалены из {tagName}");
        }

        private void isDefaultConnection_CheckedChanged(object sender, EventArgs e)
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
