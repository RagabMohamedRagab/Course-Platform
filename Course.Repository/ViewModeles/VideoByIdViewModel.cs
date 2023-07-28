
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Course.Repository.ViewModeles {
    public class VideoByIdViewModel {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Logo { get; set; }
        public IFormFile? File { get; set; }
        public string Description { get; set; }
        public int? TitleId { get; set; }
        public bool IsCompleted { get; set; } = true;
    }
}
