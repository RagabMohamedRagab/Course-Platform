
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace Course.Service.Utilities {
    public class FileService : IFileService {
        private readonly IHostingEnvironment _hosting;

        public FileService(IHostingEnvironment hosting)
        {
            _hosting = hosting;
        }
        public async Task<bool> UploadFile(IFormFile file, string fname)
        {
            if (file.Length > 0)
            {
                var root = Path.Combine(_hosting.WebRootPath, fname);
                if (!Directory.Exists(root))
                    Directory.CreateDirectory(root);
                string Name =file.FileName;
                var fullPath = Path.Combine(root, Name);
                using (var stream = new FileStream(fullPath, FileMode.Create))
                {
                    file.CopyTo(stream);
                    stream.Close();
                    return true;
                };

            }
            return false;
        }
    }
}





