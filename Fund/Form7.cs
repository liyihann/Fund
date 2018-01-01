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
    public partial class Form7 : Form
    {
        Thread td;
        public Form7()
        {
            InitializeComponent();
            ThreadStart ts = new ThreadStart(GetIntroduction);
            td = new Thread(ts);
            td.SetApartmentState(ApartmentState.STA);
            td.Start();
          
        }

        void GetIntroduction()
        {//读取文件内容
            string strSum1 = Read("result_increase_sum");
            string strSum2 = Read("result_decrease_sum");
            string strNum1 = Read("result_increase_num");
            string strNum2 = Read("result_decrease_num");
            string[] allSum1 = strSum1.Split(',');
            string[] allSum2 = strSum2.Split(',');
            string[] allNum1 = strNum1.Split(',');
            string[] allNum2 = strNum2.Split(',');
            for(int i = 0; i < 50; i++)
            {
                DataGridViewRow row1 = new DataGridViewRow();
                DataGridViewRow row2 = new DataGridViewRow();
                DataGridViewRow row3 = new DataGridViewRow();
                DataGridViewRow row4 = new DataGridViewRow();
                this.Invoke((EventHandler)delegate
                {
                    dataGridView1.Rows.Add(row1);
                    dataGridView1.Rows[i].Cells[0].Value = i + 1;//排行
                    dataGridView1.Rows[i].Cells[1].Value = allSum1[i * 3];//股票代码
                    dataGridView1.Rows[i].Cells[2].Value = allSum1[i * 3+1];//股票名称

                    double d1 = Convert.ToDouble(allSum1[i * 3 + 2]);//股票持仓金额差值
                    d1 = Math.Round(d1, 2);
                    dataGridView1.Rows[i].Cells[3].Value = d1;
                });
                this.Invoke((EventHandler)delegate
                {
                    dataGridView2.Rows.Add(row2);//排行
                    dataGridView2.Rows[i].Cells[0].Value = i + 1;//股票代码
                    dataGridView2.Rows[i].Cells[1].Value = allSum2[i * 3];//股票名称
                    dataGridView2.Rows[i].Cells[2].Value = allSum2[i * 3+1];//股票持仓金额差值

                    double d1 = Convert.ToDouble(allSum2[i * 3 + 2]);
                    d1 = Math.Round(d1, 2);
                    dataGridView2.Rows[i].Cells[3].Value = d1;
                });
                this.Invoke((EventHandler)delegate
                {
                    dataGridView3.Rows.Add(row3);//排行
                    dataGridView3.Rows[i].Cells[0].Value = i + 1;//股票代码
                    dataGridView3.Rows[i].Cells[1].Value = allNum1[i * 3];//股票名称
                    dataGridView3.Rows[i].Cells[2].Value = allNum1[i * 3+1];//股票持仓数目差值

                    double d1 = Convert.ToDouble(allNum1[i * 3 + 2]);
                    d1 = Math.Round(d1, 2);
                    dataGridView3.Rows[i].Cells[3].Value = d1;
                });
                this.Invoke((EventHandler)delegate
                {
                    dataGridView4.Rows.Add(row4);//排行
                    dataGridView4.Rows[i].Cells[0].Value = i + 1;//股票代码
                    dataGridView4.Rows[i].Cells[1].Value = allNum2[i * 3];//股票名称
                    dataGridView4.Rows[i].Cells[2].Value = allNum2[i * 3+1];//股票持仓数目差值

                    double d2 = Convert.ToDouble(allNum2[i * 3 + 2]);
                    d2 = Math.Round(d2, 2);
                    dataGridView4.Rows[i].Cells[3].Value = d2;
                });
            }
            }

        string Read(string fileName)
        {
            StreamReader sr=new StreamReader("..\\..\\stock\\result\\"+fileName+".txt",Encoding.Default);
            String data = sr.ReadToEnd();
            return data;
        }

    }
}
