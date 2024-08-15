using Entities.Models;

namespace Repositories.Extensions
{
    public static class ReviewRepositoryExtension
    {
        public static IQueryable<ProductReview> ToPaginate(this IQueryable<ProductReview> reviews, int pageNumber, int pageSize)
        {
            return reviews
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize);
        }
    }
}