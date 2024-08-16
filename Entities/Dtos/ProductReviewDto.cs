using System.ComponentModel.DataAnnotations;

namespace Entities.Dtos
{
    public record ProductReviewDto
    {
        public int ReviewId { get; init; }
        [Required(ErrorMessage = "Review Text is required.")]
        [MaxLength(250)]
        public String? ReviewText { get; init; }
        [Range(1,5, ErrorMessage = "Rating must be between 1 and 5.")]
        [Required(ErrorMessage ="Rating is required.")]
        public int Rating { get; init; }
        public DateTime ReviewDate { get; init; } = DateTime.Now;
        public String? UserId { get; init; }
        public int ProductId { get; init; }
    }
}