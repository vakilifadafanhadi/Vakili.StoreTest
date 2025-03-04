using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Vakili.StoreTest.Entities;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace Vakili.StoreTest.ConfigureEntities
{
    class ProductEntityConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable(StoreTestConsts.DbTablePrefix +
                nameof(Product) + "s",
                t =>
                {
                    t.HasCheckConstraint("CK_Product_Level", "[Level] < 4");
                });
            builder.ConfigureByConvention();
            builder.
                HasOne(product => product.Parent).
                WithMany(product => product.Children).
                HasForeignKey(product => product.ParentId).
                OnDelete(DeleteBehavior.Restrict);
        }
    }
}
