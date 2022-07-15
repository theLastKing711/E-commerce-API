namespace ECommerce.API.Helpers
{
    public interface IImagesUploader
    {
        string UploadImage(IFormFile file);
    }
}
