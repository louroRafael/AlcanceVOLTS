using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlcanceVOLTS.Domain.Dtos.Common
{
    public class FailDTO
    {
        public FailDTO(Exception ex)
        {
            Message = ex.Message;
            StackTrace = ex.StackTrace;
            Details = ex.ToString();
        }

        public string Message { get; set; }
        public string StackTrace { get; set; }
        public string Details { get; set; }
    }
}
