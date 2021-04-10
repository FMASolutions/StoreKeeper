using StoreKeeper.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace StoreKeeper.Data.Configurations
{
    public class SubGroupConfiguration : IEntityTypeConfiguration<SubGroup>
    {        
        public void Configure(EntityTypeBuilder<SubGroup> builder)
        {
            builder
                .HasKey(m => m.ID);

            builder
                .Property(m => m.ID)
                .UseIdentityColumn();
                
            builder
                .Property(m => m.Name)
                .IsRequired()
                .HasMaxLength(SubGroup.NameMaxLength);
            
            builder
                .Property(m => m.Code)
                .IsRequired()
                .HasMaxLength(SubGroup.CodeMaxLength);

            builder
                .Property(m => m.Description)
                .HasMaxLength(SubGroup.DescriptionMaxLength);
            
            builder
                .Property(m => m.IsVisible)
                .IsRequired()
                .HasDefaultValue(true);

            builder
                .HasOne(m => m.ProductGroup)
                .WithMany(a => a.SubGroups)
                .HasForeignKey(m => m.ProductGroupID)
                .OnDelete(DeleteBehavior.Restrict);
            
            builder
                .ToTable("SubGroups");
        }
    }
}
