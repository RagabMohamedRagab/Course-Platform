
namespace Course.Domain.Domains {
    public class Book:BaseEntity {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Cover { get;set; }
        [Column(TypeName = "decimal(18,0)")]
        public decimal Price { get; set; }
        public string? book { get;set; }
        [ForeignKey(nameof(UserId))]
        public string? UserId { get;set; }
        public virtual AppUser user { get; set; }
    }
}
