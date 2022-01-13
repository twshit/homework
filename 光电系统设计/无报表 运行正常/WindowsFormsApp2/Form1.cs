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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {

            //登录验证
            string studentid = this.textBox_yonghuming.Text.Trim();
            string password = this.textBox_mima.Text.Trim();
            string strsql = $"select * from [login] where studentid='{studentid}'and [password]='{password}'";
            var resDT = OptDB.SelectDT(strsql);
            if (resDT.Rows.Count > 0)
            {
                Form3 admin = new Form3();
                MessageBox.Show("登录成功");
                admin.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("账号或密码错误");
            }


            //if (IsEmpty())
            //{
            //    //窗体跳转
            //    MessageBox.Show("登录成功");
            //    Form3 admin = new Form3();
            //    admin.Show();
            //    this.Hide();
            //}

        }
        //非空验证
        public bool IsEmpty()
        {
            if (textBox_yonghuming.Text.Trim() == String.Empty)
            {
                MessageBox.Show("用户名不能为空");
                return false;
            }
            if (textBox_mima.Text.Trim() == String.Empty)
            {
                MessageBox.Show("密码不能为空");
                return false;
            }
            return true;
        }


        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_chakan_Click(object sender, EventArgs e)
        {
            Form2 admin = new Form2();
            admin.Show();
            this.Hide();
        }

        private void textBox_yonghuming_TextChanged(object sender, EventArgs e)
        {

        }

        private class SqlDataAdapter
        {
            private string strsql;

            public SqlDataAdapter(string strsql)
            {
                this.strsql = strsql;
            }
        }
    }
}

