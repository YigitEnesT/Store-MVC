using Entities.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace StoreApp.Components
{
    public class AddReviewViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(ProductReviewDtoForInsertion model)
        {
            return View(model);
        }
    }
}
