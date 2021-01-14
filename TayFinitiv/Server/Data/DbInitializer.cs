using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TayFinitiv.Database;

namespace TayFinitiv.Server.Data
{
    public static class DbInitializer
    {
        public static void Initialize(ApplicationDbContext context)
        {
            context.Database.EnsureCreated();
            context.SaveChanges();
        }
    }
}
