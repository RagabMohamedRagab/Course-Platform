using System.ComponentModel.DataAnnotations;

namespace Course.Domain.Domains {
    public partial class AppUser:IdentityUser{
        public AppUser()
        {
           
            IsActive= false;
        }
        public string? Name { get; set; }
        public string? About { get; set; }
        public string? Logo { get; set; }
        [Column(TypeName ="nvarchar(150)")]
        public string? Facebook { get; set; }
        [Column(TypeName = "nvarchar(150)")]
        public string? Twitter { get; set; }
        [Column(TypeName = "nvarchar(150)")]
        public string? Instagram { get; set; }
        [Column(TypeName = "nvarchar(150)")]
        public string? LinkedIn { get; set; } 
        public bool IsActive { get; set; }
        public virtual ICollection<Title> Titles { get; set; }
        public virtual ICollection<Subscribe> Subscribes { get; set; }

    }
}
