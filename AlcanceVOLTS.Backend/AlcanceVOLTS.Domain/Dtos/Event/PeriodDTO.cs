using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlcanceVOLTS.Domain.Dtos.Event
{
    public class PeriodDTO
    {
        public PeriodDTO()
        {
        }

        public PeriodDTO(Models.Period period)
        {
            Description = period.Description;
            Snack = period.Snack;
            Date = period.Date;
        }

        public string Description { get; set; }
        public bool Snack { get; set; }
        public DateTime Date { get; set; }
    }
}
