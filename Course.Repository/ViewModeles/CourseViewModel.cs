namespace Course.Repository.ViewModeles {
    public class CourseViewModel {
        public CourseViewModel course { get; set; }
        public IList<TitleFormViewModel> Titles { get; set; }
    }
}
