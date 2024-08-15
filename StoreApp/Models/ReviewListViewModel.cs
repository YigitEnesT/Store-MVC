using Entities.Models;

namespace StoreApp.Models
{
    public class ReviewListViewModel
    {
        public IEnumerable<ProductReview> Reviews { get; set; } = Enumerable.Empty<ProductReview>();
        public Pagination Pagination { get; set; } = new();
        public int TotalCount => Reviews.Count();
    }
}