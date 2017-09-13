using Microsoft.AspNetCore.Http;
using System.IO;

namespace Fiap.Masterchef.Infra.Helpers
{
    public static class Extensions
    {
        public static byte[] GetDownloadBits(this IFormFile file)
        {
            using (var fileStream = file.OpenReadStream())
            using (var ms = new MemoryStream())
            {
                fileStream.CopyTo(ms);
                var fileBytes = ms.ToArray();
                return fileBytes;
            }
        }
    }
}
