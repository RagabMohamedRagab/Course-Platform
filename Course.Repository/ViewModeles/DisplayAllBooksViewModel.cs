

using System.ComponentModel.DataAnnotations.Schema;

namespace Course.Repository.ViewModeles {
    public class DisplayAllBooksViewModel {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Cover { get; set; }
        public string? book { get; set; }
        public string? UserId { get; set; }
    }
}
