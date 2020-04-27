using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IST440Team3.Models;
using IST440Team3.Ocr;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Http;
using System.Text;
using ServiceStack;

namespace IST440Team3.Controllers
{
    public class PdfsController : Controller
    {
        
        public PdfsController(String text, int caseNumber, int evidenceNumber)  //called on create post
        {
            var service = new TesseractService(@"C:\Users\cjani\OneDrive\Documents\GitHub\TesseractLocal", "eng", @"C:\Users\cjani\OneDrive\Documents\GitHub\TesseractLocal\tessdata");
            var varCipher = new CeaserCipher(); //decrypt module
            var varTranslation = new Translation(); //translate module
            var varTransformation = new Transformation(); //transformation module

            //MigraDoc
            varTransformation.ConvertToPdf3(varTranslation.TranslateText(varCipher.Decrypt(service.GetText(System.IO.File.OpenRead(text)))), caseNumber, evidenceNumber);

            //PDFSharp - less features but same company as MigraDoc
            //varTransformation.ConvertToPdf2(varTranslation.TranslateText(varCipher.Decrypt(service.GetText(System.IO.File.OpenRead(text)))), caseNumber, evidenceNumber);

            //Select.PDF.Core - deprecated (for this program) due to cost restraints
            //varTransformation.ConvertToPdf(varTranslation.TranslateText(varCipher.Decrypt(service.GetText(System.IO.File.OpenRead(text)))), caseNumber, evidenceNumber);

            //A little easier to read but most be covnerted to the above text due to an enclosed local variable
            //string path = @"C:\TempFolder\CipherText.png";
            //FileStream stream = System.IO.File.OpenRead(path);

            ////@"C:\TempFolder\CipherText.png";
            //string text = service.GetText(stream); //stearm == Stream[] images

            ////Console.WriteLine(text);

            //varTransformation.ConvertToPdf(varTranslation.TranslateText(varCipher.Decrypt(text)));


            //Test line
            //varTransformation.ConvertToPdf(varTranslation.TranslateText(varCipher.Decrypt(service.GetText(System.IO.File.OpenRead(@"C:\TempFolder\CipherText.png")))));
        }
    }
}
