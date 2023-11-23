using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class UserRole
    {
        public int User_id { get; set; }
        public required User UserNavigation { get; set;}
        public int Role_id { get; set;}
        public required Role RoleNavigation { get; set;}  
    }
}