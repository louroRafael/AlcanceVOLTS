using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlcanceVOLTS.Domain.Dtos.Common
{
    public class FilterDTO
    {
        public int Page { get; set; } = 1;
        public int ItemsPerPage { get; set; } = 10;
        public string GeneralSearch { get; set; }
    }
}
