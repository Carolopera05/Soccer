using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace Soccer.Web.Helpers
{
    public interface ICombosHelper
    {
        IEnumerable<SelectListItem> GetComboTeams();// List generic
        IEnumerable<SelectListItem> GetComboTeams(int id);

    }
}
