using Microsoft.EntityFrameworkCore;

namespace AlcanceVOLTS.Repository.Config
{
    public interface IDbEntityConfiguration
    {
        void Configure(ModelBuilder modelBuilder);
    }
}
