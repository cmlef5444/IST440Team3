using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace IST440Team3.Controllers
{
    //[Route("api/[controller]")]
    //public class UploadController : Controller
    //{
    //    [HttpPost, DisableRequestSizeLimit]
    //    public IActionResult Upload()
    //    {
    //        try
    //        {
    //            var file = Request.Form.Files[0];
    //            var folderName = Path.Combine("Resources", "Images");
    //            var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);

    //            if(file.length > 0)
    //            {
    //                var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
    //                var fullPath = Path.Combine(pathToSave, fileName.ToString());
    //                var dbPath = Path.Combine(folderName, fileName.ToString());

    //                using (var stream = new FileStream(fullPath, FileMode.Create))
    //                {
    //                    file.CopyTo(stream);
    //                }
    //                return Ok(new { dbPath });
    //            }
    //            else
    //            {
                    
    //                return BadRequestResult; 
    //            }
    //        }
    //        catch(Exception ex)
    //        {
    //            return StatusCode(500, $"Internal server error: {ex}");
    //        }
    //    }
    //}
}
