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
    internal class EventMap : DbEntityConfiguration<Event>, IEntityMap
    {
        public override void Configure(EntityTypeBuilder<Event> entity)
        {
            entity.HasKey(x => x.Id);
            entity.Property(x => x.Id).ValueGeneratedOnAdd();
            entity.Property(x => x.Name).IsRequired();
            entity.Property(x => x.Observation);
            entity.Property(x => x.InitialDate).IsRequired();
            entity.Property(x => x.FinalDate).IsRequired();
            entity.Property(x => x.Button).IsRequired();
            entity.Property(x => x.Recurrent).IsRequired();
            entity.Property(x => x.Frequency);
            entity.Property(x => x.Status).IsRequired();
        }
    }
}
