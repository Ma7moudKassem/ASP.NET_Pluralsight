namespace ASP.NET_Pluralsight
{
    public partial class ListModel : PageModel
    {
        public IEnumerable<Resturant> Resturants { get; set; }
        private readonly IResturantData _resturantData;

        [BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; }
        public ListModel(IResturantData resturantData)
        {
            _resturantData = resturantData;
        }

        public void OnGet()
        {
            Resturants = _resturantData.GetResturantByName(SearchTerm);
        }
    }
}
