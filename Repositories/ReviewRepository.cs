using Entities.Models;
using Entities.RequestParameters;
using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;
using Repositories.Extensions;

namespace Repositories
{
    public class ReviewRepository : RepositoryBase<ProductReview>, IReviewRepository
    {
        public ReviewRepository(RepositoryContext context) : base(context)
        {
        }

        public void AddOneReview(ProductReview review) => Create(review);

        public void DeleteOneReview(ProductReview review) => Delete(review);

        public IQueryable<ProductReview> GetAllReviews(bool trackChanges) => FindAll(trackChanges).OrderByDescending(r => r.ReviewDate);

        public IQueryable<ProductReview> GetAllReviewsById(int productId, bool trackChanges)
        {
            return FindAll(trackChanges)
                .Include(r => r.User)
                .Where(p => p.ProductId.Equals(productId))
                .OrderByDescending(r => r.ReviewDate);
        }

        public IQueryable<ProductReview> GetAllReviewsWithPagination(ReviewRequestParameter p)
        {
            return GetAllReviewsById(p.ProductId, false)
                .OrderByDescending(r => r.User.UserName.Equals(p.UserName))
                .ThenByDescending(r => r.ReviewDate)
                .ToPaginate(p.PageNumber,p.PageSize);
        }

        public ProductReview? GetOneReview(int id, bool trackChanges)
        {
            return FindByCondition(r => r.ReviewId.Equals(id), trackChanges);
        }

        public void UpdateOneReview(ProductReview review) => Update(review);
    }
}