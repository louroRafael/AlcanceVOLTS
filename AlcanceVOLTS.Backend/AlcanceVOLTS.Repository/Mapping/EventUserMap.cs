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
            entity.Property(x => x.TeamLeader);
            entity.Property(x => x.Button);
            entity.Property(x => x.Tshirt);
            entity.Property(x => x.TshirtSize);
            entity.Property(x => x.Wristband);
            entity.Property(x => x.Badge);
            entity.Property(x => x.BadgeLabel);
            entity.Property(x => x.WalkieTalkie);
            entity.Property(x => x.WalkieTalkieNumber);
            entity.Property(x => x.CheckIn);
            entity.HasOne(x => x.Event).WithMany(x => x.EventUsers).HasForeignKey(x => x.EventId);
            entity.HasOne(x => x.Team).WithMany().HasForeignKey(x => x.TeamId);
            entity.HasOne(x => x.User).WithMany(x => x.EventUsers).HasForeignKey(x => x.UserId);
        }
    }
}
