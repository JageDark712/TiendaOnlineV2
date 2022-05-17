using System;
using System.Threading.Tasks;
using TiendaOnlineV2.Web.Models;

namespace TiendaOnlineV2.Web.Helpers
{
    public interface IConverterHelper
    {
        Category ToCategory(CategoryViewModel model, Guid imageId, bool isNew);
        CategoryViewModel ToCategoryViewModel(Category category);
        Task<Product> ToProductAsync(ProductViewModel model, bool isNew);
        ProductViewModel ToProductViewModel(Product product);
    }
}
