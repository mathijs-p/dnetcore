using dnetcore.Models;
using dnetcore.Models.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dnetcore.Data
{
    public class DbInitializer
    {
        public static void Initialize(MarketContext context)
        {
            context.Database.EnsureCreated();

            if(context.Users.Any())
            {
                return;
            }

            var users = new User[]
            {
                new User{ Username="Admin",     Password="test1234",    Role=Role.Administrator },
                new User{ Username="Seller",    Password="test1234",    Role=Role.Seller },
                new User{ Username="Consumer",  Password="test1234",    Role=Role.Consumer},
            };
            foreach(User u in users)
            {
                context.Users.Add(u);
            }
            context.SaveChanges();
        }
    }
}
