namespace ECommerce.API.Helpers
{
    public class ImagesUploader :IImagesUploader
    {
        public IWebHostEnvironment WebHostEnvironment { get; }


        public ImagesUploader(IWebHostEnvironment webHostEnvironment)
        {
            WebHostEnvironment = webHostEnvironment;
        }

        public string UploadImage(IFormFile file)
        {
            var rootPath = WebHostEnvironment.WebRootPath;

            string uploadsFolder = Path.Combine(rootPath, "images");
            string uniqueFileName = Guid.NewGuid().ToString() + "_" + file.FileName;

            string filePath = Path.Combine(uploadsFolder, uniqueFileName);

            using(var fileStream = new FileStream(filePath, FileMode.Create))
            {
                file.CopyTo(fileStream);
            }

            return uniqueFileName;

        }

    }
}
