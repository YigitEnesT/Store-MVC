using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

namespace StoreApp.Components
{
    public class CategoriesSummaryViewComponent : ViewComponent
    {
        private readonly IServiceManager _manager;

        public CategoriesSummaryViewComponent(IServiceManager manager)
        {
            _manager = manager;
        }

        public string Invoke()
        {
            return _manager
                .CategoryService
                .GetAllCategories(false)
                .Count()
                .ToString();
        }
    }
}