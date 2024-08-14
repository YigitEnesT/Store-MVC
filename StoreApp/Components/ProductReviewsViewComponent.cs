using Entities.Dtos;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

namespace StoreApp.Components
{
    public class ProductReviewsViewComponent : ViewComponent
    {
        private readonly IServiceManager _manager;

        public ProductReviewsViewComponent(IServiceManager manager)
        {
            _manager = manager;
        }

        public IViewComponentResult Invoke(int id)
        {
            var reviews =  _manager.ReviewService.GetAllReviewsById(id ,false);
            return View(reviews);
        }
    }
}