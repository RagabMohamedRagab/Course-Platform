

namespace Course.Repository.ViewModeles {
    public class IndexViewModel {
        public IEnumerable<TitlesViewModel> Titles { get; set; }
        public IEnumerable<ProfileUserViewModel> profileUser { get; set; }
		public IEnumerable<TitlesViewModel> Books { get; set; }
	}
}
