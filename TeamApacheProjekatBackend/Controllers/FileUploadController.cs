using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TeamApacheProjekatBackend.Models;

namespace TeamApacheProjekatBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileUploadController : ControllerBase
    {
        private static IWebHostEnvironment _webHostEnvironment;
   
        public FileUploadController(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        [HttpPost]

        public async Task<ActionResult<string>> Upload([FromForm] Attachment obj)
        {
            if(obj.Files.Length > 0)
            {
                try
                {
                    if (!Directory.Exists(_webHostEnvironment.WebRootPath + "\\images\\"))
                    {
                        Directory.CreateDirectory(_webHostEnvironment.WebRootPath + "\\images\\");
                    }
                    using (FileStream filestream = System.IO.File.Create(_webHostEnvironment.WebRootPath +"\\images\\" + obj.Files.FileName))
                    {
                        obj.Files.CopyTo(filestream);
                        filestream.Flush();
                        return "\\images\\" + obj.Files.FileName;
                    }
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
            else
            {
                return "Upload failed";
            }
        }
    }
}
