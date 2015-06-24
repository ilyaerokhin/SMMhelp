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
            vk = new VKapi();
            //MessageBox.Show(vk.Authorization("79056613147", "НаткаСпирина"));
            //MessageBox.Show(vk.WallGet("nn.online",10));
            //MessageBox.Show(vk.WallRepost("10682771", "149054", vk.Authorization("79056613147", "НаткаСпирина")));
        }

        private void repostbutton_Click(object sender, EventArgs e)
        {
            RepostForm form = new RepostForm();
            form.Show();
        }
    }
}
