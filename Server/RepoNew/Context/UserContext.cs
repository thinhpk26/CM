using Repo.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repo.Context
{
    public class UserContext
    {
        public string ID { get; set; }
        public string? FullName { get; set; }
        public string Avatar { get; set; }
        public string? UserCode { get; set; }
        public string PhoneNumber { get; set; }
        public string PositionName { get; set; }
        public long RoleID { get; set; }
        public string RoleName { get; set; }
        public UserPlatForm UserPlatform { get; set; }
    }
}
