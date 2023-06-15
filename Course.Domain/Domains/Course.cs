using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace Course.Domain.Domains {
    public partial class Course : BaseEntity {

        [StringLength(maximumLength:100)]
        public string Name { get; set; }
        public string? Logo { get; set; }
        public string Description { get; set; }
    }
}

