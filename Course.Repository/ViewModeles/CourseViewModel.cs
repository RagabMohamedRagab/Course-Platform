namespace Course.Repository.ViewModeles {
    public class CourseViewModel {
        public CourseViewModel()
        {
            Titles= new List<string>();
        }
        public CourseViewModel course { get; set; }
        public IList<string> Titles { get; set; }
    }
}
