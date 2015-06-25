using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SMMhelp
{
    public partial class InviteForm : Form
    {
        VKapi vk;
        OpenFileDialog OFD;
        public InviteForm()
        {
            InitializeComponent();
            OFD = new OpenFileDialog();
            if (OFD.ShowDialog() != DialogResult.OK)
            {
                return;
            }
            vk = new VKapi();
        }

        private void InviteForm_Shown(object sender, EventArgs e)
        {
            Thread thread = new Thread(new System.Threading.ThreadStart(delegate { Fun(); }));
            thread.Start();
        }

        private void Fun()
        {
            int cnt = 12;
            int[] count = { 3, 3, 2, 2 };
            string[] groups = { "10682771", "65327228", "59375874", "2001458" };
            StreamReader akk = new StreamReader(OFD.FileName);
            string lines;
            while (!akk.EndOfStream)
            {
                if(cnt==0)
                {
                    break;
                }
                akklabel.Invoke(new MethodInvoker(delegate { akklabel.Text = (Int32.Parse(akklabel.Text) + 1).ToString(); }));
                lines = akk.ReadLine();
                string login = lines.Substring(0, lines.IndexOf(':'));
                string password = lines.Substring(lines.IndexOf(':') + 1);
                listBox.Invoke(new MethodInvoker(delegate { listBox.Items.Insert(0, "Логинемся в vk.com Логин: " + login + " Пароль:" + password); }));
                string token = vk.Authorization(login, password);
                listBox.Invoke(new MethodInvoker(delegate { listBox.Items.Insert(0, "Получаем Token: " + token); }));

                Random rand = new Random(DateTime.Now.Millisecond);

                int i = 0;
                do
                {
                    i = rand.Next(0, 4);
                    //MessageBox.Show(i.ToString());
                } while ((count[i] < 0) == true);

                cnt--;
                count[i]--;
                string list_friends = vk.FriendsGet(token);
                listBox.Invoke(new MethodInvoker(delegate { listBox.Items.Insert(0, "Получаем список друзей"); }));
                listBox.Invoke(new MethodInvoker(delegate { listBox.Items.Insert(0, "Начинаем приглашать"); }));

                foreach(string friend in list_friends.Split('/'))
                {
                    bool flag = false;
                    Directory.CreateDirectory("inviting\\" + groups[i]);

                    if (File.Exists("inviting\\" + groups[i] + "\\all.txt") == false)
                    {
                        File.Create("inviting\\" + groups[i] + "\\all.txt").Close();
                    }
                    StreamReader sr = new StreamReader("inviting\\" + groups[i] + "\\all.txt");

                    while (!sr.EndOfStream)
                    {
                        if(friend.Equals(sr.ReadLine()) == true)
                        {
                            flag = true;
                            break;
                        }
                    }
                    sr.Close();
                    if(flag == true)
                    {
                        loglabel.Invoke(new MethodInvoker(delegate { loglabel.Text = (Int32.Parse(loglabel.Text) + 1).ToString(); }));
                        continue;
                    }
                    try
                    {
                        int j = vk.GroupsInvite(groups[i], friend, token);
                    
                        requestlabel.Invoke(new MethodInvoker(delegate { requestlabel.Text = (Int32.Parse(requestlabel.Text) + 1).ToString(); }));
                        if(j == 0)
                        {
                            StreamWriter writer = File.AppendText("inviting\\" + groups[i] + "\\all.txt");
                            writer.WriteLine(friend, Encoding.UTF8);
                            writer.Flush();
                            writer.Close();
                            writer = File.AppendText("inviting\\" + groups[i] + "\\good.txt");
                            writer.WriteLine(friend, Encoding.UTF8);
                            writer.Flush();
                            writer.Close();
                            invitelabel.Invoke(new MethodInvoker(delegate { invitelabel.Text = (Int32.Parse(invitelabel.Text) + 1).ToString(); }));
                        }
                        if (j == -1)
                        {
                            break; // лимит
                        }
                        if (j == -2)
                        {
                            StreamWriter writer = File.AppendText("inviting\\" + groups[i] + "\\all.txt");
                            writer.WriteLine(friend, Encoding.UTF8);
                            writer.Flush();
                            writer.Close();
                            writer = File.AppendText("inviting\\" + groups[i] + "\\bad.txt");
                            writer.WriteLine(friend, Encoding.UTF8);
                            writer.Flush();
                            writer.Close();
                        }
                    }
                    catch (WebException e)
                    {
                        MessageBox.Show("Проблемы с антикапчей");
                        return;
                    }
                    int timesleep = rand.Next(2000, 10000);
                    if(listBox.Items[0].ToString().Contains("Задержка:"))
                    {
                        listBox.Invoke(new MethodInvoker(delegate { listBox.Items.RemoveAt(0); }));
                    }
                    listBox.Invoke(new MethodInvoker(delegate { listBox.Items.Insert(0, "Задержка: " + timesleep / 1000 + " сек."); }));
                    Thread.Sleep(timesleep);
                }
            }
            akk.Close();
            MessageBox.Show("Конец");
        }
    }
}
