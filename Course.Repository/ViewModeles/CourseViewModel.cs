namespace Course.Repository.ViewModeles {
    public class CourseViewModel {
        public CourseViewModel()
        {
            Titles= new List<string>();
        }
        public CourseFormViewModel course { get; set; }
        public TitleFormViewModel Title { get; set; }
        public IList<string> Titles { get; set; }
    }
}
