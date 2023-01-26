using AlcanceVOLTS.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlcanceVOLTS.Domain.Dtos.Event
{
    public class RegisterEventDTO
    {
        public string? Id { get; set; }
        public string Name { get; set; }
        public string Observation { get; set; }
        public DateTime InitialDate { get; set; }
        public DateTime FinalDate { get; set; }
        public bool Button { get; set; }
        public bool Recurrent { get; set; }
        public EventFrequency? Frequency { get; set; }
        public EventStatus? Status { get; set; }

    }
}
