using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using WebApi.Models;
using WebApi.Helpers;
using System.Threading.Tasks;
using SixLabors.ImageSharp.Processing;
using SixLabors.ImageSharp;

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

            try
            {
                // Check if file exists with its full path    
                if (System.IO.File.Exists(path))
                {
                    // If file found, delete it    
                    System.IO.File.Delete(path);
                    Console.WriteLine("File deleted.");
                }
                else Console.WriteLine("File not found");
            }
            catch (Exception e)
            {

            }

        }

        public void CustomCrop(string filePath, IFormFile blob, int width, int height)
        {
            
            try
            {
               
                using (var image = Image.Load(blob.OpenReadStream()))
                {


                    //int width = image.Width / 2;
                    if (image.Height < height) {
                        height = image.Height;
                    }

                    //int height = image.Height / 2;
                    //image.Mutate(x => x.Resize(width, height));
                    image.Mutate(x => x.Resize(width * 2, 0).Crop(new Rectangle((image.Width - width) / 2, (image.Height - height) / 2, width, height)));
                    deleteFileIfExist(filePath);
                    image.Save(filePath);
                }
            }
            catch (Exception)
            {
                
            }
        }




        [HttpPost("image/file")]
        public async Task<ActionResult<FileModel>> PostImage([FromForm] FileModel file, IFormCollection data)
        {
            try
            {

                string path = "";
                string systemFileExtenstion = ".jpg";
                file.FileName = file.Type + systemFileExtenstion;

                if (file.Type == "providerImage")
                {
                   
                    path = Path.Combine(@"C:\home\site\wwwroot\wwwroot\business\" + file.BusinessId + @"\provider\", file.Type + "_" + file.ProviderId + systemFileExtenstion);

                    createdirectory(@"C:\home\site\wwwroot\wwwroot\business\" + file.BusinessId + @"\provider\");
                    CustomCrop(path, data.Files[0], 200, 200);
                }
                else if (file.Type == "businessInformationProfile")
                {

                    path = Path.Combine(@"C:\home\site\wwwroot\wwwroot\business\" + file.BusinessId, file.Type + systemFileExtenstion);
                    createdirectory(@"C:\home\site\wwwroot\wwwroot\business\" + file.BusinessId);
                    CustomCrop(path, data.Files[0], 200, 200);
                }
                else if (file.Type == "serviceImage")
                {

                    path = Path.Combine(@"C:\home\site\wwwroot\wwwroot\business\" + file.BusinessId + @"\service\", file.Type + "_" + file.ProviderId + systemFileExtenstion);

                    createdirectory(@"C:\home\site\wwwroot\wwwroot\business\" + file.BusinessId + @"\service\");
                    CustomCrop(path, data.Files[0], 300, 200);
                }
                else if (file.Type == "businessInformationCover")
                {

                    path = Path.Combine(@"C:\home\site\wwwroot\wwwroot\business\" + file.BusinessId, file.Type + systemFileExtenstion);
                    createdirectory(@"C:\home\site\wwwroot\wwwroot\business\" + file.BusinessId);

                    CustomCrop(path, data.Files[0], 1920, 300);

                }
                



                //using (Stream stream = new FileStream(path, FileMode.Create))
                //{

                    //file.
                    //file.FormFile = data.Files[0];
                    //file.FormFile.CopyTo(stream);
                //}

                

                //_context.FileUpload.Add(file);
                await _context.SaveChangesAsync();

                //return CreatedAtAction("GetBooking", new { id = bookingService.id }, bookingService);

                return StatusCode(StatusCodes.Status201Created);
            }
            catch (Exception)            {

                return StatusCode(StatusCodes.Status500InternalServerError);
            }

            

        }
    }
}
