using Microsoft.AspNetCore.Http;

namespace Course.Repository.ViewModeles {
    public class BookFormViewModel {
        public string Name { get;set; }
        public string Description { get;set; }
        public IFormFile Cover { get;set; }
        public IFormFile Book { get;set; }
         public decimal Price { get;set; }
        public string? UserName { get;set; }

    }
}
