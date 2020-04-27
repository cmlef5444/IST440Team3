using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SelectPdf;
using ServiceStack;
using Google.Cloud.Translation.V2;
using Microsoft.AspNetCore.Http;
using System.Net.Http.Headers;

namespace IST440Team3.Models
{
    public class Transformation
    {
        public string Time { get; set; }
        public int Id { get; set; }
        public int CaseNumber { get; set; }
        public int EvidenceNumber { get; set; }
        public string OrigionalLanguage { get; set; }
        public string OutputLanguage { get; set; }
        //public IFormFile OrigionalFile { get; set; }
        //public IFormFile DecyptedFile { get; set; }
            
        public Transformation()
        { 
           Time = DateTime.Now.ToString();
        }       

        public PdfDocument ConvertToPdf(ArrayList translationInput)
        {            
            PdfDocument doc = new PdfDocument();
            PdfPage page = doc.AddPage();
            PdfPage page2 = doc.AddPage();
            PdfPage page3 = doc.AddPage();

            PdfFont font = doc.AddFont(PdfStandardFont.Helvetica);
            font.Size = 15;

            PdfRenderingResult result;

            PdfTextElement text = new PdfTextElement(50, 50, "Cipher Translations", font);
            result = page.Add(text);           

            int i = 0;
            foreach (string str in translationInput)    //if statements are a temporary code that would be changed with a paid subscription for Select.PDF
            {
                i++;
                PdfTextElement elem;// = new PdfTextElement(0, result.PdfPageLastRectangle.Bottom + 30, i + ": " + str, font);
                if(i <= 10) 
                {
                    elem = new PdfTextElement(0, result.PdfPageLastRectangle.Bottom + 30, i + ": " + str, font);
                    result = page.Add(elem);
                }
                else if(i <= 20)
                {
                    if (i == 11)
                    {
                        result = page2.Add(text);
                    }                    
                    elem = new PdfTextElement(0, result.PdfPageLastRectangle.Bottom + 30, i + ": " + str, font);
                    result = page2.Add(elem);
                }
                else if(i < 30)
                {   
                    if(i == 21)
                    {
                    result = page3.Add(text);
                    }                    
                    elem = new PdfTextElement(0, result.PdfPageLastRectangle.Bottom + 30, i + ": " + str, font);
                    result = page3.Add(elem);
                }              
            }
            doc.Save("Cipher2.Translation.pdf");
            doc.Close();                     

            return doc;

            //Additional features Below

            //// instantiate a html to pdf converter object
            //HtmlToPdf converter = new HtmlToPdf();

            //// create a new pdf document converting an url
            //PdfDocument doc = converter.ConvertUrl(TxtUrl.Text);

            //// get conversion result (contains document info from the web page)
            //HtmlToPdfResult result = converter.ConversionResult;

            //// set the document properties
            //doc.DocumentInformation.Title = result.WebPageInformation.Title;
            //doc.DocumentInformation.Subject = result.WebPageInformation.Description;
            //doc.DocumentInformation.Keywords = result.WebPageInformation.Keywords;

            //doc.DocumentInformation.Author = "Select.Pdf Samples";
            //doc.DocumentInformation.CreationDate = DateTime.Now;

            //// save pdf document
            //doc.Save(Response, false, "Sample.pdf");

            //// close pdf document
            //doc.Close();
        }

    }
}
