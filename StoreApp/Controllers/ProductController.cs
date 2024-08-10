using System.Security.Claims;
using Entities.Dtos;
using Entities.Models;
using Entities.RequestParameters;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Repositories;
using Repositories.Contracts;
using Services.Contracts;
using StoreApp.Models;

namespace StoreApp.Controllers
{
    public class ProductController : Controller
    {
        private readonly IServiceManager _manager;
        private readonly UserManager<IdentityUser> _userManager;

        public ProductController(IServiceManager manager, UserManager<IdentityUser> userManager)
        {
            _manager = manager;
            _userManager = userManager;
        }

        public IActionResult Index(ProductRequestParameters p)
        {
            ViewData["Title"] = "Products";
            var products = _manager.ProductService.GetAllProductsWithDetails(p);

            var pagedProducts = _manager.ProductService.GetProductsWithPagination(p);

            var pagination = new Pagination
            {
                CurrentPage = p.PageNumber,
                ItemsPerPage = p.PageSize,
                TotalItems = products.Count()
            };

            var viewModel = new ProductListViewModel
            {
                Products = pagedProducts,
                Pagination = pagination
            };

            return View(viewModel);
        }


        public IActionResult Get([FromRoute(Name = "id")] int id)
        {
            var model = _manager.ProductService.GetOneProduct(id, false);
            ViewData["Title"] = model?.ProductName;
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateReview([FromForm] ProductReviewDtoForInsertion reviewDto)
        {
            if (ModelState.IsValid)
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                if (_manager.ReviewService.GetAllReviewsById(reviewDto.ProductId, false).Where(r => r.UserId.Equals(userId)).Count() > 0)
                {
                    TempData["ErrorMessage"] = "Kullanıcı aynı ürüne birden fazla yorum yazamaz.";
                    return RedirectToAction("Get", "Product", new { id = reviewDto.ProductId });
                }

                var reviewWithUserId = reviewDto with { UserId = userId };
                _manager.ReviewService.AddOneReview(reviewWithUserId);

                TempData["SuccessMessage"] = "Yorum başarıyla eklendi!";
                return RedirectToAction("Get", "Product", new { id = reviewDto.ProductId });
            }

            TempData["ErrorMessage"] = "Geçersiz giriş. Lütfen tekrar deneyin.";
            return RedirectToAction("Get", "Product", new { id = reviewDto.ProductId });
        }

        [HttpPost]
        public IActionResult RemoveReview([FromForm] int id, [FromForm] int productId)
        {
            _manager.ReviewService.DeleteOneReview(id, false);
            TempData["SuccessMessage"] = "Silme işlemi başarılı.";
            return RedirectToAction("Get", "Product", new { id = productId });
        }

    }
}