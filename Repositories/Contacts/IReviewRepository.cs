using Entities.Models;
using Entities.RequestParameters;

namespace Repositories.Contracts
{
    public interface IReviewRepository : IRepositoryBase<ProductReview>
    {
        IQueryable<ProductReview> GetAllReviews(bool trackChanges);
        IQueryable<ProductReview> GetAllReviewsById(int productId, bool trackChanges);
        void AddOneReview(ProductReview review);
        void UpdateOneReview(ProductReview review);
        void DeleteOneReview(ProductReview review);
        ProductReview? GetOneReview(int id, bool trackChanges);
        IQueryable<ProductReview> GetAllReviewsWithPagination(ReviewRequestParameter p);
    }
}