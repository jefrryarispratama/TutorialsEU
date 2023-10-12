using Microsoft.EntityFrameworkCore;

namespace TutorialsEU.Models
{
	public class MyDbContext : DbContext	
	{
        // property
        public DbSet<Person> People { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("MyDb");
        }   

    }
}
