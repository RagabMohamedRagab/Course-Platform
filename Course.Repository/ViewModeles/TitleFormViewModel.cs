using Microsoft.AspNetCore.Http;

namespace Course.Repository.ViewModeles {
    public class TitleFormViewModel {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public IFormFile Logo { get; set; }
    }
}
