using Entities.Dtos;
using Entities.Models;

namespace Services.Contracts
{
    public interface IReviewService
    {
        IEnumerable<ProductReview> GetAllReviews(bool trackChanges);
        IEnumerable<ProductReview> GetAllReviewsById(int productId, bool trackChanges);
        void AddOneReview(ProductReviewDtoForInsertion review);
        void UpdateOneReview(ProductReviewDtoForUpdate review);
        void DeleteOneReview(int id, bool trackChanges);
        ProductReview? GetOneReview(int id, bool trackChanges);
    }
}