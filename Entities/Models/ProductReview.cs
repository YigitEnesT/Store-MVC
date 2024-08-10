using Microsoft.AspNetCore.Identity;

namespace Entities.Models
{
    public class ProductReview
    {
        public int ReviewId { get; set; }
        public String? ReviewText { get; set; }
        public int Rating { get; set; }
        public DateTime ReviewDate { get; set; }
        public String? UserId { get; set; }
        public IdentityUser? User { get; set; }
        public int ProductId { get; set; }
        public Product? Product { get; set; }
    }
}