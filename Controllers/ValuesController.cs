using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.IO;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace IST440Team3.Models
{
    public class ValuesController : Controller
    {
        private IHostingEnvironment _env;
        public ValuesController(IHostingEnvironment env)
        {
            _env = env;
        }

       // public IActionResult Index() => View();
        public IActionResult SingleFile(IFormFile file)
        {
            var dir = _env.ContentRootPath;

            using (var filestream = new FileStream(Path.Combine(dir, "file.png"), FileMode.Create, FileAccess.Write))
            {
                file.CopyTo(filestream);
            }
            
               return RedirectToAction("Index");
        }

    }
}
