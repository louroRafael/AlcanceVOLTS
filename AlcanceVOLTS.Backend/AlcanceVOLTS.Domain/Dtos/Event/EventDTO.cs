using AlcanceVOLTS.Domain.Enums;
using AlcanceVOLTS.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlcanceVOLTS.Domain.Dtos.Event
{
    public class EventDTO
    {
        public EventDTO()
        {
        }

        public EventDTO(Models.Event eventModel) 
        {
            Id = eventModel.Id.ToString();
            Name = eventModel.Name;
            Observation = eventModel.Observation ?? "";
            InitialDate = eventModel.InitialDate.ToString("dd/MM/yyyy");
            FinalDate = eventModel.FinalDate.ToString("dd/MM/yyyy");
            Button = eventModel.Button ? "Sim" : "Não";
            Recurrent = eventModel.Recurrent ? "Sim" : "Não";
            Frequency = eventModel.Frequency;
            Status = eventModel.Status;
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public string Observation { get; set; }
        public string InitialDate { get; set; }
        public string FinalDate { get; set; }
        public string Button { get; set; }
        public string Recurrent { get; set; }
        public EventFrequency? Frequency { get; set; }
        public EventStatus Status { get; set; }

    }
}
