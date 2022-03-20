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


        [HttpPost("image/file")]
        public async Task<ActionResult<FileModel>> PostImage([FromForm] FileModel file, IFormCollection data)
        {
            try
            {

                string fileName = Path.GetRandomFileName();
                
                string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", fileName + data.Files[0].FileName);
                using (Stream stream = new FileStream(path, FileMode.Create))
                {
                    //file.
                    file.FormFile = data.Files[0];
                    file.FormFile.CopyTo(stream);
                }

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
