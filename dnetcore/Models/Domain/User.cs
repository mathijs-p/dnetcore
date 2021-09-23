using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dnetcore.Models.DomainModels
{
    public enum Role
    {
        Consumer = 0,
        Seller = 1,
        Administrator = 2,
    }

    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public Role Role { get; set; }
        public List<Store?> Stores { get; set; }
        public bool IsDeleted { get; set; }
    }
}
