using AlcanceVOLTS.Domain.Enums;
using AlcanceVOLTS.Domain.Infra.Helpers;
using AlcanceVOLTS.Domain.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlcanceVOLTS.Domain.Models
{
    public class User : EntityBase
    {
        public User(string name, string login)
        {
            Name = name;
            Login = login;
            Password = ("volts").ToMD5();
            Active = true;
            UserType = UserType.Voluntario;
        }

        public string Name { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public bool Active { get; set; }
        public UserType UserType { get; set; }

        public virtual List<EventUser> EventUsers { get; set; }
    }
}
