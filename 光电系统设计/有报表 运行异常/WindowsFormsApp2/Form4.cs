using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp9;

namespace WindowsFormsApp2
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }


        private void button1_Click(object sender, EventArgs e)  //打开串口
        {
            if (serialPort1.IsOpen == false)
            {
                this.serialPort1.PortName = comboBox1.Text;
                serialPort1.Open();
                this.button2.Text = "关闭串口";
            }
            else
            {
                serialPort1.Close();
                this.button2.Text = "打开串口";
            }
        }

        private void button9_Click(object sender, EventArgs e)  //返回上一级
        {
            Form3 admin = new Form3();
            admin.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
        }
        private void Form4_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void serialPort1_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            byte vx;
            while (serialPort1.BytesToRead != 0)
            {
                int ivx = serialPort1.ReadByte();
                if (ivx == -1)
                    break;
                vx = (byte)ivx;
                this.Invoke((EventHandler)(delegate
                {
                    textBox1.Text += vx.ToString("x2") + " ";
                }));
            }
            //textBox1.Text += Environment.NewLine;
        }

        private void comboBox1_MouseClick(object sender, MouseEventArgs e)
        {
            string[] ports = System.IO.Ports.SerialPort.GetPortNames();
            comboBox1.DataSource = ports;
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            string connectString = @"Data Source=LAPTOP-3KELG2HB\SQL_SERVER;Initial Catalog=Data;Persist Security Info=True;User ID=sa;Password=123456";
            using (SqlConnection conn = new SqlConnection(connectString))
            {
                conn.Open();
                string 电压 = textBox2.Text;
                string 电流 = textBox1.Text;
                string sql = "insert data_V_C (VOL,CUR) values ('{0}','{1}')";
                sql = string.Format(sql, textBox2.Text, textBox1.Text);
                SqlCommand cmd = new SqlCommand(sql, conn);
                int returnvalue = cmd.ExecuteNonQuery();
            }
        }

        private void button3_Click_2(object sender, EventArgs e)
        {
            cp1616.Reset();
            string a = textBox1.Text;
            Double date = Double.Parse(a);
            double s;
            s = date * 4096 / 3.3;

            int temp = (int)Math.Floor(Convert.ToDouble(s));
            string res = temp.ToString("x");

            string str = " ";
            if ((res.Length % 2) != 0)
            {

                res = str + res;
            }
            byte[] bytes = new byte[res.Length / 2];
            for (int i = 0; i < bytes.Length; i++)
                bytes[i] = Convert.ToByte(res.Substring(i * 2, 2).Replace(" ", ""), 16);

            byte[] tx = cp1616.MakeCP1616Packet(0x02, bytes);
            serialPort1.Write(tx, 0, tx.Length);
        }
        private List<byte> back = new List<byte>(4096);

        private void button4_Click(object sender, EventArgs e)
        {
            byte[] tx = cp1616.MakeCP1616Packet((byte)3);
            serialPort1.Write(tx, 0, tx.Length);
            int n = serialPort1.BytesToRead;
            byte[] recv = new byte[n];
            serialPort1.Read(recv, 0, n);
            back.AddRange(recv);
            byte h = back[6];
            byte l = back[7];
            double ADC1;
            ADC1 = (h << 8) | l;
            double data;
            data = ((ADC1) * 1 * 3.3) / 4096;
            string V = data.ToString("0.00");
            textBox2.Text = V;
            back.Clear();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            double temp = double.Parse(textBox1.Text);
            if (temp >= 3.3)
            {
                MessageBox.Show("电压设置超出3.3V");
                timer1.Enabled = false;
            }
            string h = textBox2.Text;
            Double j = Double.Parse(h);
            string a = textBox1.Text;
            Double date = Double.Parse(a);
            chart1.Series[0].Points.AddXY(date, j);
            button2_Click_1(sender, e);
            DateTime dt1 = DateTime.Now;
            while ((DateTime.Now - dt1).TotalMilliseconds < 300)
            {
                continue;
            };
            double b = date + 0.05;
            string c = Convert.ToString(b);
            textBox1.Text = c;
            button3_Click_2(sender, e);

            while ((DateTime.Now - dt1).TotalMilliseconds < 3000)
            {
                continue;
            };

            button4_Click(sender, e);
        }

        private void btn_stop_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            cp1616 = new CP1616Packet();
        }
        CP1616Packet cp1616;

        private void Form4_FormClosed(object sender, FormClosedEventArgs e)
        {
            serialPort1.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
             var outputData = OptDB.SelectDT("select * from data");
             var bt = AsposeOfficeHelper.DataTableToExcelBytes(outputData);
             using (FileStream exc = new FileStream(@"D:\系统默认\桌面\新建文件夹\data.xls", FileMode.Create))
            {
                exc.Write(bt, 0, bt.Length);
            }

        }
    }
}
