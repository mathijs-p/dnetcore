using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace dnetcore.Models.DomainModels
{
    public class Store
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Product> Products { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
