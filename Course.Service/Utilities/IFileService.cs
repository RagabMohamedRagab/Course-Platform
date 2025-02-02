﻿
using Microsoft.AspNetCore.Http;

namespace Course.Service.Utilities { 
    public interface IFileService
    {
      
        Task<bool> UploadFile(IFormFile file, string fname);
        Task<bool> RemoveFile(string name,string fname);

    }
}
