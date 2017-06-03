using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication2
{
    public enum httpMethod
    {
        GET,
        POST,
        PUT,
        DELETE
    }
    class Client
    {

        public string endPoint { get; set; }

        public httpMethod httpMethod { get; set; }

        public Client()
        {
            endPoint = string.Empty;
            httpMethod = httpMethod.GET;
        }
        public string request()
        {
            string str = string.Empty;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(endPoint);
            request.Method = httpMethod.ToString();
            Stream s;
            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            {
                if (response.StatusCode != HttpStatusCode.OK)
                {
                    throw new ApplicationException("wow you are so cool");
                }
                using (Stream responseStream = response.GetResponseStream())
                {
                    if (responseStream != null)
                    {
                        using (StreamReader reader = new StreamReader(responseStream))
                        {
                            str = reader.ReadToEnd();
                        }
                    }
                }

            }
            return str;
        }


    }
}
