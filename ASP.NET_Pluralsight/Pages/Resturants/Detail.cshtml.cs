namespace ASP.NET_Pluralsight.Pages.Resturants
{
    public class DetailModel : PageModel
    {
        private readonly IResturantData _resturantData;

        public DetailModel(IResturantData resturantData)
        {
            _resturantData = resturantData;
        }
        public Resturant? Resturant { get; set; }
        public IActionResult OnGet(int resturantId)
        {
            Resturant = _resturantData.GetResturantById(resturantId);
            if (Resturant == null)
                return RedirectToPage("./NotFound");
            else
                return Page();
        }
    }
}
