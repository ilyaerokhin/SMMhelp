using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace SMMhelp
{
    class VKapi
    {
        private int client_id = 3697615;
        private string client_secret = "AlVXZFMUqyrnABp8ncuU";
        public string Authorization(string login, string password)
        {
            string resultPage = null;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://oauth.vk.com/token?grant_type=password&client_id=" + this.client_id + "&client_secret=" + this.client_secret + "&username=" + login + "&password=" + password);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            using (StreamReader sr = new StreamReader(response.GetResponseStream(), Encoding.UTF8, true))
            {
                resultPage = sr.ReadToEnd();
                sr.Close();
            }
            if(resultPage.Contains("access_token"))
            {
                return resultPage.Split(new char[] { '"' })[3];
            }
            else
            {
                return resultPage;
            }
        }
        public string WallGet(string owner_id, string count)
        {
            string resultPage = null;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://api.vkontakte.ru/method/wall.get.xml?owner_id=-" + owner_id + "&count=" + count+1);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            using (StreamReader sr = new StreamReader(response.GetResponseStream(), Encoding.UTF8, true))
            {
                resultPage = sr.ReadToEnd();
                sr.Close();
            }

            string result = "";

            XDocument xml = XDocument.Load(new StringReader(resultPage));
            bool flag = true;

            foreach (XElement element in xml.Root.Elements("post"))
            {
                if (flag == true)
                {
                    flag = false;
                    continue;
                }
                result = result + string.Format(element.Element("id").Value) + "/";
            }

            return result; 
        }
        public string WallRepost(string from_id, string post_id, string token)
        {
            string resultPage = null;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://api.vkontakte.ru/method/wall.repost.xml?object=wall-" + from_id + "_" + post_id + "&access_token=" + token);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            using (StreamReader sr = new StreamReader(response.GetResponseStream(), Encoding.UTF8, true))
            {
                resultPage = sr.ReadToEnd();
                sr.Close();
            }

            return resultPage;
        }
    }
}
