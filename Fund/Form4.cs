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
    public partial class Form4 : Form
    {
        Thread td;
        public Form4()
        {
            InitializeComponent();
            ThreadStart ts = new ThreadStart(GetIntroduction);
            td = new Thread(ts);
            td.SetApartmentState(ApartmentState.STA);
            td.Start();
        }

        void GetIntroduction()
        {
            //try
            //{
            string str = Read();//读取文件内容
            string[] all = str.Split(',');//
            //int i = 0;
            for (int i = 0; i < 100; i++)
            {
                this.Invoke((EventHandler)delegate
                {
                    DataGridViewRow row = new DataGridViewRow();
                    dataGridView1.Rows.Add(row);
                    dataGridView1.Rows[i].Cells[0].Value = i + 1;//排行

                    dataGridView1.Rows[i].Cells[1].Value = all[i * 3];//股票代码
                    dataGridView1.Rows[i].Cells[2].Value = all[i * 3+1];//股票名称
                    double d = Convert.ToDouble(all[i * 3 + 2]);//股票持仓金额
                    d = Math.Round(d, 2);
                    dataGridView1.Rows[i].Cells[3].Value = d;
                });
            }

            string[] all2 = new string[all.Length - 1];//去除最后一个空字符串
            Array.Copy(all, all2, all.Length - 1);
            Array.Reverse(all2);//倒置数组
            for(int i = 0; i <100;i++)
            {
                this.Invoke((EventHandler)delegate
                {
                    DataGridViewRow row = new DataGridViewRow();
                    dataGridView2.Rows.Add(row);
                    dataGridView2.Rows[i].Cells[0].Value = i + 1;//排行
                    //相对原数组 现数组已被倒置，需要交换1、3cell读取位置
                    dataGridView2.Rows[i].Cells[1].Value = all2[i * 3+2];//股票代码
                    dataGridView2.Rows[i].Cells[2].Value = all2[i * 3 + 1];//股票名称
                    if (all2[i * 3].Contains("E"))//股票持仓金额
                    {
                        string s = all2[i * 3];

                        string b = s;
                        string e = s;
                        b = b.Substring(0, b.IndexOf("E"));
                        e = e.Substring(e.IndexOf("E") + 1);
                        double d = Math.Round(Convert.ToDouble(b), 2);//对系数保留两位小数 指数不变
                        dataGridView2.Rows[i].Cells[3].Value = d.ToString() + "E" + e;//科学记数法表示
                    }
                    else
                    {
                        dataGridView2.Rows[i].Cells[3].Value = all2[i * 3];//若原数据非采用科学记数法，则正常显示
                    }


            });
            }
            //}
           // }
            //catch (FileNotFoundException fe)
            //{
              //  MessageBox.Show("请先点击\"更新数据\"按钮", "提示");
           // }
        }

        string Read()
        {

                StreamReader sr = new StreamReader("..\\..\\stock\\result\\result_latest.txt", Encoding.Default);
                String data = sr.ReadToEnd();
                return data;



}
    }
}
