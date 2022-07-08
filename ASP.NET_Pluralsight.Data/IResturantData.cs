namespace ASP.NET_Pluralsight.Data
{
    public interface IResturantData
    {
        public IEnumerable<Resturant> GetResturantByName(string name);
        public Resturant GetResturantById(int id);
        Resturant Update(Resturant updatedResturant);
        int Commit();
        public Resturant Add(Resturant newResturant);
        public Resturant Delete(int id);
    }
}
