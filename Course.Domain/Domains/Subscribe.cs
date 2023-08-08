

namespace Course.Domain.Domains {
    public class Subscribe {
        public int Id { get; set; }
        [ForeignKey(nameof(User))]
        public string? UserId { get; set; }
        public virtual AppUser User { get; set; }
        public int? TitleId { get; set; }
        public virtual Title Title { get; set; }    
    }
}
