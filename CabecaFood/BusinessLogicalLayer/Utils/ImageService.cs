using Microsoft.AspNetCore.Http;
using System.IO;

namespace BusinessLogicalLayer.Utils
{
    public static class ImageService
    {
        public static string InsertImageAndReturnPath(IFormFile image)
        {
            string path = Path.Combine("~Pictures" + image.FileName);
            using (var stream = new FileStream(path, FileMode.Create))
            {
                image.CopyTo(stream);
            }

            return path;
        }
    }
}
