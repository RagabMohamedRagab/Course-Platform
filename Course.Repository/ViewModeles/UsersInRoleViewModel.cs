

namespace Course.Repository.ViewModeles {
    public class UsersInRoleViewModel {
        public UsersInRoleViewModel()
        {
            UsersInfo = new List<UsersInfoViewModel>();
        }
        public AddRoleViewModel role { get; set; }
        public IList<UsersInfoViewModel> UsersInfo { get; set; }
    }
}
