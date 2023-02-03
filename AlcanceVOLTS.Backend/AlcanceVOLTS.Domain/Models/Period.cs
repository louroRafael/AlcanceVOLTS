using AlcanceVOLTS.Domain.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlcanceVOLTS.Domain.Models
{
    public class Period : EntityBase
    {
        public Period()
        {

        }

        public Period(string description, DateTime date)
        {
            Description = description;
            Snack = false;
            Date = date;
        }

        public string Description { get; set; }
        public bool Snack { get; set; }
        public DateTime Date { get; set; }

        public Guid EventId { get; set; }
        public virtual Event Event { get; set; }
    }
}
