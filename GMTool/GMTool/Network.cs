using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;


namespace GMTool
{
    public class Network
    {
        private CookieContainer cookieJar = new CookieContainer();


        public Network()
        {
            

        }
        public string HttpPost(string URI, string Parameters)
        {
            HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create(URI);
            req.CookieContainer = this.cookieJar;
            //req.Proxy = new System.Net.WebProxy(ProxyString, true);
            //Add these, as we're doing a POST
            req.ContentType = "application/x-www-form-urlencoded";
            req.Method = "POST";
            //We need to count how many bytes we're sending. Post'ed Faked Forms should be name=value&
            byte[] bytes = System.Text.Encoding.ASCII.GetBytes(Parameters);
            req.ContentLength = bytes.Length;
            System.IO.Stream os = req.GetRequestStream();
            os.Write(bytes, 0, bytes.Length); //Push it out there
            os.Close();
            System.Net.WebResponse resp = req.GetResponse();
            if (resp == null) return null;
            System.IO.StreamReader sr = new System.IO.StreamReader(resp.GetResponseStream());
            return sr.ReadToEnd().Trim();
        }

        public string HttpGet(string URI)
        {
            HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create(URI);
            req.CookieContainer = this.cookieJar;
            //req.Proxy = new System.Net.WebProxy(ProxyString, true); //true means no proxy
            System.Net.WebResponse resp = req.GetResponse();
            System.IO.StreamReader sr = new System.IO.StreamReader(resp.GetResponseStream());
            return sr.ReadToEnd().Trim();
        }

    }
}
