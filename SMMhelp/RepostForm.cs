using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SMMhelp
{
    public partial class RepostForm : Form
    {
        List<string> posts;
        VKapi vk;
        OpenFileDialog OFD;

        public RepostForm()
        {
            InitializeComponent();
            OFD = new OpenFileDialog();
            if (OFD.ShowDialog() != DialogResult.OK)
            {
                return;
            }
            //MessageBox.Show(OFD.FileName);
        }

        private void RepostForm_Shown(object sender, EventArgs e)
        {
            Thread thread = new Thread(new System.Threading.ThreadStart(delegate { Fun(); }));
            thread.Start();
        }

        private void Fun()
        {
            StreamReader sr = new StreamReader("group_list.txt");
            string line;
            posts = new List<string>();
            vk = new VKapi();

            while (!sr.EndOfStream)
            {
                line = sr.ReadLine();
                string group_id = line.Split(':')[0];
                string num_of_posts = line.Split(':')[1];

                string rez = vk.WallGet(group_id, num_of_posts);

                foreach (string n in rez.Split('/'))
                {
                    //MessageBox.Show(n);
                    posts.Add(group_id + ":" + n);
                }

                listBox.Invoke(new MethodInvoker(delegate { listBox.Items.Insert(0, "Загружаем из vk.com/club" + group_id + " " + num_of_posts + " постов"); }));

                groupslabel.Invoke(new MethodInvoker(delegate { groupslabel.Text = (Int32.Parse(groupslabel.Text) + 1).ToString(); }));
            }
            sr.Close();

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
                listBox.Invoke(new MethodInvoker(delegate { listBox.Items.Insert(0, "Получаем Token: " + token); }));

                Random rand = new Random(DateTime.Now.Millisecond);
                int count = rand.Next(1,10);
                List<int> list_posts = new List<int>();

                //MessageBox.Show(count.ToString());
                for(int i=0; i<count; i++)
                {
                    int Flag = 1;
                    do
                    {
                        int n = rand.Next(posts.Count);

                        if (list_posts.Contains(n) == false)
                        {
                            list_posts.Add(n);
                            int timesleep = rand.Next(15000, 45000);
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

                //MessageBox.Show(login + " " + password);
            }
            akk.Close();
            MessageBox.Show("Конец\a");
        }
    }
}
