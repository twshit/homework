using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            Form3 admin = new Form3();
            admin.Show();
            this.Hide();
        }

        private void Form5_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen == false)
            {
                this.serialPort1.PortName = comboBox1.Text;
                serialPort1.Open();
                this.button1.Text = "关闭串口";
            }
            else
            {
                serialPort1.Close();
                this.button1.Text = "打开串口";
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void comboBox1_MouseClick(object sender, MouseEventArgs e)
        {
            string[] ports = System.IO.Ports.SerialPort.GetPortNames();
            comboBox1.DataSource = ports;
        }

        private void Form5_FormClosed(object sender, FormClosedEventArgs e)
        {
            serialPort1.Close();
        }

        private bool SendStr(String str)
        {
            return SendStr(textBox1.Text, radioButton2.Checked);
        }
        private bool SendStr(String str, bool hexbool)
        {

            byte[] sendData = null;

            if (hexbool)
            {
                try
                {
                    sendData = strToHexByte(str.Trim());
                }
                catch (Exception)
                {
                    //throw;
                    MessageBox.Show("字符串转十六进制有误,请检测输入格式.", "错误!");
                    return false;
                }
            }
            else if (radioButton1.Checked)
            {
                sendData = Encoding.ASCII.GetBytes(str);
            }
            if (this.SendData(sendData))//发送数据成功计数
            {
                textBox2.Text += str;
                return true;
            }
            return false;
        }
        private byte[] strToHexByte(string hexString)
        {
            string temp = " ";
            hexString = hexString.Replace(" ", "");
            if ((hexString.Length % 2) != 0)
            {
                hexString = temp + hexString;
            }
            byte[] returnBytes = new byte[hexString.Length / 2];
            for (int i = 0; i < returnBytes.Length; i++)
                returnBytes[i] = Convert.ToByte(hexString.Substring(i * 2, 2).Replace(" ", ""), 16);
            return returnBytes;
        }
        public bool SendData(byte[] data)
        {
            if (serialPort1.IsOpen)
            {
                try
                {
                    serialPort1.Write(data, 0, data.Length);//发送数据
                    return true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                //MessageBox.Show("串口未打开", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                AddContent("串口未打开\r\n");
            }
            return false;
        }

        public void AddData(byte[] data)
        {
            if (radioButton3.Checked)
            {
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < data.Length; i++)
                {
                    sb.AppendFormat("{0:x}" + " ", data[i]);
                }
                AddContent(sb.ToString().ToUpper());
            }
            else if (radioButton4.Checked)
            {
                AddContent(new ASCIIEncoding().GetString(data));
            }
        }
        private void AddContent(string content)
        {
            this.BeginInvoke(new MethodInvoker(delegate
            {

                textBox3.AppendText("\r\n");
                textBox3.AppendText(content);
            }));
        }

        private void serialPort1_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            byte[] ReDatas = new byte[serialPort1.BytesToRead];
            serialPort1.Read(ReDatas, 0, ReDatas.Length);//读取数据
            this.AddData(ReDatas);//输出数据
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (SendStr(textBox1.Text))
            {
                textBox2.Text += "\r\n";
            }
        }
    }
}
    
