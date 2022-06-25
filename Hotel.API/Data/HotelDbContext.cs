using Hotel.API.Models;
using Microsoft.EntityFrameworkCore;

namespace Hotel.API.Data
{
    public class HotelDbContext : DbContext
    {
        public HotelDbContext(DbContextOptions options) : base(options)
        {
        }

        //Dbset
        public DbSet<hotel> Hotels {get; set; }



       
    }
}
