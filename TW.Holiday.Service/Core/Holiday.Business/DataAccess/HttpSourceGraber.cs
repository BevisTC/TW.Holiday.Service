using Communication.Component.WebApi;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Holiday.Business.DataAccess
{
    public class HttpSourceGraber<T> : ISourceGraber<T>
    {
        private string url;

        public HttpSourceGraber(string url)
        {
            this.url = url;
        }

        public T GetSource()
        {
            HttpWebResponse response =  HttpTools.Get(this.url);
            string json = Encoding.UTF8.GetString(response.ReadBody());

            T result = JsonConvert.DeserializeObject<T>(json);

            return result; 

        }
    }
}