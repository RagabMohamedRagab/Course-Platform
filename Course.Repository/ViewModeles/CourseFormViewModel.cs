using Microsoft.AspNetCore.Http;

namespace Course.Repository.ViewModeles {
    public class CourseFormViewModel {
        public string Name { get; set; }
        public IFormFile Logo { get; set; }
        public string Description { get; set; }

        public int TitleId { get; set; }
    }
}
