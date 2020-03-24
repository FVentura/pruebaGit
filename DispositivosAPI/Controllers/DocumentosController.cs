using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileProviders;


namespace DispositivosAPI.Controllers
{
    [Route("Documentos")]
    [ApiController]
    public class DocumentosController : ControllerBase
    {
       // public System.IO.Stream CreateReadStream();

        //[Serializable]
        public class FileProvider
        {
            public IFormCollection FormData { get; set; }
            public string TestString { get; set; }
        }

        [HttpPost("formdata")]
        public IActionResult Upload([FromForm]FileProvider fileProvider)
        {
            try
            {
               // var files = fileProvider.Creat;
                var testString = fileProvider.TestString;

                //IFormFileCollection fileCollection = fileProvider.FormData.Files;
                //string testString = fileProvider.TestString;


                //foreach (IFormFile file in fileCollection)
                //{

                //    /// Read at a line a time.
                //    StringBuilder lineAtATime = new StringBuilder();
                //    using (var reader = new StreamReader(file.OpenReadStream()))
                //    {
                //        while (reader.Peek() >= 0)
                //        {
                //            string line = reader.ReadLine();
                //            lineAtATime.Append(line);
                //        }
                //    }
                //    string textByLines = lineAtATime.ToString();


                //}
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error: " + ex.Message);
            }
        }



        [Microsoft.AspNetCore.Mvc.HttpPost]
        [Microsoft.AspNetCore.Mvc.Route("Envia_Doc")]
        public async Task<object> UploadDocument()
        {
            //IFormFile iff = docInfo.File;
            //string fn = iff.FileName;
            //var tempFilename = $@"c:\temp\{fn}";

            //using (var fileStream = new FileStream(tempFilename, FileMode.Create))
            //{
            //    await iff.CopyToAsync(fileStream);
            //}

           // return Ok();
           // var a = fs;
           // var b = value;
            MyMethod(HttpContext);


            return Ok();
        }
        public void MyMethod(Microsoft.AspNetCore.Http.HttpContext context)
        {           
            //var files = HttpContext.Request.Form.Files;
            IFormFileCollection iff =(IFormFileCollection)context.Request.Form.Files;
           // string fn = iff FileName;
            // int b = a.Count;
            // Other code
        }
    }
}