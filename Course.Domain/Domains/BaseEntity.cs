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
        [StringLength(maximumLength: 150)]
        public string CreatedBy { get; set; }
        [StringLength(maximumLength: 150)]
        public string ModifiedBy { get; set; }
        public bool IsDeleted { get; set; }
    }
}

