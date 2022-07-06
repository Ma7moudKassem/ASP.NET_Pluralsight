using ASP.NET_Pluralsight.Core;
using ASP.NET_Pluralsight.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ASP.NET_Pluralsight
{
    public partial class ListModel : PageModel
    {
        public IEnumerable<Resturant> Resturants { get; set; }
        private readonly IResturantData _resturantData;

        public ListModel(IResturantData resturantData)
        {
            _resturantData = resturantData;
        }

        public void OnGet()
        {
            Resturants = _resturantData.GetAll();
        }
    }
}
