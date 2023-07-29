
namespace Course.Domain.Domains {
    public class Book {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? book { get;set; }
        [ForeignKey(nameof(UserId))]
        public string? UserId { get;set; }
        public virtual AppUser user { get; set; }
    }
}
