using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace AlcanceVOLTS.Repository.Config
{
    internal abstract class DbEntityConfiguration<TEntity> : IDbEntityConfiguration<TEntity> where TEntity : class
    {
        public abstract void Configure(EntityTypeBuilder<TEntity> entity);
        public void Configure(ModelBuilder modelBuilder) => Configure(modelBuilder.Entity<TEntity>());
    }
}
