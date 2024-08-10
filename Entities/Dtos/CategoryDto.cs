using System.ComponentModel.DataAnnotations;

namespace Entities.Dtos
{
    public record CategoryDto
    {
        public int CategoryId { get; init; }

        [Required(ErrorMessage = "Category Name is required.")]
        public String CategoryName { get; init; } = String.Empty;
    }
}