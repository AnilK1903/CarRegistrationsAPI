using CarRegistrationsAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CarRegistrationsAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Manufacturer> Manufacturers { get; set; }

        public DbSet<Car> Cars { get; set; }
    }
}
