using AlcanceVOLTS.Domain.Dtos.Event;
using AlcanceVOLTS.Domain.Enums;
using AlcanceVOLTS.Domain.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlcanceVOLTS.Domain.Models
{
    public class Event : EntityBase
    {
        public string Name { get; set; }
        public string? Observation { get; set; }
        public DateTime InitialDate { get; set; }
        public DateTime FinalDate { get; set; }
        public bool Button { get; set; }
        public bool Recurrent { get; set; }
        public EventFrequency? Frequency { get; set; }
        public EventStatus Status { get; set; }

        public virtual List<EventUser> EventUsers { get; set; }
        public virtual List<Team> Teams { get; set; }

        public static implicit operator Event(RegisterEventDTO eventDTO)
        {
            Event eventModel = new Event();

            if(eventDTO.Id != null)
                eventModel.Id = Guid.Parse(eventDTO.Id);
            eventModel.Name = eventDTO.Name;
            eventModel.Observation = eventDTO.Observation;
            eventModel.InitialDate = eventDTO.InitialDate;
            eventModel.FinalDate = eventDTO.FinalDate;
            eventModel.Button = eventDTO.Button;
            eventModel.Recurrent = eventDTO.Recurrent;
            eventModel.Frequency = eventDTO.Frequency;
            eventModel.Status = eventDTO.Status ?? EventStatus.Agendado;

            return eventModel;
        }
    }
}
