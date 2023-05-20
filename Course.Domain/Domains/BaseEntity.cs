using System.ComponentModel.DataAnnotations;

namespace Course.Domain.Domains {
    public partial class BaseEntity {
        public BaseEntity()
        {
            CreateOn = DateTime.Now;
            IsDeleted = false;
        }
        public int Id { get; set; }
        [Column(TypeName="date")]
        public DateTime CreateOn { get; set; }
        [Column(TypeName = "date")]
        public DateTime ModifiedOn { get; set; }
        public bool IsDeleted { get; set; }
    }
}

