namespace Course.Repository.ViewModeles {
    public class DisplayTitlesViewModel {
        public IEnumerable<TitlesViewModel> Titles { get; set; }
        public string Orderby { get; set; } = "ASC";
        public string SearchBy { get; set; }
        public int TotalPages { get; set; }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
    }
}
