using AlcanceVOLTS.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlcanceVOLTS.Domain.Dtos.User
{
    public class UserDTO
    {
        public UserDTO()
        {

        }

        public UserDTO(Models.User user)
        {
            this.Id = user.Id.ToString();
            this.Name = user.Name;
            this.Login = user.Login;
            this.Active = user.Active ? "Ativo" : "Não Ativo";
            this.UserType = user.UserType;
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public string Login { get; set; }
        public string Active { get; set; }
        public UserType UserType { get; set; }
    }
}
