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
        int tPage = 1;

        List<string> fundsID = new List<string>();
        List<Stock> stocks = new List<Stock>();

        public Form1()
        {
            InitializeComponent();
            this.skinEngine1.SkinFile = "skin.ssk";
            tPage = GetTotalPage();
            label1.Text = page + "/" + tPage.ToString();//总页数
            ThreadStart ts = new ThreadStart(GetIntroduction);
            td = new Thread(ts);
            td.SetApartmentState(ApartmentState.STA);
            td.Start();
        }

        void GetIntroduction()
        {
            turnTo(1);
            createFolder("..\\..\\stock\\");//若无目的文件夹，则在程序第一次打开时创建文件夹，避免因目录不存在引发异常
            createFolder("..\\..\\stock\\result\\");
            createFolder("..\\..\\stock\\latest\\");
            createFolder("..\\..\\stock\\2017q2\\");
            createFolder("..\\..\\stock\\2017q3\\");
        }
        //获取总页数 使爬取数据总页数可随网站数据动态更新
        int GetTotalPage()
        {
            int page=0;
            string str = GetContent("http://fund.eastmoney.com/data/rankhandler.aspx?op=ph&dt=kf&ft=all&rs=&gs=0&sc=zzf&st=desc&qdii=&tabSubtype=,,,,,&pi=1&pn=50&dx=1&v=0.10850418109563731");
            str = str.Substring(str.IndexOf("allPages"));
            str = str.Substring(str.IndexOf(":") + 1);
            str = str.Substring(0, str.IndexOf(","));
            page = Convert.ToInt32(str);
            return page;
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
            label1.Text = page + "/"+tPage.ToString();


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

        //下一页
        private void button2_Click(object sender, EventArgs e)
        {
            //if (page == 55)
            //if(page == 74)
            if (page == tPage)
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
                //if(!(a > 0 && a < 75))
                if (!(a > 0 && a < tPage+1))
                    throw new Exception();
                turnTo(a);
            }
            catch(Exception ex)
            {
                MessageBox.Show("输入错误，请检查您输入的数字（1-"+tPage.ToString()+"）。", "提示");
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
                MessageBox.Show("输入错误，不存在编号为" + str + "的基金。", "提示");
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
        
        private void button4_Click(object sender, EventArgs e)
        {
            //读取指定文件夹下的文件信息
            DirectoryInfo folder = new DirectoryInfo("..\\..\\stock\\latest\\");
            getID();

            if (folder.GetFiles("*.txt").Count() < 100)//若文件夹下文件数目较少，说明该文件所需数据还未加载过，需要先获取网页再进行后续操作
                getFundHTML(); //获取基金网页   

            
            List<string> names = getFile("latest");

            string content;
            string total, percent;
            string stockCode;
            string stockName;
            double sums;
            foreach(string name in names)//对网页内容字符串进行分割
            {//每次循环需重新初始化赋值，避免极少数情况下误记为上次循环值
                total = "";
                percent = "";
                sums = 0.0;
                stockCode = "";
                stockName = "";
                content = Read("latest\\" + name);//content初始值为txt文本全部内容
                //对数据不断进行截取清洗
                //条件判断的使用 由于网页中有些数据项为空，避免抓取时出现异常
                if (content.Contains("基金规模")) content = content.Substring(content.IndexOf("基金规模") + 9);
                if (content.Contains("亿")) total = content.Substring(0, content.IndexOf("亿"));
                if (total == "--")
                    continue;
                sums = Convert.ToDouble(total);

                if (content.Contains("股票名称")) content = content.Substring(content.IndexOf("股票名称"));
                if (content.Contains("</table>")) content = content.Substring(0, content.IndexOf("</table>"));
                while (content.Contains("alignLeft"))
                {
                    if (content.Contains("alignLeft")) content = content.Substring(content.IndexOf("alignLeft"));
                    if (content.Contains(">")) content = content.Substring(content.IndexOf(">") + 1);

                    //string tmp1 = content.Substring(0, 2);
                    string tmp1 = content.Substring(0, 5);
                    if (tmp1 == "   <a")
                    //if (tmp1 == "<a")
                    {
                        if (content.Contains(".com/")) content = content.Substring(content.IndexOf(".com/") + 5);
                        //tmp2的作用：对数字股票代码（如sz000001）和字母股票代码（如/us/BABA）抓取时进行区分
                        string tmp2 = "";
                        if (content.Contains(".html")) tmp2 = content.Substring(0, content.IndexOf(".html"));
                        if (tmp2.Contains("/"))
                        {
                            if (content.Contains("/l")) content = content.Substring(content.IndexOf("/") + 1);
                        }
                        else
                        {
                            if (content.Length > 5) content = content.Substring(2);
                        }
                        //获取股票代码
                        if (content.Contains(".html")) stockCode = content.Substring(0, content.IndexOf(".html"));
                        if (content.Contains(">")) content = content.Substring(content.IndexOf(">") + 1);
                    }
                    //获取股票名称
                    if (content.Contains("<")) stockName = content.Substring(0, content.IndexOf("<"));
                    if (content.Contains("alignRight")) content = content.Substring(content.IndexOf("alignRight"));
                    if (content.Contains(">")) content = content.Substring(content.IndexOf(">") + 1);
                    percent = content.Substring(0, content.IndexOf("<") - 1);
                    //获取股票在单支基金中的持仓金额
                    sums *= Convert.ToDouble(percent) / 100.0;
                    bool isMatch = false;
                    //对该股票在所有基金中的持仓金额进行累加
                    foreach (Stock sto in stocks)
                    {
                        if (sto.name == stockName)
                        {
                            sto.sum[2] += sums;//sum[2]指股票的实时数据
                            isMatch = true;//该股票已在list中，可以直接累加
                            break;
                        }
                    }
                    if (!isMatch)//该股票不在list中，为一支“新”股票。则需要将股票添加入list，持仓金额和数目为当前值
                    {
                        if (stockName != "" && stockCode != "")
                        {
                            Stock st = new Stock();
                            st.name = stockName;
                            st.code = stockCode;
                            st.sum[2] = sums;
                            stocks.Add(st);
                        }
                    }
                }
            }
            List<Stock> tmp = new List<Stock>();
            sortSum(tmp,2);//对持股金额进行排序

            string result = "";
            //获取所有已对持股金额排序后的股票信息
            //for(int i = 0; i < 100; i++)
            //{                
            //  result += tmp.ElementAt(i).code+","+tmp.ElementAt(i).name + "," + tmp.ElementAt(i).sum[2] + ",";
            //}
            foreach (Stock t in tmp)
            {
                result += t.code + "," + t.name + "," + t.sum[2] + ",";
            }

            inText(result, "result\\result_latest", "Default");//排序所得结果写入文件，方便后续读取
            //加载完成后提示
            MessageBox.Show("数据更新完成。您可以点击对应\"查看排行\"按钮查看股票排行。");
       }

        private void getID()
        {
            //for (int i = 1; i < 56; i++)
            // for (int i = 1; i < 75; i++)
            for (int i = 1; i < tPage + 1; i++)
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

        //获取基金主页网页内容。代码部分放进函数里，减少重复代码
        private void getFundHTML()
        {
            string url;
            string HTML;
            foreach (string ID in fundsID)
            {
                url = "http://fund.eastmoney.com/" + ID + ".html";

                HTML = GetContent(url);//获取对应持仓数据页面内容

                inText(HTML, "latest\\" + ID);//写入txt文件
            }
        }

        //将获取的内容写入文本文件
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
            
            for (int i = 0; i < folder.GetFiles("*.txt").Count(); i++)//读取路径下所有txt文件名称
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

        private void getDetailHTML(string year, string month, string quarter)
        {
            string url;
            string HTML;
            foreach (string ID in fundsID)
            {
                url = "http://fund.eastmoney.com/f10/FundArchivesDatas.aspx?type=jjcc&code=" + ID + "&topline=10&year=" + year + "&month=" + month;

                HTML = GetContent(url);//获取对应持仓数据页面内容

                inText(HTML, year + quarter + "\\" + ID);//写入txt文件
            }
        }

        void getData(string folderName, string date, int k)
        {
            List<string> names = getFile(folderName);
            string content;
            string sNum, sValue;
            string stockName;
            string stockCode;
            bool flag;
            double stockNum;
            double stockValue;

            foreach (string name in names)
            {//每次循环需重新初始化赋值，避免极少数情况下误记为上次循环值
                sNum = "";
                sValue = "";
                stockName = "";
                stockCode = "";
                flag = false;
                stockNum = 0.0;
                stockValue = 0.0;
                content = Read(folderName + "\\" + name);//content初始值为txt文本全部内容

                //对数据不断进行截取清洗
                if (content.Contains(date))
                {
                    content = content.Substring(content.IndexOf(date));

                    //条件判断的使用 由于网页中有些数据项为空，避免抓取时出现异常
                    if (content.Contains("最新价")) flag = true;
                    if (content.Contains("季度股票投资明细"))
                        content = content.Substring(0, content.IndexOf("季度股票投资明细"));
                    if (content.Contains("<tbody>")) content = content.Substring(content.IndexOf("<tbody>"));
                    while (content.Contains("<tr>"))
                    {
                        if (content.Contains("<tr>")) content = content.Substring(content.IndexOf("<tr>"));
                        if (content.Contains("tol")) content = content.Substring(content.IndexOf("tol") + 1);
                        if (content.Contains(".com/")) content = content.Substring(content.IndexOf(".com/") + 5);
                        //tmp2的作用：对数字股票代码（如sz000001）和字母股票代码（如/us/BABA）抓取时进行区分
                        string tmp2 = "";
                        if (content.Contains(".html")) tmp2 = content.Substring(0, content.IndexOf(".html"));
                        if (tmp2.Contains("/"))
                        {
                            if (content.Contains("/")) content = content.Substring(content.IndexOf("/") + 1);
                        }
                        else
                        {
                            if (content.Length > 5) content = content.Substring(2);
                        }
                        //获取股票代码
                        if (content.Contains(".html")) stockCode = content.Substring(0, content.IndexOf(".html"));

                        if (content.Contains(">")) content = content.Substring(content.IndexOf(">") + 1);
                        //获取股票名称
                        if (content.Contains("</a")) stockName = content.Substring(0, content.IndexOf("</a"));

                        if (flag)
                        {
                            if (content.Contains("tor")) content = content.Substring(content.IndexOf("tor") + 1);
                            if (content.Contains("tor")) content = content.Substring(content.IndexOf("tor") + 1);
                        }
                        if (content.Contains("tor")) content = content.Substring(content.IndexOf("tor") + 1);
                        if (content.Contains("tor")) content = content.Substring(content.IndexOf("tor") + 1);
                        if (content.Contains(">")) content = content.Substring(content.IndexOf(">") + 1);
                        //获取股票在单支基金中的持仓数目
                        if (content.Contains("<")) sNum = content.Substring(0, content.IndexOf("<"));
                        if (double.TryParse(sNum, out stockNum)) stockNum = Convert.ToDouble(sNum);

                        if (content.Contains("tor")) content = content.Substring(content.IndexOf("tor") + 1);
                        if (content.Contains(">")) content = content.Substring(content.IndexOf(">") + 1);
                        //获取股票在单支基金中的持仓金额
                        if (content.Contains("<")) sValue = content.Substring(0, content.IndexOf("<"));
                        if (double.TryParse(sValue, out stockValue)) stockValue = Convert.ToDouble(sValue);

                        bool isMatch = false;
                        //对该股票在所有基金中的持仓金额和数目进行累加
                        foreach (Stock sto in stocks)
                        {
                            if (sto.name == stockName)
                            {
                                sto.sum[k] += stockValue;
                                sto.num[k] += stockNum;
                                isMatch = true;//该股票已在list中，可以直接累加
                                break;
                            }
                        }
                        if (!isMatch)//该股票不在list中，为一支“新”股票。则需要将股票添加入list，持仓金额和数目为当前值
                        {
                            if (stockName != "" && stockCode != "")
                            {
                                Stock st = new Stock();
                                st.name = stockName;
                                st.code = stockCode;
                                st.sum[k] = stockValue;
                                st.num[k] = stockNum;
                                stocks.Add(st);
                            }
                        }
                    }
                }
            }
        }

        //对股票总额排序。放入函数中，减少重复代码
        void sortSum(List<Stock> tmp, int k)
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


        //对两个季度持股金额差值进行排序
        void sortSumDif(List<Stock> tmp)
        {
            bool isSort;
            foreach (Stock st in stocks)
            {

                isSort = false;
                for (int i = 0; i < tmp.Count; i++)
                {
                    if (tmp.ElementAt(i).sum[1] - tmp.ElementAt(i).sum[0] < st.sum[1] - st.sum[0])
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

        //对两个季度持股数差值进行排序
        void sortNumDif(List<Stock> tmp)
        {
            bool isSort;
            foreach (Stock st in stocks)
            {
                isSort = false;
                for (int i = 0; i < tmp.Count; i++)
                {
                    if (tmp.ElementAt(i).num[1] - tmp.ElementAt(i).num[0] < st.num[1] - st.num[0])
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

        //在指定路径下创建文件夹
        void createFolder(string path)
        {
            DirectoryInfo di = new DirectoryInfo(path);
            di.Create();
        }

        //删除指定路径文件夹下的文件
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


        private void button6_Click(object sender, EventArgs e)
        {//若文件夹下已写入result文件，则打开对应窗口展示结果
            if (File.Exists("..\\..\\stock\\result\\result_latest.txt")){
                Form4 form4 = new Form4();
                form4.Show();
            }else
            {//若文件夹下无result文件，提示用户需先更新数据。避免异常情况的产生
                MessageBox.Show("数据尚未更新。您需要先点击对应\"更新数据\"按钮，并等待数据更新完成后，才能查看排行。");
            }
        }

        //button7 获取第二季度数据
        private void button7_Click(object sender, EventArgs e)
        {
            DirectoryInfo folder2 = new DirectoryInfo("..\\..\\stock\\2017q2\\");//读取指定路径下文件信息
            getID();//获取基金ID信息
            if (folder2.GetFiles("*.txt").Count() < 100)//若Q2已有文件，则直接使用文件，减少加载写入所需时间，提升效率
                getDetailHTML("2017", "6", "Q2");//将网页内容写入txt文件

            getData("2017Q2", "2017-06-30", 0);//读取网页内容并清洗数据

            List<Stock> tmp = new List<Stock>();
            sortSum(tmp, 0);//对持股金额进行排序

            string result = "";
            //获取所有已对持股金额排序后的股票信息
            foreach (Stock t in tmp)
            {
                result += t.code + "," + t.name + "," + t.sum[0] + ",";
            }

            inText(result, "result\\result_2017Q2", "Default");//写入result文件，方便后续读取
            //加载完成后提示
            MessageBox.Show("数据更新完成。您可以点击对应\"查看排行\"按钮查看股票排行。");

        }

        private void button8_Click(object sender, EventArgs e)
        {//若文件夹下已写入result文件，则打开对应窗口展示结果
            if (File.Exists("..\\..\\stock\\result\\result_2017q2.txt"))
            {
                Form5 form5 = new Form5();
                form5.Show();
            }
            else//若文件夹下无result文件，提示用户需先更新数据。避免异常情况的产生
            {
                MessageBox.Show("数据尚未更新。您需要先点击对应\"更新数据\"按钮，并等待数据更新完成后，才能查看排行。");
            }
        }

        //button9 获取第三季度数据
        private void button9_Click(object sender, EventArgs e)
        {
            DirectoryInfo folder3 = new DirectoryInfo("..\\..\\stock\\2017q3\\");//读取指定路径下文件信息

            getID();//获取基金ID信息
            if (folder3.GetFiles("*.txt").Count() < 100)//若Q3已有文件，则直接使用文件，减少加载写入所需时间，提升效率
                getDetailHTML("2017", "9", "Q3");//将网页内容写入txt文件

            getData("2017Q3", "2017-09-30", 1);//读取网页内容并清洗数据

            List<Stock> tmp = new List<Stock>();
            sortSum(tmp, 1);//对持股金额进行排序

            string result = "";
            //获取所有已对持股金额排序后的股票信息
            foreach (Stock t in tmp)
            {
                result += t.code + "," + t.name + "," + t.sum[1] + ",";
            }

            inText(result, "result\\result_2017Q3", "Default");//写入result文件，方便后续读取
            //加载完成后提示
            MessageBox.Show("数据更新完成。您可以点击对应\"查看排行\"按钮查看股票排行。");

        }

        private void button10_Click(object sender, EventArgs e)
        {//若文件夹下已写入result文件，则打开对应窗口展示结果
            if (File.Exists("..\\..\\stock\\result\\result_2017q3.txt"))
            {
                Form6 form6 = new Form6();
                form6.Show();
            }else
            {//若文件夹下无result文件，提示用户需先更新数据。避免异常情况的产生
                MessageBox.Show("数据尚未更新。您需要先点击对应\"更新数据\"按钮，并等待数据更新完成后，才能查看排行。");
            }
        }

        private void button11_Click(object sender, EventArgs e) {
            //若Q2、Q3已有文件，则直接使用文件，减少加载写入所需时间，提升效率
            //若无，则按原始步骤
            
            //读取指定路径下文件信息
            DirectoryInfo folder2 = new DirectoryInfo("..\\..\\stock\\2017q2\\");
            DirectoryInfo folder3 = new DirectoryInfo("..\\..\\stock\\2017q3\\");

            getID();//获取基金ID信息
            if (folder2.GetFiles("*.txt").Count() < 100)
                getDetailHTML("2017", "6", "Q2");//将网页内容写入txt文件
            if (folder3.GetFiles("*.txt").Count() < 100)
                getDetailHTML("2017", "9", "Q3");

            getData("2017Q2", "2017-06-30", 0);//读取网页内容并清洗数据
            getData("2017Q3", "2017-09-30", 1);
            List<Stock> tmp1 = new List<Stock>();
            sortSumDif(tmp1);//对持股金额差值进行排序
            string resultSum1 = "";
            string resultSum2 = "";
            
            //获取Q3减Q2持股金额排名最高的50名，即增持数最高的排名
            for (int i = 0; i < 50; i++)
            {
                resultSum1 += tmp1.ElementAt(i).code + "," + tmp1.ElementAt(i).name + "," + (tmp1.ElementAt(i).sum[1] - tmp1.ElementAt(i).sum[0]) + ",";
            }
            inText(resultSum1, "result\\result_increase_sum", "Default");//写入result文件，方便后续读取
            
            //获取Q3减Q2持股金额排名最低的50名，即减持数最高的排名
            for (int i = tmp1.Count - 1; i > tmp1.Count - 51; i--)
            {//使用正数展示，展示数据使用Q2减Q3的差值
                resultSum2 += tmp1.ElementAt(i).code + "," + tmp1.ElementAt(i).name + "," + (tmp1.ElementAt(i).sum[0] - tmp1.ElementAt(i).sum[1]) + ",";
            }
            inText(resultSum2, "result\\result_decrease_sum", "Default");



            List<Stock> tmp2 = new List<Stock>();
            sortNumDif(tmp2);//对持股数目差值进行排序
            string resultNum1 = "";
            string resultNum2 = "";
            
            //获取Q3减Q2持股数排名最高的50名，即增持数最高的排名
            for(int i = 0; i < 50; i++)
            {
                resultNum1 += tmp2.ElementAt(i).code + "," + tmp2.ElementAt(i).name + "," + (tmp2.ElementAt(i).num[1]- tmp2.ElementAt(i).num[0]) + ",";
            }
            inText(resultNum1, "result\\result_increase_num", "Default");
            
            //获取Q3减Q2持股数排名最低的50名，即减持数最高的排名
            for (int i = tmp2.Count-1; i >tmp2.Count-51; i--)
            {//使用正数展示，展示数据使用Q2减Q3的差值
                resultNum2+= tmp2.ElementAt(i).code + "," + tmp2.ElementAt(i).name + "," + (tmp2.ElementAt(i).num[0]- tmp2.ElementAt(i).num[1]) + ",";
            }
            inText(resultNum2, "result\\result_decrease_num", "Default");

            //加载完成后提示
            MessageBox.Show("数据更新完成。您可以点击对应\"查看排行\"按钮查看股票排行。");
        }

        private void button12_Click(object sender, EventArgs e) {
            //若文件夹下已写入result文件，则打开对应窗口展示结果
            if (File.Exists("..\\..\\stock\\result\\result_increase_num.txt")&& File.Exists("..\\..\\stock\\result\\result_decrease_num.txt")&& File.Exists("..\\..\\stock\\result\\result_increase_sum.txt")&& File.Exists("..\\..\\stock\\result\\result_decrease_sum.txt"))
            {
                Form7 form7 = new Form7();
                form7.Show();
            }
            else//若文件夹下无result文件，提示用户需先更新数据。避免异常情况的产生
            {
                MessageBox.Show("数据尚未更新。您需要先点击对应\"更新数据\"按钮，并等待数据更新完成后，才能查看排行。");
            }
        }



        //点击可清除文件夹下已生成的文件，以清理空间
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
        public string code { get; set; }//股票代码
        public string name { get; set; }//股票名称

        private double[] s = new double[3];// 第0位为第二季度数据，第1位为第三季度数据，第2位为实时数据
        private double[] n = new double[2];// 第0位为第二季度数据，第1位为第三季度数据

        public double[] sum {//股票总持仓金额 
            get { return s; }
            set { s = value; }
        }
        public double[] num {//股票总持仓数目
            get { return n; }
            set { n = value; }
        }
    }

}







