using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;

namespace VKSixDegreesOfSeparation
{
    enum FetchResult
    {
        Success,
        ConnectionError,
        BadData
    }

    class VKFetcher
    {
        public FetchResult Status
        {
            get
            {
                return _status;
            }
        }

        protected string httpRequest(string url)
        {
            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);

            httpWebRequest.Timeout = 3000; //3s

            string responseString = ""; //resp string

            try
            {
                WebResponse response = httpWebRequest.GetResponse();

                Stream dataStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(dataStream);

                string responseFromServer = reader.ReadToEnd();

                reader.Close();
                response.Close();

                if (responseFromServer.IndexOf("error") >= 0)
                {
                    _status = FetchResult.BadData;
                    return responseString;
                }

                responseString = responseFromServer;
            }
            catch (System.Net.WebException)
            {
                _status = FetchResult.ConnectionError;
                return "";
            }

            _status = FetchResult.Success;
            return responseString;
        }

        protected FetchResult _status;
        protected VKUser _user;
    }
}
