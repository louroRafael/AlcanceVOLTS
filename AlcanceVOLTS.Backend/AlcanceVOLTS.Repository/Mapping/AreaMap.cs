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
    internal class AreaMap : DbEntityConfiguration<Area>, IEntityMap
    {
        public override void Configure(EntityTypeBuilder<Area> entity)
        {
            entity.HasKey(x => x.Id);
            entity.Property(x => x.Id).ValueGeneratedOnAdd();
            entity.Property(x => x.Name).IsRequired();
        }
    }
}
