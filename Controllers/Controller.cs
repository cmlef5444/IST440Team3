using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IST440Team3.Models;

namespace IST440Team3.Controllers
{
    public class Controller
    {
        public Controller()
        {   
            //login
            //tesseract module
            var varCipher = new CeaserCipher(); //decrypt module
            var varTranslation = new Translation(varCipher.Decrypt()); //translate
            //transfrom (packages avaivle to convert to pdf)
            //Notification

         //  varCipher.Decrypt();    //returns arrayList of all 26 ciphers, is input for translate

        }
        

    






    }
}
