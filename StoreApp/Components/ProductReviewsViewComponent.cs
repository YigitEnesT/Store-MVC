using Entities.Dtos;
using Entities.Models;
using Entities.RequestParameters;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;
using StoreApp.Models;

namespace StoreApp.Components
{
    public class ProductReviewsViewComponent : ViewComponent
    {
        private readonly IServiceManager _manager;

        public ProductReviewsViewComponent(IServiceManager manager)
        {
            _manager = manager;
        }

        public IViewComponentResult Invoke(ReviewRequestParameter p)
        {
            var reviews = _manager.ReviewService.GetAllReviewsById(p.ProductId, false);
            var pagedReviews = _manager.ReviewService.GetAllReviewsWithPagination(p);

            var pagination = new Pagination
            {
                CurrentPage = p.PageNumber,
                ItemsPerPage = p.PageSize,
                TotalItems = reviews.Count()   
            };

            var viewModel = new ReviewListViewModel
            {
                Reviews = pagedReviews,
                Pagination = pagination
            };

            return View(viewModel);

        }
    }
}