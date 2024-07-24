using Entities.Models;
using Repositories.Contracts;
using Services.Contracts;

namespace Services
{
    public class ProductManager : IProductService
    {
        private readonly IRepositoryManager _manager;

        public ProductManager(IRepositoryManager manager)
        {
            _manager = manager;
        }

        public void CreateProduct(Product product)
        {
            _manager.Product.CreateProduct(product);
            _manager.Save();
        }

        public void DeleteOneProduct(int id, bool trackChanges)
        {
            Product entity = GetOneProduct(id,trackChanges);
            if (entity is not null)
            {
                _manager.Product.DeleteOneProduct(entity);
                _manager.Save();
            }
        }

        public IEnumerable<Product> GetAllProducts(bool trackChanges)
        {
            return _manager.Product.GetAllProducts(trackChanges);
        }

        public Product? GetOneProduct(int id, bool trackChanges)
        {
            var product = _manager.Product.GetOneProduct(id,trackChanges);
            if (product is null)
                throw new Exception("Product not found.");
            
            return product;
        }

        public void UpdateOneProduct(Product product)
        {
            var entity = _manager.Product.GetOneProduct(product.ProductId,true);
            if(entity is null)
                throw new Exception("Product not found.");
            entity.ProductName=product.ProductName;
            entity.Price = product.Price;

            _manager.Save();
        }
    }
}