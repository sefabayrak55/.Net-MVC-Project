using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repositories.EFCore.Config
{
    public class CategoryConfig : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(c => c.Id); // PK : Convention
            builder.Property(c => c.CategoryName).IsRequired();

            builder.Property(c => c.Description).HasDefaultValue("...");

            builder.HasData(
                new Category()
                {
                    Id = 1,
                    CategoryName = "Bilgisayar",
                    Description = "..."
                },
                new Category()
                {
                    Id = 2,
                    CategoryName = "SmartPhone",
                    Description = "..."
                },
                new Category()
                {
                    Id = 3,
                    CategoryName = "Electronic",
                    Description = "..."
                });
        }
    }
}
