namespace ASP.NET_Pluralsight.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Resturant> Resturants { get; set; }
    }
}
