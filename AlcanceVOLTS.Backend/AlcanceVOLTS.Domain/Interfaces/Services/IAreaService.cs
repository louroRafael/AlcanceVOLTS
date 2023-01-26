using AlcanceVOLTS.Domain.Dtos.Common;
using AlcanceVOLTS.Domain.Dtos.Event;
using AlcanceVOLTS.Domain.Interfaces.Common;
using AlcanceVOLTS.Domain.Models;

namespace AlcanceVOLTS.Domain.Interfaces.Services
{
    public interface IAreaService : ICrudServiceBase<Area>
    {
        ///<summary> Get List Of Areas By Filter </summary>
        Task<List<Area>> GetAllByFilter(FilterDTO filter);
    }
}
