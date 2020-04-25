﻿using Google.Cloud.Translation.V2;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IST440Team3.Models
{
    public class Translation
    {
        //public string ApiKey { get; set;}
        //public int Id { get; set; }
        //public string Text { get; set; }
        //public string startLanguage { get; set; }
        //public string endLanguage { get; set; }

        ArrayList inputArray = new ArrayList();
        ArrayList outputArray = new ArrayList();


        public Translation()
        {
            
        }

        public ArrayList TranslateText(ArrayList inputArray)
        {
            var client = TranslationClient.Create();

            Console.WriteLine("");

            foreach(string text in inputArray)
            {
                //need to change languages for user nput, first is target language second is source language      
                var response = client.TranslateText(text, LanguageCodes.English, LanguageCodes.Spanish);
                Console.WriteLine("translation text " + response.TranslatedText);   //FIX_ME: Console check, remove on final
                outputArray.Add(response.TranslatedText.ToString());
            }

            return outputArray;
        }
    }
}
