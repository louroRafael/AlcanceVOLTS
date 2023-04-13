using AlcanceVOLTS.Domain.Models;
using AlcanceVOLTS.Repository.Config;
using AlcanceVOLTS.Repository.Mapping.Common;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AlcanceVOLTS.Repository.Mapping
{
    internal class SnackMap : DbEntityConfiguration<Snack>, IEntityMap
    {
        public override void Configure(EntityTypeBuilder<Snack> entity)
        {
            entity.HasKey(x => x.Id);
            entity.Property(x => x.Id).ValueGeneratedOnAdd();
            entity.HasOne(x => x.Period).WithMany().HasForeignKey(x => x.PeriodId);
            entity.HasOne(x => x.EventUser).WithMany(x => x.Snacks).HasForeignKey(x => x.EventUserId);
        }
    }
}
