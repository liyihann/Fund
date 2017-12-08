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
using System.Net;
using System.IO;
using System.Text.RegularExpressions;
using System.Collections;

namespace Fund
{
    public partial class Form1 : Form
    {
        Thread td;
        //初始化页数
        int page = 1;
        //初始化开始界面，并把页数转到第一页

        List<string> fundsID = new List<string>();
        List<Stock> stocks = new List<Stock>();

        public Form1()
        {
            InitializeComponent();
            ThreadStart ts = new ThreadStart(GetIntroduction);
            td = new Thread(ts);
            td.SetApartmentState(ApartmentState.STA);
            td.Start();
        }

        void GetIntroduction()
        {
            turnTo(1);
            createFolder("..\\..\\stock\\");
            createFolder("..\\..\\stock\\result\\");
            createFolder("..\\..\\stock\\latest\\");
            createFolder("..\\..\\stock\\2017q2\\");
            createFolder("..\\..\\stock\\2017q3\\");
        }

        //获取网页的内容，代码来自老师给的股票
        string GetContent(string url)
        {
            string html = "";
            // 发送查询请求
            WebRequest request = WebRequest.Create(url);
            WebResponse response = null;
            try
            {
                response = request.GetResponse();
                // 获得流
                StreamReader sr = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
                html = sr.ReadToEnd();
                response.Close();
            }
            catch (Exception ex)
            {
                // 本机没有联网
                if (ex.GetType().ToString().Equals("System.Net.WebException"))
                {
                    MessageBox.Show("请检查你的计算机是否已连接上互联网。\n" + url, "提示");
                }
            }
            return html;
        }
        //转到特定页
        string turnTo(int pi)
        {
            //清空之前内容
            this.dataGridView1.Rows.Clear();
            string url = "http://fund.eastmoney.com/data/rankhandler.aspx?op=ph&dt=kf&ft=all&rs=&gs=0&sc=zzf&st=desc&sd=2015-10-29&ed=2016-10-29&qdii=&tabSubtype=,,,,,&pi="
                + pi + "&pn=50&dx=1&v=0.10850418109563731";

            string data = GetContent(url);
            //正则表达式，提取每两个引号之间内容
            Regex re = new Regex("(?<=\").*?(?=\")", RegexOptions.None);

            //用正则表达式提取内容
            MatchCollection mc = re.Matches(data);

            int index = 0;

            //跳过单数项
            int pass = 0;

            foreach(Match funds in mc){
                if (pass % 2 == 1)
                {
                    pass++;
                    continue;
                }

                string fund = funds.Value;
                //把逗号之间的内容提取出来放进string数组里
                string[] all = Regex.Split(fund, ",", RegexOptions.IgnoreCase);
                //新建一行
                DataGridViewRow row = new DataGridViewRow();


                //之后的代码都是把string数组的内容放进每一行里
                this.Invoke((EventHandler)delegate
                {
                    dataGridView1.Rows.Add(row);
                    dataGridView1.Rows[index].Cells[0].Value = all[0];
                });
                this.Invoke((EventHandler)delegate
                {
                    dataGridView1.Rows[index].Cells[1].Value = all[1].Substring(0, (all[1].Length > 6 ? 6 : all[1].Length));
                });
                this.Invoke((EventHandler)delegate
                {
                    dataGridView1.Rows[index].Cells[2].Value = all[3].Length == 0 ? "---" : all[3].Substring(5);
                });
                this.Invoke((EventHandler)delegate
                {
                    dataGridView1.Rows[index].Cells[3].Value = all[4].Length == 0 ? "---" : all[4];
                });
                this.Invoke((EventHandler)delegate
                {
                    dataGridView1.Rows[index].Cells[4].Value = all[5].Length == 0 ? "---" : all[5];
                });
                this.Invoke((EventHandler)delegate
                {
                    dataGridView1.Rows[index].Cells[5].Value = getPercent(all[6]);
                });
                this.Invoke((EventHandler)delegate
                {
                    dataGridView1.Rows[index].Cells[6].Value = getPercent(all[7]);
                });
                this.Invoke((EventHandler)delegate
                {
                    dataGridView1.Rows[index].Cells[7].Value = getPercent(all[8]);
                });
                this.Invoke((EventHandler)delegate
                {
                    dataGridView1.Rows[index].Cells[8].Value = getPercent(all[9]);
                });
                this.Invoke((EventHandler)delegate
                {
                    dataGridView1.Rows[index].Cells[9].Value = getPercent(all[10]);
                });
                this.Invoke((EventHandler)delegate
                {
                    dataGridView1.Rows[index].Cells[10].Value = getPercent(all[11]);
                });
                this.Invoke((EventHandler)delegate
                {
                    dataGridView1.Rows[index].Cells[11].Value = getPercent(all[12]);
                });
                this.Invoke((EventHandler)delegate
                {
                    dataGridView1.Rows[index].Cells[12].Value = getPercent(all[13]);
                });
                this.Invoke((EventHandler)delegate
                {
                    dataGridView1.Rows[index].Cells[13].Value = getPercent(all[14]);
                });
                this.Invoke((EventHandler)delegate
                {
                    dataGridView1.Rows[index].Cells[14].Value = getPercent(all[15]);
                });
                this.Invoke((EventHandler)delegate
                {
                    dataGridView1.Rows[index].Cells[15].Value = all[20];
                });
                //换行
                index++;
                pass++;
            }
            //改变页码
            page = pi;
            //labe1.Text = page + "/55";
            label1.Text = page + "/74";

            //清空文字框内容
            textBox1.Text = "";
            return url;
        }

        //获得两位有效数字的字符串百分数
        string getPercent(string temp)
        {
            if (temp.Length == 0)
            {
                return "---";
            }
            double d = Math.Round(Convert.ToDouble(temp), 2);
            temp = d.ToString();
            if (Convert.ToInt32(d) - d == 0)
                temp += ".00%";
            else if (Convert.ToInt32(d*10) - d*10 == 0)
                temp += "0%";
            else
                temp += "%";
            return temp;
        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        //下一页
        private void button2_Click(object sender, EventArgs e)
        {
            //if (page == 55)
            if(page == 74)
                return;
            turnTo(page + 1);
        }
        //上一页
        private void button1_Click(object sender, EventArgs e)
        {
            if (page == 1)
                return;
            turnTo(page - 1);
        }
        //转到特定页
        private void button3_Click(object sender, EventArgs e)
        {
            //使用try catch通过文字框内容转到特定页，并抛出错误输出
            try
            {
                int a = Convert.ToInt32(textBox1.Text);
                //if (!(a > 0 && a < 56))
                if(!(a > 0 && a < 75))
                    throw new Exception();
                turnTo(a);
            }
            catch(Exception ex)
            {
                MessageBox.Show("输入错误，请检查您输入的数字（1-74）。", "提示");
                textBox1.Text = "";
                textBox1.Enabled = true;
                textBox2.Enabled = true;
                button1.Enabled = true;
                button2.Enabled = true;
                button3.Enabled = true;
                button5.Enabled = true;
            }
        }

        //输入基金代码查看某只基金详情
        private void button5_Click(object sender, EventArgs e)
        {
            string str = textBox2.Text;

            //通过try catch把输入的基金代码转到网页，若网页不存在，则抛出错误，
            //同时把输入的错误基金代号的格式抛出
            try
            {
                string x = GetContent(@"http://fund.eastmoney.com/" + str + ".html");
                x = x.Substring(x.IndexOf("<title>") + 7);
                x = x.Substring(0, x.IndexOf("</title>"));
                if (!(x.Contains(str)))
                {
                    throw new Exception();
                }
                Form2 f = new Form2(str);
                f.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("输入错误，不存编号为" + str + "的基金。", "提示");
                textBox1.Text = "";
                textBox1.Enabled = true;
                textBox2.Enabled = true;
                button1.Enabled = true;
                button2.Enabled = true;
                button3.Enabled = true;
                button5.Enabled = true;
            }
        }

        //查看某只基金详情
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Form2 f = new Form2(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            f.Show();
        }
        
        private void getID()
        {
            //for (int i = 1; i < 56; i++)
            for (int i = 1; i < 75; i++)
            {
                this.Invoke((EventHandler)delegate
                {
                    string url = "http://fund.eastmoney.com/data/rankhandler.aspx?op=ph&dt=kf&ft=all&rs=&gs=0&sc=zzf&st=desc&sd=2015-10-29&ed=2016-10-29&qdii=&tabSubtype=,,,,,&pi="
                        + i + "&pn=50&dx=1&v=0.10850418109563731";

                    string data = GetContent(url);
                    //正则表达式，提取每两个引号之间内容
                    Regex re = new Regex("(?<=\").*?(?=\")", RegexOptions.None);

                    //用正则表达式提取内容
                    MatchCollection mc = re.Matches(data);
                    foreach (Match funds in mc)
                    {
                        string fund = funds.Value;
                        //把逗号之间的内容提取出来放进string数组里
                        string[] all = Regex.Split(fund, ",", RegexOptions.IgnoreCase);
                        if (all[0].Length == 0)
                            continue;
                        fundsID.Add(all[0]);
                    }
                });
            }
        }

        private void getFundHTML()
        {
            string url;
            string HTML;
            foreach (string ID in fundsID)
            {
                url = "http://fund.eastmoney.com/" + ID + ".html";

                HTML = GetContent(url);

                inText(HTML, "latest\\"+ID);
            }
        }

        void sortSum(List<Stock> tmp,int k)
        {
            bool isSort;
            foreach (Stock st in stocks)
            {

                isSort = false;
                for (int i = 0; i < tmp.Count; i++)
                {
                    if (tmp.ElementAt(i).sum[k] < st.sum[k])
                    {
                        tmp.Insert(i, st);
                        isSort = true;
                        break;
                    }
                }
                if (!isSort)
                {
                    tmp.Add(st);
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DirectoryInfo folder = new DirectoryInfo("..\\..\\stock\\latest\\");
            if (stocks.Count < 100)
            {
                getID();
                if (folder.GetFiles("*.txt").Count() < 100)
                    getFundHTML();    
            }
            
            List<string> names = getFile("latest");

            string content;
            string total, percent;

            double sums;
            foreach(string name in names)
            {
                content = Read("latest\\" + name);
                content = content.Substring(content.IndexOf("基金规模") + 9);
                total = content.Substring(0, content.IndexOf("亿"));
                if (total == "--")
                    continue;
                sums = Convert.ToDouble(total);


                content = content.Substring(content.IndexOf("股票名称"));
                content = content.Substring(0, content.IndexOf("</table>"));
                while (content.Contains("alignLeft"))
                {
                    content = content.Substring(content.IndexOf("alignLeft"));
                    content = content.Substring(content.IndexOf(">") + 1);

                    //string tmp1 = content.Substring(0, 2);
                    string tmp1 = content.Substring(0, 5);
                    if (tmp1 == "   <a")
                    //if (tmp1 == "<a")
                            content = content.Substring(content.IndexOf(">") + 1);
                    string stockName = content.Substring(0, content.IndexOf("<"));
                    content = content.Substring(content.IndexOf("alignRight"));
                    content = content.Substring(content.IndexOf(">") + 1);
                    percent = content.Substring(0, content.IndexOf("<") - 1);
                    sums *= Convert.ToDouble(percent) / 100.0;
                    bool isMatch = false;
                    foreach (Stock sto in stocks)
                    {
                        if (sto.name == stockName)
                        {
                            sto.sum[2] += sums;
                            isMatch = true;
                            break;
                        }
                    }
                    if (!isMatch)
                    {
                        Stock st = new Stock();
                        st.name = stockName;
                        st.sum[2] = sums;
                        stocks.Add(st);
                    }
                }
            }
            List<Stock> tmp = new List<Stock>();
            sortSum(tmp,2);
          
            string result = "";
            for(int i = 0; i < 100; i++)
            {
                result += tmp.ElementAt(i).name + "," + tmp.ElementAt(i).sum[2] + ",";
            }
            inText(result, "result\\result_latest", "Default");
       }

        void inText(string data, string name,string str="UTF8")
        {
            FileStream fs = new FileStream("..\\..\\stock\\" + name + ".txt", FileMode.Create);
            //获得字节数组
            byte[] datas;
            if (str == "UTF8")
            {
                datas = System.Text.Encoding.UTF8.GetBytes(data);
                fs.Write(datas, 0, data.Length);
            }
            else
            {
                datas = System.Text.Encoding.Default.GetBytes(data);
                fs.Write(datas, 0, datas.Length);
            }
            //开始写入
            //清空缓冲区、关闭流
            fs.Flush();
            fs.Close();
        }

        List<string> getFile(string folderName)//搜索文件夹中的文件
        {
            //list数组步用指定长度
            List<string> b = new List<string>();

            //读取路径下的信息
            DirectoryInfo folder = new DirectoryInfo("..\\..\\stock\\"+folderName+"\\");
            
            for (int i = 0; i < folder.GetFiles("*.txt").Count(); i++)
            {
                b.Add(folder.GetFiles("*.txt")[i].Name);
            }
            
            return b;
        }

        private string Read(string name)
        {
            StreamReader sr = new StreamReader("..\\..\\stock\\" + name, Encoding.UTF8);
            String data = sr.ReadToEnd();
            return data;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form4 form4 = new Form4();
            form4.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Form5 form5 = new Form5();
            form5.Show();
        }

        private void getDetailHTML(string year,string month,string quarter)
        {
            string url;
            string HTML;
            foreach (string ID in fundsID)
            {   //获取2017年第二季度数据
                url = "http://fund.eastmoney.com/f10/FundArchivesDatas.aspx?type=jjcc&code=" + ID + "&topline=10&year="+year+"&month="+month;

                HTML = GetContent(url);

                inText(HTML, year+quarter+"\\"+ID);
            }
        }

        //button7 获取第二季度数据
      private void button7_Click(object sender, EventArgs e) {
            DirectoryInfo folder2 = new DirectoryInfo("..\\..\\stock\\2017q2\\");
             getID();
             if (folder2.GetFiles("*.txt").Count() < 100)
                 getDetailHTML("2017", "6", "Q2");
             getData("2017Q2", "2017-06-30", 0);

            List<Stock> tmp = new List<Stock>();
            sortSum(tmp,0);

            string result = "";
            for(int i = 0; i < 100; i++)
            {
                result += tmp.ElementAt(i).name + "," + tmp.ElementAt(i).sum[0] + ",";
            }

            inText(result, "result\\result_2017Q2", "Default");

        }

        private void button10_Click(object sender, EventArgs e)
        {
            Form6 form6 = new Form6();
            form6.Show();
        }

        void getData(string folderName, string date,int k) {
            List<string> names = getFile(folderName);
            string content;
            string sNum="", sValue="";
            string stockName="";
            bool flag; ;
            double stockNum = 0.0;
            double stockValue = 0.0;

            foreach (string name in names)
            {
                flag = false;
                content = Read(folderName+"\\" + name);
                if (content.Contains(date))
                {
                    content = content.Substring(content.IndexOf(date));
                    if (content.Contains("最新价"))  flag = true; 
                    if (content.Contains("季度股票投资明细"))
                        content = content.Substring(0, content.IndexOf("季度股票投资明细"));
                    if (content.Contains("<tbody>")) content = content.Substring(content.IndexOf("<tbody>"));
                   // content = content.Substring(0, content.IndexOf("</tbody>"));
                    while (content.Contains("<tr>"))
                    {
                        if (content.Contains("<tr>")) content = content.Substring(content.IndexOf("<tr>"));
                        if(content.Contains("tol")) content = content.Substring(content.IndexOf("tol")+1);
                        if(content.Contains("html")) content = content.Substring(content.IndexOf("html"));
                        if (content.Contains(">")) content = content.Substring(content.IndexOf(">")+1);

                        if (content.Contains("</a")) stockName = content.Substring(0, content.IndexOf("</a"));

                        if (flag)
                        {   if(content.Contains("tor")) content = content.Substring(content.IndexOf("tor") + 1);
                            if(content.Contains("tor")) content = content.Substring(content.IndexOf("tor") + 1);
                        }
                        if (content.Contains("tor")) content = content.Substring(content.IndexOf("tor") + 1);
                        if (content.Contains("tor")) content = content.Substring(content.IndexOf("tor") + 1);
                        if (content.Contains(">")) content = content.Substring(content.IndexOf(">")+1);
                        if (content.Contains("<")) sNum = content.Substring(0, content.IndexOf("<"));

                        if(double.TryParse(sNum, out stockNum))  stockNum = Convert.ToDouble(sNum);

                        if (content.Contains("tor")) content = content.Substring(content.IndexOf("tor") + 1);
                        if (content.Contains(">")) content = content.Substring(content.IndexOf(">")+1);
                        if (content.Contains("<")) sValue = content.Substring(0, content.IndexOf("<"));
                        if (double.TryParse(sValue,out stockValue)) stockValue = Convert.ToDouble(sValue);

                        bool isMatch = false;

                        foreach (Stock sto in stocks)
                        {
                            if (sto.name == stockName)
                            {
                                sto.sum[k] += stockValue;
                                sto.num[k] += stockNum;
                                isMatch = true;
                                break;
                            }
                        }
                        if (!isMatch)
                        {
                            Stock st = new Stock();
                            st.name = stockName;
                            st.sum[k] = stockValue;
                            st.num[k] = stockNum;
                            stocks.Add(st);
                        }
                    }
                }
            }
        }

        //button9 获取第三季度数据
        private void button9_Click(object sender, EventArgs e)
        {
            DirectoryInfo folder3 = new DirectoryInfo("..\\..\\stock\\2017q3\\");

            getID();
            if (folder3.GetFiles("*.txt").Count() < 100)
               getDetailHTML("2017", "9", "Q3");
            getData("2017Q3", "2017-09-30", 1);

            List<Stock> tmp = new List<Stock>();
            sortSum(tmp,1);

            string result = "";
            for (int i = 0; i < 100; i++)
            {
                result += tmp.ElementAt(i).name + "," + tmp.ElementAt(i).sum[1] + ",";
            }

            inText(result, "result\\result_2017Q3", "Default");

        }

        void sortNumDif(List<Stock> tmp)
        {
            bool isSort;
            foreach (Stock st in stocks)
            {

                isSort = false;
                for (int i = 0; i < tmp.Count; i++)
                {
                    if (tmp.ElementAt(i).num[1]- tmp.ElementAt(i).num[0] < st.num[1]-st.num[0])
                    {
                        tmp.Insert(i, st);
                        isSort = true;
                        break;
                    }
                }
                if (!isSort)
                {
                    tmp.Add(st);
                }
            }
        }

        private void button11_Click(object sender, EventArgs e) {
            //先判断 若stock已有数据，直接使用stocks数据
            //若stocks无数据，但q2、q3已有文件，则直接使用文件
            //若均无，则按原始步骤
            DirectoryInfo folder2 = new DirectoryInfo("..\\..\\stock\\2017q2\\");
            DirectoryInfo folder3 = new DirectoryInfo("..\\..\\stock\\2017q3\\");
            getID();
            if(folder2.GetFiles("*.txt").Count()<100)
               getDetailHTML("2017", "6", "Q2");
            if (folder3.GetFiles("*.txt").Count() < 100)
                getDetailHTML("2017", "9", "Q3");
                getData("2017Q2", "2017-06-30", 0);
                getData("2017Q3", "2017-09-30", 1);
            
            List<Stock> tmp = new List<Stock>();
            sortNumDif(tmp);
            string result1 = "";
            string result2 = "";
            for(int i = 0; i < 50; i++)
            {
                result1 += tmp.ElementAt(i).name + "," + (tmp.ElementAt(i).num[1]- tmp.ElementAt(i).num[0]) + ",";
            }
            inText(result1, "result\\result_increase", "Default");
            for (int i = tmp.Count-1; i >tmp.Count-51; i--)
            {
                result2+= tmp.ElementAt(i).name + "," + (tmp.ElementAt(i).num[0]- tmp.ElementAt(i).num[1]) + ",";
            }
            inText(result2, "result\\result_decrease", "Default");
        }

        private void button12_Click(object sender, EventArgs e) {
            Form7 form7 = new Form7();
            form7.Show();
        }

        void createFolder(string path)
        {
            DirectoryInfo di = new DirectoryInfo(path);
            di.Create();
        }

        void deleteFiles(string path)
        {
            foreach (string d in Directory.GetFileSystemEntries(path))
            {
                if (File.Exists(d))
                {
                    FileInfo fi = new FileInfo(d);
                    if (fi.Attributes.ToString().IndexOf("ReadOnly") != -1)
                        fi.Attributes = FileAttributes.Normal;
                    File.Delete(d);     //删除文件   
                }
            }
        }

        //清除已生成的文件
        private void button13_Click(object sender, EventArgs e)
        {
            deleteFiles("..\\..\\stock\\result\\");
            deleteFiles("..\\..\\stock\\latest\\");
            deleteFiles("..\\..\\stock\\2017q3\\");
            deleteFiles("..\\..\\stock\\2017q2\\");

        }
    }

    public class Stock
    {
        public string name { get; set; }

        private double[] s = new double[3];
        private double[] n = new double[2];

        public double[] sum {
            get { return s; }
            set { s = value; }
        }
        public double[] num {
            get { return n; }
            set { n = value; }
        }
    }

}







