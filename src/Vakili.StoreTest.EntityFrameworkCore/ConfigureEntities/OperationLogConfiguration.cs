using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Vakili.StoreTest.Entities;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace Vakili.StoreTest.ConfigureEntities
{
    class OperationLogConfiguration : IEntityTypeConfiguration<OperationLog>
    {
        public void Configure(EntityTypeBuilder<OperationLog> builder)
        {
            builder.ToTable(StoreTestConsts.DbTablePrefix + nameof(OperationLog) + "s", StoreTestConsts.DbSchema);
            builder.ConfigureByConvention();
        }
    }
}
