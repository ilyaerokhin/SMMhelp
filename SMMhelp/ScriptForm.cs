using SimpleAntiGate;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SMMhelp
{
    public partial class ScriptForm : Form
    {
        Thread thread;
        Thread thread2;
        bool flag;
        VKapi vk;
        OpenFileDialog OFD;
        List<string> posts;
        int min = 100;
        int max = 1500;
        int postmin = 100;
        int postmax = 5000;
        public ScriptForm()
        {
            InitializeComponent();
            OFD = new OpenFileDialog();
            vk = new VKapi();
        }

        private void ScriptForm_Shown(object sender, EventArgs e)
        {
            thread = new Thread(new System.Threading.ThreadStart(delegate { Fun(); }));
            thread2 = new Thread(new System.Threading.ThreadStart(delegate { AntiGateBalance(); }));

            if (OFD.ShowDialog() != DialogResult.OK)
            {
                this.Close();
                return;
            }

            thread.Start();
            thread2.Start();

            flag = true;
        }

        private void AntiGateBalance()
        {
            antilabel.Invoke(new MethodInvoker(delegate { antilabel.Text = AntiGate.GetBalance() + "$"; }));
            Thread.Sleep(60000);
        }

        private void Fun()
        {
            int m = -1;
            StreamReader sr = new StreamReader("group_list.txt");
            string line;
            posts = new List<string>();
            int cnt = 16;
            int[] count = { 4, 4, 4, 4 };
            string[] groups = { "10682771", "65327228", "59375874", "2001458" };
            DataTable dt = new DataTable();

            while (!sr.EndOfStream)
            {
                line = sr.ReadLine();
                string group_id = line.Split(':')[0];
                string num_of_posts = line.Split(':')[1];

                string rez = vk.WallGet(group_id, Convert.ToInt32(num_of_posts));

                foreach (string n in rez.Split('/'))
                {
                    //MessageBox.Show(n);
                    posts.Add(group_id + ":" + n);
                }

                listBox.Invoke(new MethodInvoker(delegate { listBox.Items.Insert(0, "Загружаем из vk.com/club" + group_id + " " + num_of_posts + " постов"); }));

                grouplabel.Invoke(new MethodInvoker(delegate { grouplabel.Text = (Int32.Parse(grouplabel.Text) + 1).ToString(); }));
                postlabel.Invoke(new MethodInvoker(delegate { postlabel.Text = (Int32.Parse(postlabel.Text) + Int32.Parse(num_of_posts)).ToString(); }));
            }
            sr.Close();

            StreamReader akk = new StreamReader(OFD.FileName);
            string lines;

            //dataGridView1.Invoke(new MethodInvoker(delegate { dataGridView1.Columns.Add("Аккаунты", "Аккаунты"); }));
            //dataGridView1.Invoke(new MethodInvoker(delegate { dataGridView1.Columns.Add("Друзья", "Друзья"); }));

            while (!akk.EndOfStream)
            {
                dataGridView1.Invoke(new MethodInvoker(delegate { dataGridView1.Rows.Add(); }));
                m++;
                akklabel.Invoke(new MethodInvoker(delegate { akklabel.Text = (Int32.Parse(akklabel.Text) + 1).ToString(); }));
                lines = akk.ReadLine();
                string login = lines.Substring(0, lines.IndexOf(':'));
                string password = lines.Substring(lines.IndexOf(':') + 1);

                dataGridView1.Invoke(new MethodInvoker(delegate {dataGridView1.Rows[m].Cells[0].Value = login; }));

                listBox.Invoke(new MethodInvoker(delegate { listBox.Items.Insert(0, "Логинемся в vk.com Логин: " + login + " Пароль:" + password); }));
                string token = vk.Authorization(login, password);
                if (token.Contains("Заблокирован") == true)
                {
                    dataGridView1.Invoke(new MethodInvoker(delegate { dataGridView1.Rows[m].Cells[1].Value = "ban"; }));
                    banlabel.Invoke(new MethodInvoker(delegate { banlabel.Text = (Int32.Parse(banlabel.Text) + 1).ToString(); }));
                    listBox.Invoke(new MethodInvoker(delegate { listBox.Items.Insert(0, "Аккаунт заблокирован"); }));
                    continue;
                }
                listBox.Invoke(new MethodInvoker(delegate { listBox.Items.Insert(0, "Получаем Token: " + token); }));

                int fr = vk.UsersGet(token);
                dataGridView1.Invoke(new MethodInvoker(delegate {dataGridView1.Rows[m].Cells[1].Value = fr; }));
   
                allfriendslabel.Invoke(new MethodInvoker(delegate { allfriendslabel.Text = (Int32.Parse(allfriendslabel.Text) + fr).ToString(); }));

                Random rand = new Random(DateTime.Now.Millisecond);

                // РЕПОСТЫ

                int counts = rand.Next(1, 10);
                List<int> list_posts = new List<int>();

                for (int i = 0; i < counts; i++)
                {
                    int Flag = 1;
                    do
                    {
                        int n = rand.Next(posts.Count);

                        if (list_posts.Contains(n) == false)
                        {
                            list_posts.Add(n);
                            int timesleep = rand.Next(postmin, postmax);
                            vk.WallRepost(posts[n].Split(':')[0], posts[n].Split(':')[1], token);
                            repostlabel.Invoke(new MethodInvoker(delegate { repostlabel.Text = (Int32.Parse(repostlabel.Text) + 1).ToString(); }));
                            listBox.Invoke(new MethodInvoker(delegate { listBox.Items.Insert(0, "vk.com/wall-" + posts[n].Split(':')[0] + "_" + posts[n].Split(':')[1]); }));
                            listBox.Invoke(new MethodInvoker(delegate { listBox.Items.Insert(0, "Задержка: " + timesleep / 1000 + " сек."); }));
                            Thread.Sleep(timesleep);
                            Flag = 0;
                        }
                    }
                    while (Flag != 0);

                }

                ///////////////////////////////////

                // В ДРУЗЬЯ

                int age = rand.Next(14, 35);
                string people = vk.UsersSearch(0, age, token);
                listBox.Invoke(new MethodInvoker(delegate { listBox.Items.Insert(0, "Получаем людей с возрастом = " + age.ToString()); }));
                listBox.Invoke(new MethodInvoker(delegate { listBox.Items.Insert(0, "Начинаем приглашать"); }));

                foreach (string friend in people.Split('/'))
                {
                    bool flag = false;
                    if (File.Exists("allfriends.txt") == false)
                    {
                        File.Create("allfriends.txt").Close();
                    }
                    StreamReader lr = new StreamReader("allfriends.txt");

                    while (!lr.EndOfStream)
                    {
                        if (friend.Equals(lr.ReadLine()) == true)
                        {
                            flag = true;
                            break;
                        }
                    }
                    lr.Close();
                    if (flag == true)
                    {
                        logFlabel.Invoke(new MethodInvoker(delegate { logFlabel.Text = (Int32.Parse(logFlabel.Text) + 1).ToString(); }));
                        continue;
                    }

                    try
                    {
                        int j = vk.FriendsAdd(friend, token);
                        requestFlabel.Invoke(new MethodInvoker(delegate { requestFlabel.Text = (Int32.Parse(requestFlabel.Text) + 1).ToString(); }));

                        if (j == 0)
                        {
                            StreamWriter writer = File.AppendText("allfriends.txt");
                            writer.WriteLine(friend, Encoding.UTF8);
                            writer.Flush();
                            writer.Close();
                            inviteFlabel.Invoke(new MethodInvoker(delegate { inviteFlabel.Text = (Int32.Parse(inviteFlabel.Text) + 1).ToString(); }));
                        }
                        if (j == -1)
                        {
                            break; // лимит
                        }
                        if (j < -1)
                        {
                            StreamWriter writer = File.AppendText("allfriends.txt");
                            writer.WriteLine(friend, Encoding.UTF8);
                            writer.Flush();
                            writer.Close();
                        }
                    }
                    catch (WebException e)
                    {
                        //AutoClosingMessageBox.Show("Проблемы с антикапчей", "", 2000);
                    }
                    int timesleep = rand.Next(min, max);
                    if (listBox.Items[0].ToString().Contains("Задержка:"))
                    {
                        listBox.Invoke(new MethodInvoker(delegate { listBox.Items.RemoveAt(0); }));
                    }
                    listBox.Invoke(new MethodInvoker(delegate { listBox.Items.Insert(0, "Задержка: " + timesleep / 1000 + " сек."); }));
                    Thread.Sleep(timesleep);
                }

                //////////////////////////////////

                // В СООБЩЕСТВА

                int g = 0;
                do
                {
                    g = rand.Next(0, 4);
                    //MessageBox.Show(i.ToString());
                } while ((count[g] < 0) == true);

                cnt--;
                count[g]--;
                string list_friends = vk.FriendsGet(token);
                listBox.Invoke(new MethodInvoker(delegate { listBox.Items.Insert(0, "Получаем список друзей"); }));
                listBox.Invoke(new MethodInvoker(delegate { listBox.Items.Insert(0, "Начинаем приглашать"); }));

                foreach (string friend in list_friends.Split('/'))
                {
                    bool flag = false;
                    Directory.CreateDirectory("inviting\\" + groups[g]);

                    if (File.Exists("inviting\\" + groups[g] + "\\all.txt") == false)
                    {
                        File.Create("inviting\\" + groups[g] + "\\all.txt").Close();
                    }
                    StreamReader lr = new StreamReader("inviting\\" + groups[g] + "\\all.txt");

                    while (!lr.EndOfStream)
                    {
                        if (friend.Equals(lr.ReadLine()) == true)
                        {
                            flag = true;
                            break;
                        }
                    }
                    lr.Close();
                    if (flag == true)
                    {
                        logGlabel.Invoke(new MethodInvoker(delegate { logGlabel.Text = (Int32.Parse(logGlabel.Text) + 1).ToString(); }));
                        continue;
                    }
                    try
                    {
                        int j = vk.GroupsInvite(groups[g], friend, token);

                        requestGlabel.Invoke(new MethodInvoker(delegate { requestGlabel.Text = (Int32.Parse(requestGlabel.Text) + 1).ToString(); }));
                        if (j == 0)
                        {
                            StreamWriter writer = File.AppendText("inviting\\" + groups[g] + "\\all.txt");
                            writer.WriteLine(friend, Encoding.UTF8);
                            writer.Flush();
                            writer.Close();
                            writer = File.AppendText("inviting\\" + groups[g] + "\\good.txt");
                            writer.WriteLine(friend, Encoding.UTF8);
                            writer.Flush();
                            writer.Close();
                            inviteGlabel.Invoke(new MethodInvoker(delegate { inviteGlabel.Text = (Int32.Parse(inviteGlabel.Text) + 1).ToString(); }));
                        }
                        if (j == -1)
                        {
                            break; // лимит
                        }
                        if (j == -2)
                        {
                            StreamWriter writer = File.AppendText("inviting\\" + groups[g] + "\\all.txt");
                            writer.WriteLine(friend, Encoding.UTF8);
                            writer.Flush();
                            writer.Close();
                            writer = File.AppendText("inviting\\" + groups[g] + "\\bad.txt");
                            writer.WriteLine(friend, Encoding.UTF8);
                            writer.Flush();
                            writer.Close();
                        }
                    }
                    catch (WebException e)
                    {
                        //AutoClosingMessageBox.Show("Проблемы с антикапчей", "", 2000);
                    }
                    int timesleep = rand.Next(min, max);
                    if (listBox.Items[0].ToString().Contains("Задержка:"))
                    {
                        listBox.Invoke(new MethodInvoker(delegate { listBox.Items.RemoveAt(0); }));
                    }
                    listBox.Invoke(new MethodInvoker(delegate { listBox.Items.Insert(0, "Задержка: " + timesleep / 1000 + " сек."); }));
                    Thread.Sleep(timesleep);
                }

                /////////////////////////////////
            }
            if(checkBox.Checked == true)
            {
                Process.Start("shutdown", "/s /t 0");
            }
            akk.Close();
            SystemSounds.Beep.Play();
            MessageBox.Show("Конец");
        }

        private void button_Click(object sender, EventArgs e)
        {
            if(flag == true)
            {
                thread.Suspend();
                button.Text = "Старт";
                flag = false;
            }
            else
            {
                thread.Resume();
                button.Text = "Пауза";
                flag = true;
            }
        }

        private void ScriptForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            //MessageBox.Show(thread.ThreadState.ToString());
            if (!thread.ThreadState.ToString().Contains("Suspended"))
            {
                thread.Abort();
            }

            if (!thread2.ThreadState.ToString().Contains("Suspended"))
            {
                thread2.Abort();
            }
        }
    }
}
