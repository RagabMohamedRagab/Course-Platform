using Microsoft.AspNetCore.Http;

namespace Course.Repository.ViewModeles {
    public class TitleFormViewModel {
        public string Name { get; set; }
        public IFormFile Img { get; set; }
    }
}
