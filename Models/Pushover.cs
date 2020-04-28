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
        public Pushover(int caseNumber, int evidenceNumber)
        {
            var parameters = new NameValueCollection {
                { "token", "a4uc2ktpkdjigwmqbh5oheippnts23" },   //API Token
                { "user", "uu8xjohkzu35oocs4mj5xnemru8ppo" },     //pushover address: vhpftxh56f@pomail.net
                { "title", "Nittany Solutions: Decryption" }, 
                { "message", "Your Cipher and/or Translation for Case Number #" + caseNumber + " Evidence # " + evidenceNumber + " is complete." },
                //{ "attachment", filename }    //Removed to maintain chain of evidence
            };

            using (var client = new WebClient())
            {
                client.UploadValues("https://api.pushover.net/1/messages.json", parameters);
            }
        }

    }
}