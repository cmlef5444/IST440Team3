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


namespace IST440Team3.Controllers
{
    //[Authorize(Roles = Admin, User)]
    public class PdfsController : Controller
    {
        
        private IHostingEnvironment _env;
        public PdfsController()
        {
            string path = @"C:\TempFolder\input-sample-image.png";
            FileStream stream = System.IO.File.OpenRead(path);

            //"src/IST440Team3/Pages/PDFs/input-sample-image.png"
            var service = new TesseractService(@"C:\Users\cjani\OneDrive\Documents\GitHub\TesseractLocal", "eng", @"C:\Users\cjani\OneDrive\Documents\GitHub\TesseractLocal\tessdata");
            string text = service.GetText(stream); //stearm == Stream[] images

            Console.WriteLine(text);



          




            //var varCipher = new CeaserCipher(); //decrypt module
            //var varTranslation = new Translation(); //translate module
            //var varTransformation = new Transformation();

            //varTransformation.ConvertToPdf(varTranslation.TranslateText(varCipher.Decrypt()));

      

         //  varCipher.Decrypt();    //returns arrayList of all 26 ciphers, is input for translate

        }
        public static async Task<string> ReadFormFileAsync(Microsoft.AspNetCore.Http.IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                return await Task.FromResult((string)null);
            }

            using (var reader = new StreamReader(file.OpenReadStream()))
            {
                return await reader.ReadToEndAsync();
            }
        }

        [HttpPost("PDFs /Create")]
        public async Task<IActionResult> Post(List<Microsoft.AspNetCore.Http.IFormFile> files)
        {
            long size = files.Sum(f => f.Length);

            // full path to file in temp location
            var filePath = Path.GetTempFileName();

            foreach (var formFile in files)
            {
                if (formFile.Length > 0)
                {
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await formFile.CopyToAsync(stream);
                    }
                }
            }

            // process uploaded files
            // Don't rely on or trust the FileName property without validation.

            return Ok(new { count = files.Count, size, filePath });
        }


        //public ValuesController(IHostingEnvironment env)
        //{
        //    _env = env;
        //}

        // public IActionResult Index() => View();
        //public IActionResult SingleFile(IFormFile file)
        //{
        //    var dir = _env.ContentRootPath;

        //    using (var filestream = new FileStream(Path.Combine(dir, "file.png"), FileMode.Create, FileAccess.Write))
        //    {
        //        file.CopyTo(filestream);
        //    }

        //    return RedirectToAction("Index");
        //}
        //public IActionResult SingleFile(IFormFile file)
        //{
        //    var dir = _env.ContentRootPath;
        //    using (var fileStream = new FileStream(Path.Combine(dir, "sample.png"), FileMode.Create, FileAccess.Write))
        //    {
        //        file.CopyTo(fileStream);
        //    }
        //    return RedirectToAction("Index");
        //}
        //public IActionResult Create()
        //{
        //    return View();
        //}
        //[HttpPost]
        //public IActionResult Create(Microsoft.AspNetCore.Http.IFormFile file)
        //{
        //    // Extract file name from whatever was posted by browser
        //    var fileName = System.IO.Path.GetFileName(file.FileName);

        //    // If file with same name exists delete it
        //    if (System.IO.File.Exists(fileName))
        //    {
        //        System.IO.File.Delete(fileName);
        //    }

        //    // Create new local file and copy contents of uploaded file
        //    using (var localFile = System.IO.File.OpenWrite(fileName))
        //    using (var uploadedFile = file.OpenReadStream())
        //    {
        //        uploadedFile.CopyTo(localFile);
        //    }

        //    ViewBag.Message = "File successfully uploaded";

        //    return View();
        //}
    }
}
