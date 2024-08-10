using Entities.Dtos;
using Entities.Models;

namespace Services.Contracts
{
    public interface ICategoryService
    {
        IEnumerable<Category> GetAllCategories(bool trackChanges);
        void CreateOneCategory(CategoryDtoForInsertion categoryDto, bool trackChanges);
    }
}