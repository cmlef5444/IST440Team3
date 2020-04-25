using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IST440Team3.Models;
using Microsoft.AspNetCore.Mvc;
using System.IO;

namespace IST440Team3.Controllers
{
    //[Authorize(Roles = Admin, User)]
    public class Controller
    {
        public Controller()
        {   
            //login
            //tesseract module
            var varCipher = new CeaserCipher(); //decrypt module
            var varTranslation = new Translation(); //translate module
            var varTransformation = new Transformation();

            varTransformation.ConvertToPdf(varTranslation.TranslateText(varCipher.Decrypt()));

            //transfrom (packages avaivle to convert to pdf)
            //Notification

         //  varCipher.Decrypt();    //returns arrayList of all 26 ciphers, is input for translate

        }

    
        

    






    }
}
