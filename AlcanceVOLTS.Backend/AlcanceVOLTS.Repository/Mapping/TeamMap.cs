using AlcanceVOLTS.Domain.Models;
using AlcanceVOLTS.Repository.Config;
using AlcanceVOLTS.Repository.Mapping.Common;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlcanceVOLTS.Repository.Mapping
{
    internal class TeamMap : DbEntityConfiguration<Team>, IEntityMap
    {
        public override void Configure(EntityTypeBuilder<Team> entity)
        {
            entity.HasKey(x => x.Id);
            entity.Property(x => x.Id).ValueGeneratedOnAdd();
            entity.Property(x => x.Name).IsRequired();
            entity.Property(x => x.Dynamic).IsRequired();
            entity.HasOne(x => x.Event).WithMany(x => x.Teams).HasForeignKey(x => x.EventId);
            entity.HasMany(x => x.TeamAreas).WithOne(x => x.Team);
        }
    }
}
