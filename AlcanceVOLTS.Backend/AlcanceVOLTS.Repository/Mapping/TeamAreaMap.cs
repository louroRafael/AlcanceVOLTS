﻿using AlcanceVOLTS.Domain.Models;
using AlcanceVOLTS.Repository.Config;
using AlcanceVOLTS.Repository.Mapping.Common;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AlcanceVOLTS.Repository.Mapping
{
    internal class TeamAreaMap : DbEntityConfiguration<TeamArea>, IEntityMap
    {
        public override void Configure(EntityTypeBuilder<TeamArea> entity)
        {
            entity.HasKey(x => x.Id);
            entity.Property(x => x.Id).ValueGeneratedOnAdd();
            entity.HasOne(x => x.Team).WithMany(x => x.TeamAreas).HasForeignKey(x => x.TeamId);
            entity.HasOne(x => x.Area).WithMany().HasForeignKey(x => x.AreaId);
            entity.HasOne(x => x.Period).WithMany().HasForeignKey(x => x.PeriodId);
        }
    }
}
