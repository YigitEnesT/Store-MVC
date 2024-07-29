using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

namespace StoreApp.Components
{
    public class CategoryNumberViewComponent : ViewComponent
    {
        private readonly IServiceManager _manager;

        public CategoryNumberViewComponent(IServiceManager manager)
        {
            _manager = manager;
        }
        public string Invoke(int id)
        {
            
            var amount = _manager.ProductService.
                GetAllProducts(false)
                .Where(p => p.CategoryId.Equals(id))
                .Count().ToString();
            return amount;
        }
    }
}