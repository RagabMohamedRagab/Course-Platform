using System.Collections.Generic;

namespace Course.Repository.ViewModeles {
    public class CourseViewModel {
        public CourseFormViewModel course { get; set; }
        public TitleFormViewModel Title { get; set; }
        public List<TitleDropDownListViewModel> Titles { get; set; }
        public string UserName{ get; set; }
    }
}
