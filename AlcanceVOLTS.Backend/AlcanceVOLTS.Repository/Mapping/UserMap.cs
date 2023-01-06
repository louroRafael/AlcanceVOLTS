using AlcanceVOLTS.Domain.Models;
using AlcanceVOLTS.Repository.Config;
using AlcanceVOLTS.Repository.Mapping.Common;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AlcanceVOLTS.Repository.Mapping
{
    internal class UserMap : DbEntityConfiguration<User>, IEntityMap
    {
        public override void Configure(EntityTypeBuilder<User> entity)
        {
            entity.HasKey(x => x.Id);
            entity.Property(x => x.Id).ValueGeneratedOnAdd();
            entity.Property(x => x.Name).IsRequired();
            entity.Property(x => x.Login).IsRequired();
            entity.Property(x => x.Password).IsRequired();
            entity.Property(x => x.Active).IsRequired();
            entity.Property(x => x.UserType).IsRequired();
        }
    }
}
