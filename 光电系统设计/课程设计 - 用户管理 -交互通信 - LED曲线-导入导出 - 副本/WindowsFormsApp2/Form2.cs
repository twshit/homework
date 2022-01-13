using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form2 : Form
    {
        public string EditType = "";//编辑类别
        public Form2()
        {
            InitializeComponent();
            BindDT();
        }
        public void BindDT()
        {

            dataGridView1.DataSource = OptDB.SelectDT("select * from login");

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //添加用户
            StartEdit();
            EditType = "添加";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 admin = new Form1();
            admin.Show();
            this.Hide();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //删除用户
            StartEdit();
            EditType = "删除";
        }
        //开始编辑
        public void StartEdit()
        {
            //录入信息区控件禁用
            this.textBox_xuehao.Enabled = true;
            this.textBox_xingming.Enabled = true;
            this.textBox_mima.Enabled = true;
            this.button4.Enabled = true;
            this.button5.Enabled = true;
        }

        //结束编辑
        public void EndEdit()
        {
            //录入信息区控件禁用
            this.textBox_xuehao.Enabled = false;
            this.textBox_xingming.Enabled = false;
            this.textBox_mima.Enabled = false;
            this.button4.Enabled = true;
            this.button5.Enabled = true;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            EndEdit();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //获取录入信息
            string username = this.textBox_xingming.Text;
            string studentid = this.textBox_xuehao.Text;
            string password = this.textBox_mima.Text;
            //根据编辑类别进行操作
            switch (EditType)
            {
                case "添加":

                    if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(studentid) || string.IsNullOrEmpty(password))
                    {
                        MessageBox.Show("请检查数据是否为空");
                        return;
                    }
                    string sql = "select * from login where studentid=" + studentid;
                    if (OptDB.SelectDT(sql).Rows.Count <= 0)
                    {
                        var strsql = "insert into login(studentid,username,password)" +
                               "values('" + studentid + "','" + username + "','" + password + "')";
                        if (OptDB.AdapDB(strsql) > 0)
                        {
                            MessageBox.Show("添加成功");

                            BindDT();
                        }
                        else
                        {
                            MessageBox.Show("添加失败");
                        }
                    }
                    else
                    {
                        MessageBox.Show("请检查学号是否重复");
                    }
                    break;
                case "删除":
                    if (string.IsNullOrEmpty(studentid))
                    {
                        MessageBox.Show("删除请输入学号");
                        return;
                    }
                    var sqlStr = "delete from login where studentid=" + studentid;
                    OptDB.AdapDB(sqlStr);
                    MessageBox.Show("删除成功");
                    BindDT();
                    break;
                default:
                    break;
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            var filepath = @"D:\系统默认\桌面\新建文件夹\student_input.xls";

            if (File.Exists(filepath))
            {
                var table = AsposeOfficeHelper.ReadExcel(filepath);
                if (table != null)
                {
                    foreach (DataRow item in table.Rows)
                    {
                        try
                        {
         
                            var strsql = "insert into login(studentid,username,password) values('" + item[1].ToString() + "','" + item[2].ToString() + "','" + item[3].ToString() + "')";
                            OptDB.AdapDB(strsql);
                          
                        }
                        catch (Exception)
                        {
                        }

                    }
                    BindDT();
                }
            }


        }

        private void button6_Click(object sender, EventArgs e)
        {
            var outputData = OptDB.SelectDT("select * from login");
            var bt = AsposeOfficeHelper.DataTableToExcelBytes(outputData);
            using (FileStream exc = new FileStream(@"D:\系统默认\桌面\新建文件夹\student_output.xls", FileMode.Create))
            {
                exc.Write(bt, 0, bt.Length);
            }
        }

    }

}
