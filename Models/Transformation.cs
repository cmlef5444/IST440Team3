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

using PdfSharp;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using PdfSharp.Pdf.IO;
using PdfDocument = PdfSharp.Pdf.PdfDocument;

using MigraDoc;
using MigraDoc.Rendering;
using MigraDoc.RtfRendering;
using MigraDoc.DocumentObjectModel;

namespace IST440Team3.Models
{
    public class Transformation
    {
        public string FilePath { get; set; }
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
        public Document ConvertToPdf3(ArrayList translationInput, int caseNumber, int evidenceNumber)
        {
            Document document = CreateDocument(translationInput, caseNumber, evidenceNumber);
            document.UseCmykColor = true;
            const bool unicode = false;
            //const PdfFontEmbedding embedding = PdfFontEmbedding.Always;   PDFDocumentRenderer no longer requires PDFFontEmbedding

            PdfDocumentRenderer pdfRenderer = new PdfDocumentRenderer(unicode);

            pdfRenderer.Document = document;
            pdfRenderer.RenderDocument();
            string filename = "CsNum" + caseNumber + ".EviNum" + evidenceNumber + ".pdf";
            pdfRenderer.PdfDocument.Save(filename);

            return document;
        }

        static Document CreateDocument(ArrayList translationInput, int caseNumber, int evidenceNumber)
        {
            Document document = new Document();
            string name = "Case #" + caseNumber + " Evidence #" + evidenceNumber;
            Section section = document.AddSection();
            Paragraph paragraph = section.AddParagraph(name);

            string newText = "";
            int i = 0;
            foreach (string str in translationInput)
            {
                i++;
                Console.WriteLine(i + " " + str);
                newText = i + ": " + str;
                section.AddParagraph(newText);
            }
            return document;
        }


        //PDFSharp - less features but same company as MigraDoc
        public PdfDocument ConvertToPdf2(ArrayList translationInput, int caseNumber, int evidenceNumber)
        {
            PdfDocument document = new PdfDocument();

            document.Info.Title = "Decrypted Translations";

            PdfSharp.Pdf.PdfPage page = document.AddPage();
            
            XGraphics gfx = XGraphics.FromPdfPage(page);

            XFont font = new XFont("Verdna", 11, XFontStyle.Regular);

            var formatter = new PdfSharp.Drawing.Layout.XTextFormatter(gfx);
            var rectangle = new XRect(10, 10, page.Width, page.Height);
            string newText = "";
            //string newText2 = "";
            int i =  0;
            foreach (string text in translationInput)
            {
                i++;
                Console.WriteLine(i + " " + text); 
                newText = newText + i + ". " + text + "\r\n";          
            }            
            formatter.DrawString(newText, font, XBrushes.Black, rectangle);

            string filename = "CsNum" + caseNumber + ".EviNum" + evidenceNumber + ".pdf";
            document.Save(filename);
            //Process.Start(filename);

            return document;
        }

        //Select.PDF.Core - deprecated (for this program) due to cost restraints
        public SelectPdf.PdfDocument ConvertToPdf(ArrayList translationInput, int caseNumber, int evidenceNumber)
        {

            SelectPdf.PdfDocument doc = new SelectPdf.PdfDocument();
            SelectPdf.PdfPage page = doc.AddPage();
            SelectPdf.PdfPage page2 = doc.AddPage();
            SelectPdf.PdfPage page3 = doc.AddPage();

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
            string name = "CsNum" + caseNumber + ".EviNum" + evidenceNumber + ".pdf";
            doc.Save(name);
            //string pathToSave = @"src\CipherStoreTemp";
            //FileStream stream = System.IO.File.Create(pathToSave);
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
