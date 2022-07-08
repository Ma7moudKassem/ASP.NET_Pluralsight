namespace ASP.NET_Pluralsight.Data
{
    public class SqlResturantData : IResturantData
    {
        private readonly ApplicationDbContext _dbContext;

        public SqlResturantData(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Resturant Add(Resturant newResturant)
        {
            _dbContext.Add(newResturant);
            return newResturant;
        }

        public int Commit()
        {
           return _dbContext.SaveChanges();
        }

        public Resturant Delete(int id)
        {
            var resturant = GetResturantById(id);
            if (resturant != null)
            {
                _dbContext.Remove(resturant);
            }
            return resturant;
        }

        public Resturant GetResturantById(int id)
        {
            return _dbContext.Resturants.Find(id);
        }

        public IEnumerable<Resturant> GetResturantByName(string name)
        {
            var query = from resturant in _dbContext.Resturants
                        where resturant.Name == name || string.IsNullOrEmpty(name)
                        orderby resturant.Id
                        select resturant;
            return query;

        }

        public Resturant Update(Resturant updatedResturant)
        {
            var entity = _dbContext.Resturants.Attach(updatedResturant);
            entity.State = EntityState.Modified;
            return updatedResturant;
        }
    }
}
