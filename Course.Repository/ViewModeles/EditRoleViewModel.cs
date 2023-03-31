using System.Drawing.Printing;

namespace Course.Repository.ViewModeles {
    public class EditRoleViewModel {
        public EditRoleViewModel()
        {
                UserName=new List<string>();    
        }
      public AddRoleViewModel role { get; set; }
      public IList<string> UserName { get; set; }
    }
}
