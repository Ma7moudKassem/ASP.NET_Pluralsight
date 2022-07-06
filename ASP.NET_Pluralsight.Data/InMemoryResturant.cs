using ASP.NET_Pluralsight.Core;

namespace ASP.NET_Pluralsight.Data
{
    public interface IResturantData
    {
        public IEnumerable<Resturant> GetAll();
    }
    public class InMemoryResturant : IResturantData
    {
        readonly List<Resturant> resturants;
        public InMemoryResturant()
        {
            resturants = new List<Resturant>()
            {

                new Resturant { Id = 1, Name = "Scott's Pizza", Location="Maryland", Cuisine=CuisineType.Italian},
                new Resturant { Id = 2, Name = "Cinnamon Club", Location="London", Cuisine=CuisineType.Italian},
                new Resturant { Id = 3, Name = "La Costa", Location = "California", Cuisine=CuisineType.Mexican}
            };
        }
        public IEnumerable<Resturant> GetAll()
        {
            return from r in resturants
                   orderby r.Name
                   select r;
        }
    }
}
