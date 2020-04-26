using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IST440Team3.Models;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Http;


namespace IST440Team3.Controllers
{
    //[Authorize(Roles = Admin, User)]
    public class PdfsController : Controller
    {
        
        private IHostingEnvironment _env;
        public PdfsController()
        {
            Create();
            // _env = env;

            //login
            //tesseract module
            //var varValues = new ValuesController();
            var varCipher = new CeaserCipher(); //decrypt module
            var varTranslation = new Translation(); //translate module
            var varTransformation = new Transformation();

            varTransformation.ConvertToPdf(varTranslation.TranslateText(varCipher.Decrypt()));

            //transfrom (packages avaivle to convert to pdf)
            //Notification

         //  varCipher.Decrypt();    //returns arrayList of all 26 ciphers, is input for translate

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
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(IFormFile file)
        {
            // Extract file name from whatever was posted by browser
            var fileName = System.IO.Path.GetFileName(file.FileName);

            // If file with same name exists delete it
            if (System.IO.File.Exists(fileName))
            {
                System.IO.File.Delete(fileName);
            }

            // Create new local file and copy contents of uploaded file
            using (var localFile = System.IO.File.OpenWrite(fileName))
            using (var uploadedFile = file.OpenReadStream())
            {
                uploadedFile.CopyTo(localFile);
            }

            ViewBag.Message = "File successfully uploaded";

            return View();
        }
    }
}
