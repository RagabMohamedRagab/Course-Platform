

namespace Course.Repository.ViewModeles {
    public class UsersInRoleViewModel {
        public UsersInRoleViewModel()
        {
            Users = new List<UsersInfoViewModel>();
        }
        public AddRoleViewModel role { get; set; }
        public IList<UsersInfoViewModel> Users { get; set; }
    }
}
