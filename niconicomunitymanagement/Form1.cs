using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Hal.CookieGetterSharp;
using System.Threading;
using System.Text.RegularExpressions;
using System.Net;
using System.IO;
using System.Diagnostics;

namespace niconicomunitymanagement
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            dataGridViewnyu.TopLeftHeaderCell.Value = "入会";
            dataGridViewtai.TopLeftHeaderCell.Value = "退会";
            dataGridViewcom.ContextMenuStrip = this.contextMenuStrip1;
            
            //フォルダ・コミュ一覧設定
            if (Properties.Settings.Default.hozonbasyo == "に")
            {
                labelpath.Text = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
                folderBrowserDialog1.SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
                Properties.Settings.Default.hozonbasyo = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
                Properties.Settings.Default.Save();

            }
            else
            {
                string line = "";
                try
                {
                    using (StreamReader sr = new StreamReader(Properties.Settings.Default.hozonbasyo + "\\comname.txt", Encoding.GetEncoding("UTF-8")))
                    {
                        while ((line = sr.ReadLine()) != null)
                        {
                            string[] ss = line.Split('\t');
                            dataGridViewcom.Rows.Add(ss[0], ss[1], ss[2], ss[3]);
                        }
                    }
                }
                catch { }

                labelpath.Text = Properties.Settings.Default.hozonbasyo;                           
            }
        }

        //private CookieCollection collection;
        private CookieContainer m_cc;//クッキーコンテナ
        private HttpWebRequest req;
        private Cookie ck;

        private string k_comban = "";
        private List<string> listid_kyu_id = new List<string>();
        private List<string> listid_kyu_name = new List<string>();
        private List<string> listidmentu = new List<string>();
        private List<string> listnamementu = new List<string>();

        private delegate void dldl();
       
        //コミュ追加
        private void textBoxurl_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;

                button3.Enabled = false;
                comboBox1.Enabled = false;
                textBoxurl.Enabled = false;
                button2.Enabled = false;
                button1.Enabled = false;
                dataGridViewcom.Enabled = false;

                Thread th = new Thread(comtouroku);
                th.Start();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            button3.Enabled = false;
            comboBox1.Enabled = false;
            textBoxurl.Enabled = false;
            button2.Enabled = false;
            button1.Enabled = false;
            dataGridViewcom.Enabled = false;

            Thread th = new Thread(comtouroku);
            th.Start();

        }

        private string commeimach1 = "コミュニティメンバー:";
        private string commeimach2 = "-ニコニコミュニティ";
        private string menidmach = "<p class=\"thumb\"><a href=\"http://www.nicovideo.jp/user/";
        private string mennamemach1 = "<p class=\"name\"><a href=\"http://www.nicovideo.jp/user/";
        private string mennamemach2 = "\" target=\"_blank\">";
        private string mennamemach3 = "</a></p>";
        private void comtouroku()
        {
            if (Directory.Exists(Properties.Settings.Default.hozonbasyo))
            {
                Match mc = null;
                Invoke(new dldl(delegate {
                mc = new Regex(@"co\d+", RegexOptions.Singleline).Match(textBoxurl.Text);
                }));

                if (mc.Success)
                {
                    bool comcho = true;
                    Invoke(new dldl(delegate { comcho = comchoufukukakunin(mc.Value); }));
                    if (comcho)
                    {
                        req = (HttpWebRequest)WebRequest.Create("http://com.nicovideo.jp/member/" + mc.Value);
                        req.CookieContainer = m_cc;//取得済みのクッキーコンテナ                        

                        using (StreamReader sr = new StreamReader(req.GetResponse().GetResponseStream(), Encoding.UTF8))
                        {
                            string stg = sr.ReadToEnd();

                            if (!new Regex("先にコミュニティに入会してください", RegexOptions.IgnoreCase).Match(stg).Success)
                            {
                                if (!new Regex("<p class=\"error_description\">", RegexOptions.IgnoreCase | RegexOptions.Singleline).Match(stg).Success)
                                {
                                    //コミュ名取得
                                    string commei = new Regex(commeimach1 + ".+?" + commeimach2, RegexOptions.IgnoreCase | RegexOptions.Singleline).Match(stg).Value.Replace(commeimach1, "").Replace(commeimach2, "");

                                    MatchCollection mcc;
                                    int n = 0;
                                    int mensu = 0;
                                    using (StreamWriter sw = new StreamWriter(Properties.Settings.Default.hozonbasyo + @"\" + mc.Value + ".txt", false, Encoding.UTF8))
                                    {
                                        do
                                        {//初期コミュ
                                            n++;

                                            req = (HttpWebRequest)WebRequest.Create("http://com.nicovideo.jp/member/" + mc.Value + "?page=" + n.ToString() + "&order=a");
                                            req.CookieContainer = m_cc;//取得済みのクッキーコンテナ

                                            using (StreamReader srr = new StreamReader(req.GetResponse().GetResponseStream(), Encoding.UTF8))
                                            {
                                                string sss = srr.ReadToEnd();
                                                mcc = new Regex(menidmach + @"\d+", RegexOptions.Singleline).Matches(sss);

                                                foreach (Match m in mcc)
                                                {
                                                    mensu++;
                                                    sw.WriteLine(m.Value.Replace(menidmach, "") + "\t" + new Regex(mennamemach1 + m.Value.Replace(menidmach, "") + mennamemach2 + @".*?" + mennamemach3).Match(sss).Value.Replace(mennamemach1, "").Replace(m.Value.Replace(menidmach, ""), "").Replace(mennamemach2, "").Replace(mennamemach3, ""));
                                                    Invoke(new dldl(delegate
                                                    {
                                                        textBoxhelp.Text = "ユーザ情報" + mensu.ToString() + "名取得";
                                                        this.Refresh();
                                                    }));
                                                }
                                            }
                                        }
                                        while (mcc.Count != 0);
                                    }

                                    using (StreamWriter sw = new StreamWriter(Properties.Settings.Default.hozonbasyo + @"\comname.txt", true, Encoding.UTF8))
                                    {
                                        sw.WriteLine(mc.Value + "\t" + commei + "\t" + mensu.ToString() + "\t" + DateTime.Now.ToString());//コミュ番・コミュ名・コミュ人数・最終確認日
                                    }

                                    Invoke(new dldl(delegate
                                    {
                                        dataGridViewcom.Rows.Add(mc.Value, commei, mensu.ToString(), DateTime.Now.ToString());
                                        textBoxurl.Text = "";
                                        textBoxhelp.Text = "コミュニティを表から選択し管理開始を押してください。";
                                        button1.Enabled = true;
                                    }));
                                }
                                else
                                {
                                    MessageBox.Show("コミュニティは存在しないか、削除された可能性があります。");
                                }
                            }
                            else
                            {
                                MessageBox.Show("先にコミュニティに入会して下さい。");
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("このコミュニティは既に追加されています。");

                    }
                }
                else
                {
                    MessageBox.Show("コミュニティページを入力して下さい。");
                }
            }
            else
            {
                MessageBox.Show("保存場所を設定して下さい。");
            } 
            
            
            Invoke(new dldl(delegate {
                button3.Enabled = true;
                comboBox1.Enabled = true;
                textBoxurl.Enabled = true;
                button2.Enabled = true;
                button1.Enabled = true;
                dataGridViewcom.Enabled = true;
                }));
        }

        //コミュ管理開始
        private void button1_Click(object sender, EventArgs e)
        {
            kannrikaisi();
        }

        private void kannrikaisi()
        {
            button1.Enabled = false;
            comboBox1.Enabled = false;
            textBoxurl.Enabled = false;
            button3.Enabled = false;
            button2.Enabled = false;
            dataGridViewcom.Enabled = false;

            if (Directory.Exists(Properties.Settings.Default.hozonbasyo))
            {
                if (dataGridViewcom.SelectedRows.Count > 0)
                {
                    k_comban = (string)dataGridViewcom[0, dataGridViewcom.SelectedRows[0].Index].Value;
                    if (File.Exists(Properties.Settings.Default.hozonbasyo + "\\" + k_comban + ".txt"))
                    {
                        dataGridViewnyu.Rows.Clear();
                        dataGridViewtai.Rows.Clear();
                        listid_kyu_id.Clear();
                        listid_kyu_name.Clear();
                        listidmentu.Clear();
                        listnamementu.Clear();
                        Thread th = new Thread(hikaku);
                        th.Start();
                    }
                    else
                    {
                        MessageBox.Show("コミュニティメンバーファイル " + k_comban + ".txt が存在しません。");

                        button1.Enabled = true;
                        comboBox1.Enabled = true;
                        textBoxurl.Enabled = true;
                        button3.Enabled = true;
                        button2.Enabled = true;
                        dataGridViewcom.Enabled = true;
                    }
                }
                else
                {
                    MessageBox.Show("表からコミュニティを選択して下さい。");

                    button1.Enabled = true;
                    comboBox1.Enabled = true;
                    textBoxurl.Enabled = true;
                    button3.Enabled = true;
                    button2.Enabled = true;
                    dataGridViewcom.Enabled = true;
                }
            }
            else
            {
                MessageBox.Show("保存場所を設定して下さい。");

                button1.Enabled = true;
                comboBox1.Enabled = true;
                textBoxurl.Enabled = true;
                button3.Enabled = true;
                button2.Enabled = true;
                dataGridViewcom.Enabled = true;
            }
        }

        private void hikaku()
        {
            req = (HttpWebRequest)WebRequest.Create("http://com.nicovideo.jp/member/" + k_comban);
            req.CookieContainer = m_cc;//取得済みのクッキーコンテナ

            using (StreamReader sr = new StreamReader(req.GetResponse().GetResponseStream(), Encoding.UTF8))
            {
                string stg = sr.ReadToEnd();

                if (!new Regex("先にコミュニティに入会してください", RegexOptions.IgnoreCase).Match(stg).Success)
                {
                    if (!new Regex("<p class=\"error_description\">", RegexOptions.IgnoreCase | RegexOptions.Singleline).Match(stg).Success)
                    {
                        //コミュ名取得
                        string commei = new Regex(commeimach1 + ".+?" + commeimach2, RegexOptions.IgnoreCase | RegexOptions.Singleline).Match(stg).Value.Replace(commeimach1, "").Replace(commeimach2, "");

                        //ファイルからID取得
                        string line;
                        using (StreamReader srr = new StreamReader(Properties.Settings.Default.hozonbasyo + "\\" + k_comban + ".txt", Encoding.UTF8))
                        {
                            while ((line = srr.ReadLine()) != null)
                            {
                                string[] ss = line.Split('\t');
                                listid_kyu_id.Add(ss[0]);
                                listid_kyu_name.Add(ss[1]);
                            }
                        }

                        //ネットから新ID取得
                        MatchCollection mcc;
                        int n = 0;
                        int mensu = 0;
                        do
                        {
                            n++;

                            req = (HttpWebRequest)WebRequest.Create("http://com.nicovideo.jp/member/" + k_comban + "?page=" + n.ToString() + "&order=a");
                            req.CookieContainer = m_cc;//取得済みのクッキーコンテナ

                            using (StreamReader srr = new StreamReader(req.GetResponse().GetResponseStream(), Encoding.UTF8))
                            {
                                string sss = srr.ReadToEnd();
                                mcc = new Regex(menidmach + @"\d+", RegexOptions.Singleline).Matches(sss);

                                foreach (Match m in mcc)
                                {
                                    mensu++;
                                    listidmentu.Add(m.Value.Replace(menidmach, ""));
                                    listnamementu.Add(new Regex(mennamemach1 + m.Value.Replace(menidmach, "") + mennamemach2 + @".*?" + mennamemach3).Match(sss).Value.Replace(mennamemach1, "").Replace(m.Value.Replace(menidmach, ""), "").Replace(mennamemach2, "").Replace(mennamemach3, ""));
                                    Invoke(new dldl(delegate
                                    {
                                        textBoxhelp.Text = "ユーザ情報現在" + mensu.ToString() + "名取得";
                                        this.Refresh();
                                    }));
                                }
                            }
                        }
                        while (mcc.Count != 0);

                        //退会メンバー確認
                        int kyu = 0;
                        int sin = 0;
                        while (kyu < listid_kyu_id.Count && kyu < listidmentu.Count)
                        {
                            if (listid_kyu_id[kyu] == listidmentu[sin])
                            {
                                kyu++;
                                sin++;

                                Invoke(new dldl(delegate
                                {
                                    textBoxhelp.Text = "退会" + kyu.ToString() + "名確認";
                                    this.Refresh();
                                }));
                            }
                            else
                            {
                                Invoke(new dldl(delegate
                                {
                                    dataGridViewtai.Rows.Add(listid_kyu_id[kyu], listid_kyu_name[kyu]);
                                    this.Refresh();
                                }));
                                kyu++;
                            }
                        }

                        //入会メンバー確認
                        while (sin < listidmentu.Count)
                        {
                            Invoke(new dldl(delegate
                            {
                                dataGridViewnyu.Rows.Add(listidmentu[sin], listnamementu[sin]);
                                textBoxhelp.Text = "入会" + sin.ToString() + "名確認";
                                this.Refresh();
                            }));
                            sin++;
                        }

                        //新規メンバー保存
                        using (StreamWriter sw = new StreamWriter(Properties.Settings.Default.hozonbasyo + "\\" + k_comban + ".txt", false, Encoding.UTF8))
                        {
                            for (int i = 0; i < listidmentu.Count; i++)
                            {
                                sw.WriteLine(listidmentu[i] + "\t" + listnamementu[i]);
                            }
                        }

                        Invoke(new dldl(delegate
                        {
                            string now = DateTime.Now.ToString();
                            int zougen = mensu - int.Parse((string)(dataGridViewcom[2, dataGridViewcom.SelectedRows[0].Index].Value));
                            string zougest = "";
                            if (zougen == 0)
                            {
                                zougest = "±" + zougen.ToString();
                            }
                            else if (zougen > 0)
                            {
                                zougest = "+" + zougen.ToString();
                            }
                            else
                            {
                                zougest = zougen.ToString();
                            }
                            textBoxhelp.Text = String.Format("{0} から {1}までの間に\r\n{2}名入会:{3}名退会:増減{4}名 合計{5}名→{6}名", (string)dataGridViewcom[3, dataGridViewcom.SelectedRows[0].Index].Value, now, dataGridViewnyu.Rows.Count.ToString(), dataGridViewtai.Rows.Count.ToString(), zougest, (string)(dataGridViewcom[2, dataGridViewcom.SelectedRows[0].Index].Value), mensu.ToString());
                            dataGridViewcom[1, dataGridViewcom.SelectedRows[0].Index].Value = commei;
                            dataGridViewcom[2, dataGridViewcom.SelectedRows[0].Index].Value = mensu.ToString();
                            dataGridViewcom[3, dataGridViewcom.SelectedRows[0].Index].Value = now;

                            using (StreamWriter sw = new StreamWriter(Properties.Settings.Default.hozonbasyo + "\\comname.txt", false, Encoding.UTF8))
                            {
                                for (int i = 0; i < dataGridViewcom.Rows.Count; i++)
                                {
                                    sw.WriteLine((string)dataGridViewcom[0, i].Value + "\t" + (string)dataGridViewcom[1, i].Value + "\t" + (string)dataGridViewcom[2, i].Value + "\t" + (string)dataGridViewcom[3, i].Value);
                                }
                            }
                        }));                        
                    }
                    else
                    {
                        MessageBox.Show("コミュニティは存在しないか、削除された可能性があります。");
                    }
                }
                else
                {
                    MessageBox.Show("先にコミュニティに入会して下さい。");
                }
            }

            Invoke(new dldl(delegate
            {
                button1.Enabled = true;
                comboBox1.Enabled = true;
                textBoxurl.Enabled = true;
                button3.Enabled = true;
                button2.Enabled = true;
                dataGridViewcom.Enabled = true;
            }));
        }


        private bool comchoufukukakunin(string comban)
        {
            for (int i = 0; i < dataGridViewcom.Rows.Count; i++)
            {
                if ((string)dataGridViewcom[0, i].Value == comban)
                {
                    return false;
                }
            }

            return true;
        }

        //保存場所設定
        private void button2_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                labelpath.Text = folderBrowserDialog1.SelectedPath;
                Properties.Settings.Default.hozonbasyo = labelpath.Text;
                Properties.Settings.Default.Save();

                dataGridViewcom.Rows.Clear();

                string line = "";
                try
                {
                    using (StreamReader sr = new StreamReader(Properties.Settings.Default.hozonbasyo + "\\comname.txt", Encoding.GetEncoding("UTF-8")))
                    {
                        while ((line = sr.ReadLine()) != null)
                        {
                            string[] ss = line.Split('\t');
                            dataGridViewcom.Rows.Add(ss[0], ss[1], ss[2], ss[3]);
                        }
                    }
                }
                catch { };

                if (ck == null)
                {

                }
                else
                {
                    if (dataGridViewcom.Rows.Count > 0)
                    {
                        button1.Enabled = true;
                        dataGridViewcom.Enabled = true;
                        textBoxhelp.Text = "コミュニティを表から選択し管理開始を押してください。";
                    }
                    else
                    {
                        button1.Enabled = false;
                        dataGridViewcom.Enabled = false;
                        textBoxhelp.Text = "コミュニティページにURLを入力しコミュ追加ボタンを押して下さい。";
                    }
                }
            }
        }

        //リンク
        private void dataGridViewcom_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;
            if (e.ColumnIndex == 0 && e.RowIndex > -1)
            {
                Process.Start("http://com.nicovideo.jp/community/" + (string)dgv[e.ColumnIndex, e.RowIndex].Value);
            }
        }

        private void dataGridViewnyu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;
            if (e.ColumnIndex == 0 && e.RowIndex > -1)
            {
                Process.Start("http://www.nicovideo.jp/user/" + (string)dgv[e.ColumnIndex, e.RowIndex].Value);
            }
        }

        private void dataGridViewtai_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;
            if (e.ColumnIndex == 0 && e.RowIndex > -1)
            {
                Process.Start("http://www.nicovideo.jp/user/" + (string)dgv[e.ColumnIndex, e.RowIndex].Value);
            }
        }

        //右クリック
        private void dataGridViewcom_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (e.RowIndex > -1)
                {
                    dataGridViewcom.Rows[e.RowIndex].Selected = true;
                }
            }
        }

        private void contextMenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem.Text == "管理開始")
            {
                kannrikaisi();
            }
            else if (e.ClickedItem.Text == "削除")
            {
                if (dataGridViewcom.SelectedRows.Count == 1 && dataGridViewcom.SelectedRows[0].Index > -1)
                {
                    int selectrow = dataGridViewcom.SelectedRows[0].Index;
                    string comnum = (string)dataGridViewcom[0, selectrow].Value;

                    File.Delete(Properties.Settings.Default.hozonbasyo + "\\" + comnum + ".txt");
                    dataGridViewcom.Rows.RemoveAt(selectrow);

                    using (StreamWriter sw = new StreamWriter(Properties.Settings.Default.hozonbasyo + "\\comname.txt", false, Encoding.UTF8))
                    {
                        for (int i = 0; i < dataGridViewcom.Rows.Count; i++)
                        {
                            sw.WriteLine((string)dataGridViewcom[0, i].Value + "\t" + (string)dataGridViewcom[1, i].Value + "\t" + (string)dataGridViewcom[2, i].Value + "\t" + (string)dataGridViewcom[3, i].Value);
                        }
                    }

                    if (dataGridViewcom.Rows.Count == 0)
                    {
                        textBoxhelp.Text = "コミュニティページにURLを入力しコミュ追加ボタンを押して下さい。";
                    }

                }
            }
        }

        //クッキーゲット
        private void Form1_Shown(object sender, EventArgs e)
        {
            //ブラウザ設定
            comboBox1.Items.AddRange(CookieGetter.CreateInstances(true));
            if (Properties.Settings.Default.burauza > -1 && Properties.Settings.Default.burauza < comboBox1.Items.Count)
            {
                comboBox1.SelectedIndex = Properties.Settings.Default.burauza;
            }
        } 

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.burauza = comboBox1.SelectedIndex;
            Properties.Settings.Default.Save();

            if (comboBox1.SelectedIndex > -1)
            {
                ckget();
            }
        }

        private void ckget()
        {
            if (comboBox1.SelectedIndex > -1)
            {
                ck = CookieGetter.CreateInstances(true)[comboBox1.SelectedIndex].GetCookie(new Uri("http://www.nicovideo.jp/"), "user_session");

                if (ck == null)
                {
                    textBoxhelp.Text = "ブラウザを選択して下さい。";
                    textBoxurl.Enabled = false;
                    button1.Enabled = false;
                    button3.Enabled = false;
                    MessageBox.Show("クッキーを取得できませんでした。\r\nブラウザでログインし直すか、ブラウザを再起動したり\r\n時間を置くなどして再度お試し下さい。");
                }
                else
                {
                    m_cc = new CookieContainer();
                    m_cc.Add(ck);

                    textBoxurl.Enabled = true;
                    button3.Enabled = true;

                    if (dataGridViewcom.Rows.Count > 0)
                    {
                        button1.Enabled = true;
                        dataGridViewcom.Enabled = true;
                        textBoxhelp.Text = "コミュニティを表から選択し管理開始を押してください。";
                    }
                    else
                    {
                        button1.Enabled = false;
                        dataGridViewcom.Enabled = false;
                        textBoxhelp.Text = "コミュニティページにURLを入力しコミュ追加ボタンを押して下さい。";
                    }
                }
            }
        }

        
      
    }
}
