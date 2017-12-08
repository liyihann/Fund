using System;

namespace Fund
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.abbreviation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IOPV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ＡＮＶ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Rootvole = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.oneweek = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.onemonth = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.threemonths = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sixmonths = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.oneyear = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.twoyears = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.threeyears = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.thisyear = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.create = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.handlingcharge = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.button10 = new System.Windows.Forms.Button();
            this.button11 = new System.Windows.Forms.Button();
            this.button12 = new System.Windows.Forms.Button();
            this.button13 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.code,
            this.abbreviation,
            this.date,
            this.IOPV,
            this.ＡＮＶ,
            this.Rootvole,
            this.oneweek,
            this.onemonth,
            this.threemonths,
            this.sixmonths,
            this.oneyear,
            this.twoyears,
            this.threeyears,
            this.thisyear,
            this.create,
            this.handlingcharge});
            this.dataGridView1.Location = new System.Drawing.Point(1, 1);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 27;
            this.dataGridView1.Size = new System.Drawing.Size(871, 429);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            // 
            // code
            // 
            this.code.HeaderText = "基金代码";
            this.code.Name = "code";
            this.code.ReadOnly = true;
            this.code.Width = 120;
            // 
            // abbreviation
            // 
            this.abbreviation.HeaderText = "基金简称";
            this.abbreviation.Name = "abbreviation";
            this.abbreviation.ReadOnly = true;
            this.abbreviation.Width = 120;
            // 
            // date
            // 
            this.date.HeaderText = "日期";
            this.date.Name = "date";
            this.date.ReadOnly = true;
            this.date.Width = 70;
            // 
            // IOPV
            // 
            this.IOPV.HeaderText = "单位净值";
            this.IOPV.Name = "IOPV";
            this.IOPV.ReadOnly = true;
            // 
            // ＡＮＶ
            // 
            this.ＡＮＶ.HeaderText = "累计净值";
            this.ＡＮＶ.Name = "ＡＮＶ";
            this.ＡＮＶ.ReadOnly = true;
            // 
            // Rootvole
            // 
            this.Rootvole.HeaderText = "日增长率";
            this.Rootvole.Name = "Rootvole";
            this.Rootvole.ReadOnly = true;
            // 
            // oneweek
            // 
            this.oneweek.HeaderText = "近1周";
            this.oneweek.Name = "oneweek";
            this.oneweek.ReadOnly = true;
            // 
            // onemonth
            // 
            this.onemonth.HeaderText = "近1月";
            this.onemonth.Name = "onemonth";
            this.onemonth.ReadOnly = true;
            // 
            // threemonths
            // 
            this.threemonths.HeaderText = "近3月";
            this.threemonths.Name = "threemonths";
            this.threemonths.ReadOnly = true;
            // 
            // sixmonths
            // 
            this.sixmonths.HeaderText = "近6月";
            this.sixmonths.Name = "sixmonths";
            this.sixmonths.ReadOnly = true;
            // 
            // oneyear
            // 
            this.oneyear.HeaderText = "近1年";
            this.oneyear.Name = "oneyear";
            this.oneyear.ReadOnly = true;
            // 
            // twoyears
            // 
            this.twoyears.HeaderText = "近2年";
            this.twoyears.Name = "twoyears";
            this.twoyears.ReadOnly = true;
            // 
            // threeyears
            // 
            this.threeyears.HeaderText = "近3年";
            this.threeyears.Name = "threeyears";
            this.threeyears.ReadOnly = true;
            // 
            // thisyear
            // 
            this.thisyear.HeaderText = "今年来";
            this.thisyear.Name = "thisyear";
            this.thisyear.ReadOnly = true;
            // 
            // create
            // 
            this.create.HeaderText = "成立来";
            this.create.Name = "create";
            this.create.ReadOnly = true;
            // 
            // handlingcharge
            // 
            this.handlingcharge.HeaderText = "手续费";
            this.handlingcharge.Name = "handlingcharge";
            this.handlingcharge.ReadOnly = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(137, 443);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(88, 32);
            this.button2.TabIndex = 2;
            this.button2.Text = "下一页";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(38, 443);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(88, 32);
            this.button1.TabIndex = 3;
            this.button1.Text = "上一页";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(276, 449);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(60, 25);
            this.textBox1.TabIndex = 4;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(351, 445);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(60, 32);
            this.button3.TabIndex = 6;
            this.button3.Text = "转到";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(231, 452);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 15);
            this.label1.TabIndex = 7;
            this.label1.Text = "1/74";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(446, 454);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 15);
            this.label2.TabIndex = 9;
            this.label2.Text = "基金编号";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(526, 449);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(114, 25);
            this.textBox2.TabIndex = 10;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(654, 445);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(80, 32);
            this.button5.TabIndex = 11;
            this.button5.Text = "搜索";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(38, 491);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(187, 30);
            this.button4.TabIndex = 12;
            this.button4.Text = "更新股票数据(实时)";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(38, 541);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(188, 31);
            this.button6.TabIndex = 13;
            this.button6.Text = "查看股票排行(实时)";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(462, 491);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(188, 30);
            this.button7.TabIndex = 14;
            this.button7.Text = "更新股票数据(2017Q2)";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(462, 541);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(188, 31);
            this.button8.TabIndex = 15;
            this.button8.Text = "查看股票排行(2017Q2）";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(251, 491);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(188, 30);
            this.button9.TabIndex = 16;
            this.button9.Text = "更新股票数据(2017Q3)";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // button10
            // 
            this.button10.Location = new System.Drawing.Point(251, 541);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(188, 31);
            this.button10.TabIndex = 17;
            this.button10.Text = "查看股票排行(2017Q3）";
            this.button10.UseVisualStyleBackColor = true;
            this.button10.Click += new System.EventHandler(this.button10_Click);
            // 
            // button11
            // 
            this.button11.Location = new System.Drawing.Point(674, 491);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(160, 30);
            this.button11.TabIndex = 18;
            this.button11.Text = "更新增/减持股数据";
            this.button11.UseVisualStyleBackColor = true;
            this.button11.Click += new System.EventHandler(this.button11_Click);
            // 
            // button12
            // 
            this.button12.Location = new System.Drawing.Point(674, 541);
            this.button12.Name = "button12";
            this.button12.Size = new System.Drawing.Size(160, 31);
            this.button12.TabIndex = 19;
            this.button12.Text = "查看增/减持股排行";
            this.button12.UseVisualStyleBackColor = true;
            this.button12.Click += new System.EventHandler(this.button12_Click);
            // 
            // button13
            // 
            this.button13.Location = new System.Drawing.Point(750, 444);
            this.button13.Name = "button13";
            this.button13.Size = new System.Drawing.Size(84, 32);
            this.button13.TabIndex = 20;
            this.button13.Text = "清空缓存";
            this.button13.UseVisualStyleBackColor = true;
            this.button13.Click += new System.EventHandler(this.button13_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(873, 589);
            this.Controls.Add(this.button13);
            this.Controls.Add(this.button12);
            this.Controls.Add(this.button11);
            this.Controls.Add(this.button10);
            this.Controls.Add(this.button9);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Form1";
            this.Text = "基金";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }


        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn code;
        private System.Windows.Forms.DataGridViewTextBoxColumn abbreviation;
        private System.Windows.Forms.DataGridViewTextBoxColumn date;
        private System.Windows.Forms.DataGridViewTextBoxColumn IOPV;
        private System.Windows.Forms.DataGridViewTextBoxColumn ＡＮＶ;
        private System.Windows.Forms.DataGridViewTextBoxColumn Rootvole;
        private System.Windows.Forms.DataGridViewTextBoxColumn oneweek;
        private System.Windows.Forms.DataGridViewTextBoxColumn onemonth;
        private System.Windows.Forms.DataGridViewTextBoxColumn threemonths;
        private System.Windows.Forms.DataGridViewTextBoxColumn sixmonths;
        private System.Windows.Forms.DataGridViewTextBoxColumn oneyear;
        private System.Windows.Forms.DataGridViewTextBoxColumn twoyears;
        private System.Windows.Forms.DataGridViewTextBoxColumn threeyears;
        private System.Windows.Forms.DataGridViewTextBoxColumn thisyear;
        private System.Windows.Forms.DataGridViewTextBoxColumn create;
        private System.Windows.Forms.DataGridViewTextBoxColumn handlingcharge;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.Button button11;
        private System.Windows.Forms.Button button12;
        private System.Windows.Forms.Button button13;
    }
}

