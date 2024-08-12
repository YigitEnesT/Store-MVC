using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace Entities.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public ICollection<CartLine> Lines { get; set; } = new List<CartLine>();

        [Required(ErrorMessage = "Name is required.")]
        public String? Name { get; set; }
        [Required(ErrorMessage = "Adress is required.")]
        public String? Address { get; set; }
        [Required(ErrorMessage = "Street Adress is required.")]
        public String? StreetAddress { get; set; }
        [Required(ErrorMessage = "City is required.")]
        public String? City { get; set; }
        [Required(ErrorMessage = "County is required.")]
        public String? County { get; set; }
        public bool GiftWrap { get; set; }
        public bool Shipped { get; set; }
        public DateTime OrderedAt { get; set; } = DateTime.Now;
        public String? UserId { get; set; }
        public IdentityUser? User { get; set; }
    }
}