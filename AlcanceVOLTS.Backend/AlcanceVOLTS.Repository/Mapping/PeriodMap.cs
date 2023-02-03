using AlcanceVOLTS.Domain.Models;
using AlcanceVOLTS.Repository.Config;
using AlcanceVOLTS.Repository.Mapping.Common;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlcanceVOLTS.Repository.Mapping
{
    internal class PeriodMap : DbEntityConfiguration<Period>, IEntityMap
    {
        public override void Configure(EntityTypeBuilder<Period> entity)
        {
            entity.HasKey(x => x.Id);
            entity.Property(x => x.Id).ValueGeneratedOnAdd();
            entity.Property(x => x.Description).IsRequired();
            entity.Property(x => x.Snack).IsRequired();
            entity.Property(x => x.Date).IsRequired();
            entity.HasOne(x => x.Event).WithMany(x => x.Periods).HasForeignKey(x => x.EventId);
        }
    }
}
