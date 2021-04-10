using StoreKeeper.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace StoreKeeper.Data.Configurations
{
    public class ProductGroupConfiguration : IEntityTypeConfiguration<ProductGroup>
    {
        public void Configure(EntityTypeBuilder<ProductGroup> builder)
        {
            builder
                .HasKey(m => m.ID);

            builder
                .Property(m => m.ID)
                .UseIdentityColumn();
                
            builder
                .Property(m => m.Name)
                .IsRequired()
                .HasMaxLength(ProductGroup.NameMaxLength);
            
            builder
                .Property(m => m.Code)
                .IsRequired()
                .HasMaxLength(ProductGroup.CodeMaxLength);
            
            builder
                .Property(m => m.Description)
                .IsRequired()
                .HasMaxLength(ProductGroup.DescriptionMaxLength);
            
            builder
                .Property(m => m.IsVisible)
                .IsRequired()
                .HasDefaultValue(true);
            
            builder
                .HasMany(m => m.SubGroups)
                .WithOne(m => m.ProductGroup)
                .HasForeignKey(m => m.ProductGroupID)
                .OnDelete(DeleteBehavior.Restrict);
            
            builder
                .ToTable("ProductGroups");
        }
    }
}
