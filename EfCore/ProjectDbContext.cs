using Domain.BookAggregate;
using Domain.PersonAggregate;
using Microsoft.EntityFrameworkCore;

namespace EfCore
{
    public class ProjectDbContext : DbContext
    {
        public ProjectDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Person>? Person { get; set; }
        public DbSet<Book>? Book { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var personAssembly = typeof(Person).Assembly;
            modelBuilder.ApplyConfigurationsFromAssembly(personAssembly);
            var bookAssembly = typeof(Book).Assembly;
            modelBuilder.ApplyConfigurationsFromAssembly(bookAssembly);


            base.OnModelCreating(modelBuilder);
        }
    }
}
