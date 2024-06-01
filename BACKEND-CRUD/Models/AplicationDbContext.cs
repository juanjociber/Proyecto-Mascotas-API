using Microsoft.EntityFrameworkCore;

namespace BACKEND_CRUD.Models
{
    public class AplicationDbContext : DbContext
    {
        public AplicationDbContext(DbContextOptions<AplicationDbContext>options) : base(options) 
        { 
        }


        public DbSet<Mascota> Mascotas { get; set; }

    }
}
