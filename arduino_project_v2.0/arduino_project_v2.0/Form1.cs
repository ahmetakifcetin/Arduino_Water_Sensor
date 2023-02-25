using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.IO.Ports;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace arduino_project_v2._0
{
    public partial class Form1 : Form
    {
        private string data;

        public Form1()
        {
            InitializeComponent();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBox1.Text != "")
                {
                    serialPort1.PortName = comboBox1.Text;
                    if (comboBox2.Text != "")
                    {
                        serialPort1.BaudRate = Convert.ToInt16(comboBox2.Text);
                        serialPort1.Open();
                        button1.Enabled = false;
                        button2.Enabled = true;
                    }
                    else
                    {
                        MessageBox.Show("Lütfen İletişim Hızını Seçiniz!");
                    }
                }
                else
                {
                    MessageBox.Show("Lütfen Port Seçiniz!");
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Hata");
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            serialPort1.Close();
            button1.Enabled = true;
            button2.Enabled = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            button1.Enabled = true;
            button2.Enabled = false;
            string[] ports = SerialPort.GetPortNames();
            foreach (string port in ports)
            {
                comboBox1.Items.Add(port);
            }

            serialPort1.DataReceived += new SerialDataReceivedEventHandler(SerialPort1_DataReceived);
        }

        private void SerialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            data = serialPort1.ReadLine();
            this.Invoke(new EventHandler(displayData_Event));
        }

        private void displayData_Event(object sender, EventArgs e)
        {
            circularProgressBar1.Value = Convert.ToInt16(data);
            label3.Text = "Su Seviyesi %" + data;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private void circularProgressBar1_Click(object sender, EventArgs e)
        {

        }
    }
    }
