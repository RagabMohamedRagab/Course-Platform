
using Microsoft.AspNetCore.Http;

namespace Course.Repository.ViewModeles {
    public class UpdateTitleViewModel {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Logo { get; set; }
        public IFormFile? file { get; set; }
    }
}
