using AlcanceVOLTS.Domain.Enums;
using AlcanceVOLTS.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlcanceVOLTS.Domain.Dtos.Event
{
    public class RegisterEventDTO
    {
        public Guid? Id { get; set; }
        public string Name { get; set; }
        public string Observation { get; set; }
        public DateTime InitialDate { get; set; }
        public DateTime FinalDate { get; set; }
        public bool Button { get; set; }
        public bool Tshirt { get; set; }
        public bool Recurrent { get; set; }
        public EventFrequency? Frequency { get; set; }
        public EventStatus? Status { get; set; }
        public int PeriodsQuantity { get; set; }
        public List<Period> Periods { get; set; }
    }
}
