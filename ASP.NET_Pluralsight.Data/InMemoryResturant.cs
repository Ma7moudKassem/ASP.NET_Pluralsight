namespace ASP.NET_Pluralsight.Data
{
    public interface IResturantData
    {
        public IEnumerable<Resturant> GetResturantByName(string name);
        public Resturant GetResturantById(int id);
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

        public Resturant GetResturantById(int id)
        {
            return resturants.SingleOrDefault(e => e.Id == id);
        }

        public IEnumerable<Resturant> GetResturantByName(string name)
        {
            return from r in resturants
                   where string.IsNullOrEmpty(name) || r.Name.StartsWith(name)
                   orderby r.Name
                   select r;
        }
    }
}
