using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.IO;

namespace Fund
{
    public partial class Form6 : Form
    {
        Thread td;
        public Form6()
        {
            InitializeComponent();
            ThreadStart ts = new ThreadStart(GetIntroduction);
            td = new Thread(ts);
            td.SetApartmentState(ApartmentState.STA);
            td.Start();
        }

        void GetIntroduction()
        {
            string str = Read();//读取文件内容
            string[] all = str.Split(',');
            for (int i = 0; i < 100; i++)
            {
                DataGridViewRow row = new DataGridViewRow();

                this.Invoke((EventHandler)delegate
                {
                    dataGridView1.Rows.Add(row);
                    dataGridView1.Rows[i].Cells[0].Value = i + 1;//排行
                    dataGridView1.Rows[i].Cells[1].Value = all[i * 3];//股票代码
                    dataGridView1.Rows[i].Cells[2].Value = all[i * 3+1];//股票名称

                    double d = Convert.ToDouble(all[i * 3 + 2])/10000.0;//股票持仓金额
                    d = Math.Round(d, 2);
                    dataGridView1.Rows[i].Cells[3].Value = d;


                });
            }
            string[] all2 = new string[all.Length - 1];//去除最后一个空字符串
            Array.Copy(all, all2, all.Length - 1);
            Array.Reverse(all2);//倒置数组
            for (int i = 0; i < 100; i++)
            {
                this.Invoke((EventHandler)delegate
                {
                    DataGridViewRow row = new DataGridViewRow();
                    dataGridView2.Rows.Add(row);
                    dataGridView2.Rows[i].Cells[0].Value = i + 1;//排行
                    //相对原数组 现数组已被倒置，需要交换1、3cell读取位置
                    dataGridView2.Rows[i].Cells[1].Value = all2[i * 3 + 2];//股票代码
                    dataGridView2.Rows[i].Cells[2].Value = all2[i * 3 + 1];//股票名称
                    double d = Convert.ToDouble(all2[i * 3]) / 10000.0;//股票持仓金额
                    d = Math.Round(d, 2);
                    dataGridView2.Rows[i].Cells[3].Value = d;

                });
            }



        }

        string Read()
        {
            StreamReader sr = new StreamReader("..\\..\\stock\\result\\result_2017q3.txt", Encoding.Default);
            String data = sr.ReadToEnd();
            return data;
        }
    }
}

