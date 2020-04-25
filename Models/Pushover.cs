using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using PushoverClient;

namespace IST440Team3.Models
{
    public class Pushover
    {
        public Pushover(string filename)
        {
            var parameters = new NameValueCollection {
                { "token", "APP_TOKEN" },   //Shermann: add api token
                { "user", "USER_KEY" },     //Shermann: add user key
              //  { "title", "this is our Title" }, //not sure about what it would be
                { "message", "Your Cipher and/or Translation is complete." },
                { "attachment", filename }
            };

            using (var client = new WebClient())
            {
                client.UploadValues("https://api.pushover.net/1/messages.json", parameters);
            }
        }

    }
}
