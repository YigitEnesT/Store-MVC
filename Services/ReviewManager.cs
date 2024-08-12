using AutoMapper;
using Entities.Dtos;
using Entities.Models;
using Entities.RequestParameters;
using Repositories.Contracts;
using Services.Contracts;

namespace Services
{
    public class ReviewManager : IReviewService
    {
        private readonly IRepositoryManager _manager;
        private readonly IMapper _mapper;

        public ReviewManager(IRepositoryManager manager, IMapper mapper)
        {
            _manager = manager;
            _mapper = mapper;
        }

        public void AddOneReview(ProductReviewDtoForInsertion reviewDto)
        {
            ProductReview review = _mapper.Map<ProductReview>(reviewDto);
            
            _manager.Review.AddOneReview(review);
            _manager.Save();
        }

        public void DeleteOneReview(int id, bool trackChanges)
        {
            var review = _manager.Review.GetOneReview(id, trackChanges);
            if (review is not null)
            {
                _manager.Review.DeleteOneReview(review);
                _manager.Save();
            }
        }

        public IEnumerable<ProductReview> GetAllReviews(bool trackChanges)
        {
            return _manager.Review.GetAllReviews(trackChanges);
        }

        public IEnumerable<ProductReview> GetAllReviewsById(int productId, bool trackChanges)
        {
            return _manager.Review.GetAllReviewsById(productId, trackChanges);
        }

        public IEnumerable<ProductReview> GetAllReviewsWithPagination(ReviewRequestParameter p)
        {
            return _manager.Review.GetAllReviewsWithPagination(p);
        }

        public ProductReview? GetOneReview(int id, bool trackChanges)
        {
            var review = _manager.Review.GetOneReview(id, trackChanges);
            if (review is null)
                throw new Exception("Review is could not found.");
            return review;
        }

        public void UpdateOneReview(ProductReviewDtoForUpdate reviewDto)
        {
            ProductReview review = _mapper.Map<ProductReview>(reviewDto);

            _manager.Review.UpdateOneReview(review);
            _manager.Save();
        }
    }
}