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
            var username = User.Identity.Name;
            var reviews =  _manager.ReviewService.GetAllReviewsById(id ,false).OrderByDescending(r => r.User.UserName.Equals(username));
            return View(reviews);
        }
    }
}