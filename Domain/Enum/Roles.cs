using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Enum
{
    public class Roles
    {
        public const string Admin = "Admin";
        public const string Client = "Client";
        public const string Manager = "Manager";
    }
    public enum RolesEnum
    {
        Admin,Client,Manager
    }
}
