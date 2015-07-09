using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
    public partial class AddFriendsForm : Form
    {
        VKapi vk;
        OpenFileDialog OFD;
        int min = 1000;
        int max = 5000;
        public AddFriendsForm()
        {
            InitializeComponent();
            OFD = new OpenFileDialog();
            if (OFD.ShowDialog() != DialogResult.OK)
            {
                return;
            }
            vk = new VKapi();
        }

        private void AddFriendsForm_Shown(object sender, EventArgs e)
        {
            Thread thread = new Thread(new System.Threading.ThreadStart(delegate { Fun(); }));
            thread.Start();
        }

        private void Fun()
        {
            StreamReader akk = new StreamReader(OFD.FileName);
            string lines;

            while (!akk.EndOfStream)
            {
                akklabel.Invoke(new MethodInvoker(delegate { akklabel.Text = (Int32.Parse(akklabel.Text) + 1).ToString(); }));
                lines = akk.ReadLine();
                string login = lines.Substring(0, lines.IndexOf(':'));
                string password = lines.Substring(lines.IndexOf(':') + 1);
                listBox.Invoke(new MethodInvoker(delegate { listBox.Items.Insert(0, "Логинемся в vk.com Логин: " + login + " Пароль:" + password); }));
                string token = vk.Authorization(login, password);
                if (token.Contains("Заблокирован") == true)
                {
                    listBox.Invoke(new MethodInvoker(delegate { listBox.Items.Insert(0, "Аккаунт заблокирован"); }));
                    continue;
                }
                listBox.Invoke(new MethodInvoker(delegate { listBox.Items.Insert(0, "Получаем Token: " + token); }));

                Random rand = new Random(DateTime.Now.Millisecond);

                string people = vk.UsersSearch(0,rand.Next(14,35), token);
                listBox.Invoke(new MethodInvoker(delegate { listBox.Items.Insert(0, "Получаем людей"); }));
                listBox.Invoke(new MethodInvoker(delegate { listBox.Items.Insert(0, "Начинаем приглашать"); }));

                foreach(string friend in people.Split('/'))
                {
                    bool flag = false;
                    if (File.Exists("allfriends.txt") == false)
                    {
                        File.Create("allfriends.txt").Close();
                    }
                    StreamReader sr = new StreamReader("allfriends.txt");

                    while (!sr.EndOfStream)
                    {
                        if (friend.Equals(sr.ReadLine()) == true)
                        {
                            flag = true;
                            break;
                        }
                    }
                    sr.Close();
                    if (flag == true)
                    {
                        loglabel.Invoke(new MethodInvoker(delegate { loglabel.Text = (Int32.Parse(loglabel.Text) + 1).ToString(); }));
                        continue;
                    }

                    try
                    {
                        int j = vk.FriendsAdd(friend, token);
                        requestlabel.Invoke(new MethodInvoker(delegate { requestlabel.Text = (Int32.Parse(requestlabel.Text) + 1).ToString(); }));

                        if (j == 0)
                        {
                            StreamWriter writer = File.AppendText("allfriends.txt");
                            writer.WriteLine(friend, Encoding.UTF8);
                            writer.Flush();
                            writer.Close();
                            invitelabel.Invoke(new MethodInvoker(delegate { invitelabel.Text = (Int32.Parse(invitelabel.Text) + 1).ToString(); }));
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
                        AutoClosingMessageBox.Show("Проблемы с антикапчей", "", 2000);
                    }
                    int timesleep = rand.Next(min, max);
                    if (listBox.Items[0].ToString().Contains("Задержка:"))
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

        private void AddFriendsForm_FormClosed(object sender, FormClosedEventArgs e)
        {

        }
    }
}
