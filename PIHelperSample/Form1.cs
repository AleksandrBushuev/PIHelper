using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using PISDK;

namespace PIHelperSample
{
    public partial class Form1 : Form
    {
        private PISDK.PISDK SDK;
        private Server server;
        private ISimulator simulator;
        private bool isConnect;
               
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonWrite_Click(object sender, EventArgs e)
        {
            if (!isConnect)
            {
                return;
            }  

            string tagName = textBoxTag.Text;
            double value = Double.Parse(textBoxValue.Text);
            DateTime date = dateTimePicker1.Value;

            PIPoint tag = searchPoint(tagName);
            if (tag == null)
            {
                return;
            }

            try
            {              
                tag.Data.UpdateValue(value, date);
                notify(string.Format("Запись значения в {0} успешно выполнена!",tagName));
            }catch (Exception ex)
            {
                MessageBox.Show(string.Format("Не удалось записать значение в архив тега {0}\n\n {1}", tagName, ex.Message), "Ошибка данных", MessageBoxButtons.OK, MessageBoxIcon.Error);
               
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
            string serverName = textBoxServer.Text;
            try
            {
                server = SDK.Servers[serverName];
                server.Open();
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Не удалось выполнить подключение к серверу {0}\n\n {1}", serverName, ex.Message), "Ошибка подключения", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if(server!=null && server.Connected)
            {
                textBoxServer.ForeColor = Color.Green;
                isConnect = true;
                notify(string.Format("Подключение к {0} успешно выполенено!", serverName));
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
    }
}
