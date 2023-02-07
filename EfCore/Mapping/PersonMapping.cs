using Domain.PersonAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EfCore.Maps
{
    public class PersonMapping : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.ToTable("Person");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.FirstName).HasMaxLength(300).IsRequired();
            builder.Property(x => x.LastName).HasMaxLength(300).IsRequired();
            builder.Property(x => x.Bio).HasMaxLength(1000).IsRequired();

            builder.HasMany(x => x.Books)
                .WithOne(x => x.Person)
                .HasForeignKey(x => x.PersonId);
        }
    }
}
