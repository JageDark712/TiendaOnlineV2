using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace TiendaOnlineV2.Web.Helpers
{
    public interface ICombosHelper
    {
        IEnumerable<SelectListItem> GetComboCategories();
    }
}
