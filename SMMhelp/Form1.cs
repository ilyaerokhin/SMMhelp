using SimpleAntiGate;
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
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace SMMhelp
{
    public partial class StartForm : Form
    {
        VKapi vk;
        public StartForm()
        {
            InitializeComponent();
            AntiGate.AntiGateKey = "23b239d9f768fd4d9d7cbbbed6ba763d";
            vk = new VKapi();
            antilabel.Text = AntiGate.GetBalance() + "$";
            //MessageBox.Show(AntiGate.GetBalance());
            //SystemSounds.Beep.Play();
            //SystemSounds.Hand.Play();
            //MessageBox.Show(vk.Authorization("79056613147", "НаткаСпирина"));
            //MessageBox.Show(vk.WallGet("10682771", 10));
            //MessageBox.Show(vk.WallRepost("10682771", "149054", vk.Authorization("79056613147", "НаткаСпирина")));
            //MessageBox.Show(vk.FriendsGet(vk.Authorization("79056613147", "НаткаСпирина")));
            //string token = vk.Authorization("sparta24@rambler.ru", "НаткаСпирина");
            //MessageBox.Show(vk.WallPost("44021730",vk.WallGet("44021730","suggests","1",token).Split('/')[0],token));
            //MessageBox.Show(vk.WallGet("44021730", "suggests", "1", token));

            //foreach (string friend in vk.UsersSearch(0,token).Split('/'))
            //{
            //    int rez = vk.FriendsAdd(friend, token);
            //    MessageBox.Show(rez.ToString());
            //}
            //MessageBox.Show(vk.UsersSearch(0,14,token));

        }

        private void repostbutton_Click(object sender, EventArgs e)
        {
            RepostForm form = new RepostForm();
            form.Show();
        }

        private void invitingbutton_Click(object sender, EventArgs e)
        {
            InviteForm form = new InviteForm();
            form.Show();

        }

        private void friendsbutton_Click(object sender, EventArgs e)
        {
            AddFriendsForm form = new AddFriendsForm();
            form.Show();
        }

        private void scriptbutton_Click(object sender, EventArgs e)
        {
            ScriptForm form = new ScriptForm();
            form.Show();
        }

        private void antilabel_Click(object sender, EventArgs e)
        {
            antilabel.Text = AntiGate.GetBalance() + "$";
        }

    }
}
