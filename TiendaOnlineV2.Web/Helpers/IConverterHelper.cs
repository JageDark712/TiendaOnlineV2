using System;
using TiendaOnlineV2.Web.Models;

namespace TiendaOnlineV2.Web.Helpers
{
    public interface IConverterHelper
    {
        Category ToCategory(CategoryViewModel model, Guid imageId, bool isNew);
        CategoryViewModel ToCategoryViewModel(Category category);
    }
}
