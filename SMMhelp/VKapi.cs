using SimpleAntiGate;
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
            try
            {
                string resultPage = null;
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://oauth.vk.com/token?grant_type=password&client_id=" + this.client_id + "&client_secret=" + this.client_secret + "&username=" + login + "&password=" + password);
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                using (StreamReader sr = new StreamReader(response.GetResponseStream(), Encoding.UTF8, true))
                {
                    resultPage = sr.ReadToEnd();
                    sr.Close();
                }
                if (resultPage.Contains("access_token"))
                {
                    return resultPage.Split(new char[] { '"' })[3];
                }
                else
                {
                    return resultPage;
                }
            }
            catch (System.Net.WebException e)
            {
                return "Заблокирован";
            }
        }
        public string WallGet(string owner_id, int count)
        {
            string resultPage = null;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://api.vkontakte.ru/method/wall.get.xml?owner_id=-" + owner_id + "&count=" + (count+1).ToString());
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

            return result.Substring(0, result.Length - 1);
        }

        public string WallGet(string owner_id, string filter, string count, string token)
        {
            string resultPage = null;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://api.vkontakte.ru/method/wall.get.xml?owner_id=-" + owner_id + "&count=" + count + "&filter=" + filter + "&access_token=" + token);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            using (StreamReader sr = new StreamReader(response.GetResponseStream(), Encoding.UTF8, true))
            {
                resultPage = sr.ReadToEnd();
                sr.Close();
            }

            string result = "";

            XDocument xml = XDocument.Load(new StringReader(resultPage));

            foreach (XElement element in xml.Root.Elements("post"))
            {
                result = result + string.Format(element.Element("id").Value) + "/";
            }
            return result.Substring(0, result.Length - 1);
        }
        public string WallPost(string owner_id, string post_id, string token)
        {
            string resultPage = null;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://api.vkontakte.ru/method/wall.post.xml?owner_id=-" + owner_id + "&post_id=" + post_id + "&access_token=" + token);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            using (StreamReader sr = new StreamReader(response.GetResponseStream(), Encoding.UTF8, true))
            {
                resultPage = sr.ReadToEnd();
                sr.Close();
            }

            return resultPage;
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

        public string FriendsGet(string token)
        {
            string resultPage = null;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://api.vkontakte.ru/method/friends.getOnline.xml?order=random&access_token=" + token);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            using (StreamReader sr = new StreamReader(response.GetResponseStream(), Encoding.UTF8, true))
            {
                resultPage = sr.ReadToEnd();
                sr.Close();
            }

            XDocument xml = XDocument.Load(new StringReader(resultPage));
            string result ="";

            foreach (XElement element in xml.Root.Elements("uid"))
            {
                result = result + string.Format(element.Value) + "/";
            }

            if(result.Length==0)
            {
                return "";
            }

            return result.Substring(0,result.Length-1); 
        }

        public int GroupsInvite(string group_id, string user_id, string token)
        {
            string resultPage = null;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://api.vkontakte.ru/method/groups.invite.xml?group_id=" + group_id + "&user_id=" + user_id + "&access_token=" + token);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            using (StreamReader sr = new StreamReader(response.GetResponseStream(), Encoding.UTF8, true))
            {
                resultPage = sr.ReadToEnd();
                sr.Close();
            }

            if (resultPage.Contains("<error_code>14") == true)
            {
                XDocument xml = XDocument.Load(new StringReader(resultPage));
                XElement element = xml.Root.Element("captcha_img");
                string captcha_key = AntiGate.Recognize(string.Format(element.Value));
                string captcha_sid = string.Format(xml.Root.Element("captcha_sid").Value);

                resultPage = null;
                request = (HttpWebRequest)WebRequest.Create("https://api.vkontakte.ru/method/groups.invite.xml?group_id=" + group_id + "&user_id=" + user_id + "&access_token=" + token + "&captcha_sid=" + captcha_sid + "&captcha_key=" + captcha_key);
                response = (HttpWebResponse)request.GetResponse();
                using (StreamReader sr = new StreamReader(response.GetResponseStream(), Encoding.UTF8, true))
                {
                    resultPage = sr.ReadToEnd();
                    sr.Close();
                }
                //return AntiGate.Recognize(string.Format(element.Value));
            }

            if(resultPage.Contains("<response>1")==true)
            {
                return 0; // приглашение выслано
            }
            else
            {
                if(resultPage.Contains("<error_code>103")==true)
                {
                    return -1; // лимит
                }
                if (resultPage.Contains("<error_code>15") == true)
                {
                    return -2; // пользователь ограничил или приглашение уже высылалось
                }
            }


            return -3; // другая ошибка
        }

        public string UsersSearch(int offset, int age, string token)
        {
            string resultPage = null;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://api.vkontakte.ru/method/users.search.xml?sort=1&offset=" + offset.ToString() + "&count=1000&city=95&age_from=" + age.ToString() + "&age_to=" + age.ToString() + "&online=1&has_photo=1&access_token=" + token);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            using (StreamReader sr = new StreamReader(response.GetResponseStream(), Encoding.UTF8, true))
            {
                resultPage = sr.ReadToEnd();
                sr.Close();
            }

            string result = "";

            XDocument xml = XDocument.Load(new StringReader(resultPage));
            bool flag = true;

            foreach (XElement element in xml.Root.Elements("user"))
            {
                if (flag == true)
                {
                    flag = false;
                    continue;
                }
                result = result + string.Format(element.Element("uid").Value) + "/";
            }

            return result.Substring(0, result.Length - 1);
        }

        public int UsersGet(string token)
        {
            string resultPage = null;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://api.vkontakte.ru/method/users.get.xml?fields=counters&access_token=" + token);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            using (StreamReader sr = new StreamReader(response.GetResponseStream(), Encoding.UTF8, true))
            {
                resultPage = sr.ReadToEnd();
                sr.Close();
            }

            string result = "";

            //return resultPage;

            XDocument xml = XDocument.Load(new StringReader(resultPage));

            foreach (XElement element in xml.Root.Elements("user"))
            {
                result = result + string.Format(element.Element("counters").Element("friends").Value) + "/";
            }

            return Convert.ToInt32(result.Substring(0, result.Length - 1));
        }

        public int FriendsAdd(string user_id, string token)
        {
            string resultPage = null;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://api.vkontakte.ru/method/friends.add.xml?user_id=" + user_id +"&access_token=" + token);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            using (StreamReader sr = new StreamReader(response.GetResponseStream(), Encoding.UTF8, true))
            {
                resultPage = sr.ReadToEnd();
                sr.Close();
            }

            if (resultPage.Contains("<error_code>14") == true)
            {
                XDocument xml = XDocument.Load(new StringReader(resultPage));
                XElement element = xml.Root.Element("captcha_img");
                string captcha_key = AntiGate.Recognize(string.Format(element.Value));
                string captcha_sid = string.Format(xml.Root.Element("captcha_sid").Value);

                resultPage = null;
                request = (HttpWebRequest)WebRequest.Create("https://api.vkontakte.ru/method/friends.add.xml?user_id=" + user_id +"&access_token=" + token + "&captcha_sid=" + captcha_sid + "&captcha_key=" + captcha_key);
                response = (HttpWebResponse)request.GetResponse();
                using (StreamReader sr = new StreamReader(response.GetResponseStream(), Encoding.UTF8, true))
                {
                    resultPage = sr.ReadToEnd();
                    sr.Close();
                }
                //return AntiGate.Recognize(string.Format(element.Value));
            }

            if (resultPage.Contains("<response>1") == true)
            {
                return 0; // приглашение выслано
            }
            if (resultPage.Contains("<response>4") == true)
            {
                return 0; // заявка одобрена
            }
            else
            {
                if (resultPage.Contains("<response>4") == true)
                {
                    return -6; // повторная заявка
                }
                if (resultPage.Contains("<error_code>1") == true)
                {
                    return -1; // лимит
                }
                if (resultPage.Contains("<error_code>174") == true)
                {
                    return -2; // сам себя
                }
                if (resultPage.Contains("<error_code>175") == true)
                {
                    return -3; // Вы в чёрном списке
                }
                if (resultPage.Contains("<error_code>176") == true)
                {
                    return -4; // у Вас в чёрном списке
                }
            }


            return -5; // другая ошибка
        }
    }
}
