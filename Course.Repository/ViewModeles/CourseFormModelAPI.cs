
using Microsoft.AspNetCore.Http;

namespace Course.Repository.ViewModeles {
    public class CourseFormModelAPI {
        public string Name { get; set; }
        public string Description { get; set; }
        public IFormFile File { get; set; }
        public int TitleId { get; set; }    
        public string UserName { get; set; }
    }
}
