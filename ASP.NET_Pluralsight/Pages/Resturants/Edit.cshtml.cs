using Microsoft.AspNetCore.Mvc.Rendering;

namespace ASP.NET_Pluralsight.Pages.Resturants
{
    public class EditModel : PageModel
    {
        private readonly IResturantData _resturantData;
        private readonly IHtmlHelper _htmlHelper;

        public EditModel(IResturantData resturantData , IHtmlHelper htmlHelper)
        {
            _resturantData = resturantData;
            _htmlHelper = htmlHelper;
        }
        [BindProperty]
        public Resturant Resturant { get; set; }

        [TempData]
        public string Message { get; set; }
        public IEnumerable<SelectListItem> Cuisines { get; set; }

        public IActionResult OnGet(int? resturantId)
        {
            Cuisines = _htmlHelper.GetEnumSelectList<CuisineType>();
            if (resturantId.HasValue)
            {
                Resturant = _resturantData.GetResturantById(resturantId.Value);

            }
            else
            {
                Resturant = new Resturant();            
            }
            if (Resturant == null)
                return RedirectToPage("./NotFound");
            else
                return Page();
        }
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                Cuisines = _htmlHelper.GetEnumSelectList<CuisineType>();
                return Page();
            }
            if (Resturant.Id > 0)
            {
                _resturantData.Update(Resturant);
            }
            else
            {
                _resturantData.Add(Resturant);
            }
            _resturantData.Commit();
            TempData["Message"] = "Resturant Saved!";
            return RedirectToPage("./Detail" , new { resturantId = Resturant.Id });
            }   
            
        }
    }

