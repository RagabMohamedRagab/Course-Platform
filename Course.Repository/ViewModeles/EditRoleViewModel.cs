using System.Drawing.Printing;

namespace Course.Repository.ViewModeles {
    public class EditRoleViewModel {
        public EditRoleViewModel()
        {
                UserName=new List<string>();    
        }
      public string Id { get; set; }
      public string Name { get; set; }
      public IList<string> UserName { get; set; }
    }
}
