using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using SelectPdf;




namespace IST440Team3.Models
{
    public class Transformation
    {
        public string Time { get; set; }
        public Transformation()
        {         

        }

        public PdfDocument ConvertToPdf(ArrayList translationInput)
        {
            Time = DateTime.Today.ToShortTimeString();
            PdfDocument doc = new PdfDocument();
            PdfPage page = doc.AddPage();

            PdfFont font = doc.AddFont(PdfStandardFont.Helvetica);
            font.Size = 15;

            PdfTextElement text = new PdfTextElement(50, 50, translationInput.ToString(), font);
            page.Add(text);

            doc.Save("Cipher.Translation " + Time + ".pdf");
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
