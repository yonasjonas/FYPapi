using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using WebApi.Models;
using WebApi.Helpers;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    [Route("/api/upload")]
    public class FileUploadController : Controller
    {
        public readonly DataContext _context;

        public FileUploadController(DataContext context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<FileModel>> GetFile(int id)
       {


            var fileinfo = await _context.FileUpload.FindAsync(id);

            if (fileinfo == null)
            {
                return NotFound();
            }

            return fileinfo;
        }

        public void createdirectory(string path)
        {
            if (Directory.Exists(path))
            {
                Console.WriteLine("That path exists already.");
                return;
            }

            // Try to create the directory.
            DirectoryInfo di = Directory.CreateDirectory(path);
            Console.WriteLine("The directory was created successfully at {0}.", Directory.GetCreationTime(path));


        }

        static public void deleteFileIfExist(string path)
        {

            /*try
            {
                // Check if file exists with its full path    
                if (File.Exists(path))
                {
                    // If file found, delete it    
                    File.Delete(path);
                    Console.WriteLine("File deleted.");
                }
                else Console.WriteLine("File not found");
            }
            catch (Exception e)
            {

            }*/

        }



        [HttpPost("image/file")]
        public async Task<ActionResult<FileModel>> PostImage([FromForm] FileModel file, IFormCollection data)
        {
            try
            {

                string fileName = Path.GetRandomFileName();
                
                string path = Path.Combine(@"C:\Users\jonas.samaitis\Documents\dev\fp\BookingServicesFrontEnd\public\business\" + file.BusinessId, file.Type + "." + data.Files[0].FileName.Substring(data.Files[0].FileName.Length - 3));

                deleteFileIfExist(path);
                createdirectory(@"C:\Users\jonas.samaitis\Documents\dev\fp\BookingServicesFrontEnd\public\business\" + file.BusinessId);



                using (Stream stream = new FileStream(path, FileMode.Create))
                {

                    //file.
                    file.FormFile = data.Files[0];
                    file.FormFile.CopyTo(stream);
                }

                file.FileName = file.Type + "." + data.Files[0].FileName.Substring(data.Files[0].FileName.Length - 3);

                _context.FileUpload.Add(file);
                await _context.SaveChangesAsync();

                //return CreatedAtAction("GetBooking", new { id = bookingService.id }, bookingService);

                return StatusCode(StatusCodes.Status201Created);
            }
            catch (Exception)            {

                return StatusCode(StatusCodes.Status500InternalServerError); ;
            }

            

        }
    }
}
