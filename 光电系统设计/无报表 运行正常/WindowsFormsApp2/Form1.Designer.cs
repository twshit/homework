
namespace WindowsFormsApp2
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_denglu = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_yonghuming = new System.Windows.Forms.TextBox();
            this.textBox_mima = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btn_quxiao = new System.Windows.Forms.Button();
            this.btn_chakan = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Highlight;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(621, 79);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Adobe 黑体 Std R", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(604, 78);
            this.label1.TabIndex = 0;
            this.label1.Text = "欢迎登录课程设计系统";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btn_denglu
            // 
            this.btn_denglu.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_denglu.Location = new System.Drawing.Point(94, 281);
            this.btn_denglu.Name = "btn_denglu";
            this.btn_denglu.Size = new System.Drawing.Size(100, 36);
            this.btn_denglu.TabIndex = 1;
            this.btn_denglu.Text = "确定";
            this.btn_denglu.UseVisualStyleBackColor = true;
            this.btn_denglu.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(116, 139);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 19);
            this.label2.TabIndex = 2;
            this.label2.Text = "用户名";
            // 
            // textBox_yonghuming
            // 
            this.textBox_yonghuming.Location = new System.Drawing.Point(223, 138);
            this.textBox_yonghuming.Name = "textBox_yonghuming";
            this.textBox_yonghuming.Size = new System.Drawing.Size(247, 25);
            this.textBox_yonghuming.TabIndex = 3;
            this.textBox_yonghuming.TextChanged += new System.EventHandler(this.textBox_yonghuming_TextChanged);
            // 
            // textBox_mima
            // 
            this.textBox_mima.Location = new System.Drawing.Point(223, 207);
            this.textBox_mima.Name = "textBox_mima";
            this.textBox_mima.PasswordChar = '*';
            this.textBox_mima.Size = new System.Drawing.Size(247, 25);
            this.textBox_mima.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(116, 213);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 19);
            this.label3.TabIndex = 4;
            this.label3.Text = "密码";
            // 
            // btn_quxiao
            // 
            this.btn_quxiao.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_quxiao.Location = new System.Drawing.Point(235, 281);
            this.btn_quxiao.Name = "btn_quxiao";
            this.btn_quxiao.Size = new System.Drawing.Size(93, 36);
            this.btn_quxiao.TabIndex = 6;
            this.btn_quxiao.Text = "退出";
            this.btn_quxiao.UseVisualStyleBackColor = true;
            this.btn_quxiao.Click += new System.EventHandler(this.button2_Click);
            // 
            // btn_chakan
            // 
            this.btn_chakan.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_chakan.Location = new System.Drawing.Point(373, 279);
            this.btn_chakan.Name = "btn_chakan";
            this.btn_chakan.Size = new System.Drawing.Size(170, 38);
            this.btn_chakan.TabIndex = 7;
            this.btn_chakan.Text = "用户数据";
            this.btn_chakan.UseVisualStyleBackColor = true;
            this.btn_chakan.Click += new System.EventHandler(this.btn_chakan_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(618, 388);
            this.Controls.Add(this.btn_chakan);
            this.Controls.Add(this.btn_quxiao);
            this.Controls.Add(this.textBox_mima);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox_yonghuming);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btn_denglu);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "登录";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_denglu;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_yonghuming;
        private System.Windows.Forms.TextBox textBox_mima;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btn_quxiao;
        private System.Windows.Forms.Button btn_chakan;
    }
}

