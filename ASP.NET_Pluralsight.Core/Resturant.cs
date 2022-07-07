namespace ASP.NET_Pluralsight.Core
{
    public class Resturant
    {
        public int Id { get; set; }

        [Required, MaxLength(50)]
        public string? Name { get; set; }

        [Required, MaxLength(255)]
        public string? Location { get; set; }
        public CuisineType Cuisine { get; set; }
    }
}
