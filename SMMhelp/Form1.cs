using SimpleAntiGate;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
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
            //MessageBox.Show(vk.Authorization("79056613147", "НаткаСпирина"));
            //MessageBox.Show(vk.WallGet("nn.online",10));
            //MessageBox.Show(vk.WallRepost("10682771", "149054", vk.Authorization("79056613147", "НаткаСпирина")));
            //MessageBox.Show(vk.FriendsGet(vk.Authorization("79056613147", "НаткаСпирина")));
            //string token = vk.Authorization("79063685218", "оплпГГНАк6764");

            //for (; ; )
            //{
            //    string rez = vk.GroupsInvite("89830206", vk.FriendsGet(token).Split('/')[0], token);
            //    MessageBox.Show(rez);
            //    if (rez.Contains("-1")==true)
            //        break;
            //}
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
    }
}
