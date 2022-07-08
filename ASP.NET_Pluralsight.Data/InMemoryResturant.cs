namespace ASP.NET_Pluralsight.Data
{
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

        public Resturant Add(Resturant newResturant)
        {
            resturants.Add(newResturant);
            newResturant.Id = resturants.Max(e => e.Id)+1;
            return newResturant;
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

        public Resturant Update(Resturant updatedResturant)
        {
            var resturant = resturants.SingleOrDefault(e => e.Id == updatedResturant.Id);
            if (resturant != null)
            {
                resturant.Name = updatedResturant.Name;
                resturant.Location = updatedResturant.Location;
                resturant.Cuisine = updatedResturant.Cuisine;
            }
            return resturant;
        }
        public Resturant Delete(int id)
        {
            var resturant = resturants.FirstOrDefault(e => e.Id == id);
            if (resturant != null)
            {
                resturants.Remove(resturant);
            }
            return resturant;
        }
        public int Commit()
        {
            return 0;
        }
    }
}
