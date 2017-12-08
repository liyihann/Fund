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
        {
            string str1 = Read("result_increase");
            string str2 = Read("result_decrease");
            string[] all1 = str1.Split(',');
            string[] all2 = str2.Split(',');
            for(int i = 0; i < 50; i++)
            {
                DataGridViewRow row1 = new DataGridViewRow();
                DataGridViewRow row2 = new DataGridViewRow();
                this.Invoke((EventHandler)delegate
                {
                    dataGridView1.Rows.Add(row1);
                    dataGridView1.Rows[i].Cells[0].Value = i + 1;
                    dataGridView1.Rows[i].Cells[1].Value = all1[i * 2];

                    dataGridView2.Rows.Add(row2);
                    dataGridView2.Rows[i].Cells[0].Value = i + 1;
                    dataGridView2.Rows[i].Cells[1].Value = all2[i * 2];

                    double d1 = Convert.ToDouble(all1[i * 2 + 1]);
                    d1 = Math.Round(d1, 2);
                    dataGridView1.Rows[i].Cells[2].Value = d1;

                    double d2 = Convert.ToDouble(all2[i * 2 + 1]);
                    d2 = Math.Round(d2, 2);
                    dataGridView2.Rows[i].Cells[2].Value = d2;

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
