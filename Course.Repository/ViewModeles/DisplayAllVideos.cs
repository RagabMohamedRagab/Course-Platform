namespace Course.Repository.ViewModeles {
    public class DisplayAllVideos {
        public DisplayAllVideos()
        {
            Courses = new List<CoursesViewModel>();
            IsCompleted=false;
        }
        public IList<CoursesViewModel> Courses { get; set; }
        public bool IsCompleted { get; set; }
    }
}
