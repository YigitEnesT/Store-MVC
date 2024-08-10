using Repositories.Contracts;

namespace Repositories
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly RepositoryContext _context;
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly IReviewRepository _reviewRepository;

        public RepositoryManager(IProductRepository productRepository,
         RepositoryContext context,
         ICategoryRepository categoryRepository,
         IOrderRepository orderRepository,
         IReviewRepository reviewRepository)
        {
            _context = context;
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
            _orderRepository = orderRepository;
            _reviewRepository = reviewRepository;
        }

        public IProductRepository Product => _productRepository;

        public ICategoryRepository Category => _categoryRepository;

        public IOrderRepository Order => _orderRepository;
        
        public IReviewRepository Review => _reviewRepository;

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}