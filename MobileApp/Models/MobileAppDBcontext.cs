using Microsoft.EntityFrameworkCore;

namespace MobileApp.Models
{
    public class MobileAppDBcontext: DbContext
    {
        public MobileAppDBcontext(DbContextOptions<MobileAppDBcontext> options): base(options) { }
        public DbSet<Staff> Staffs { get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}
