using Domain.BookAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EfCore.Maps
{
    public class BookMapping : IEntityTypeConfiguration<Book>
    {

        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.ToTable("Person");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).HasMaxLength(300).IsRequired();
            builder.Property(x => x.UnitPrice).HasMaxLength(300).IsRequired();
            builder.Property(x => x.BookFile).HasMaxLength(1000).IsRequired();
            builder.Property(x => x.NumberOfPage).HasMaxLength(5000).IsRequired();
            builder.Property(x => x.Description).HasMaxLength(1000).IsRequired();

            builder.HasOne(x => x.Person)
                .WithMany(x => x.Books)
                .HasForeignKey(x => x.PersonId);
        }
    }
}
