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
    internal class EventUserMap : DbEntityConfiguration<EventUser>, IEntityMap
    {
        public override void Configure(EntityTypeBuilder<EventUser> entity)
        {
            entity.HasKey(x => x.Id);
            entity.Property(x => x.Id).ValueGeneratedOnAdd();
            entity.HasOne(x => x.Event).WithMany(x => x.EventUsers).HasForeignKey(x => x.EventId);
            entity.HasOne(x => x.Team).WithMany().HasForeignKey(x => x.TeamId);
            entity.HasOne(x => x.User).WithMany(x => x.EventUsers).HasForeignKey(x => x.UserId);
        }
    }
}
