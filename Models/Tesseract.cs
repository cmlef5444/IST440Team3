using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using Tesseract;
using System.Drawing;

namespace IST440Team3.Models
{
    public class Tesseract
    {


        public const string folderName = "images/";
        public const string trainedDataFolderName = "tessdata";



        //public String DoOCR()
        //{
        //    // now add the following C# line in the code page  
            


        //    //string name = request.Image.FileName;
        //    //var image = request.Image;

        //    //if (image.Length > 0)
        //    //{
        //    //    using (var fileStream = new FileStream(folderName + image.FileName, FileMode.Create))
        //    //    {
        //    //        image.CopyTo(fileStream);
        //    //    }
        //    //}

        //    //string tessPath = Path.Combine(trainedDataFolderName, "");
        //    //string result = "";

        //    //using (var engine = new TesseractEngine(tessPath, request.DestinationLanguage, EngineMode.Default))
        //    //{
        //    //    using (var img = Pix.LoadFromFile(folderName + name))
        //    //    {
        //    //        var page = engine.Process(img);
        //    //        result = page.GetText();
        //    //        Console.WriteLine(result);
        //    //    }
        //    //}
        //    //return String.IsNullOrWhiteSpace(result) ? "Ocr is finished. Return empty" : result;


        //}
    }
}
