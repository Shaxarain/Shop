﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using DBs.DB;
using Shop.Funcs.Entities;

namespace Shop.Funcs.EF
{
    public class ApplicationContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationContext(string conectionString) : base(conectionString)
        {
        }
        public DbSet<ClientProfile> ClientProfiles { get; set; }
    }
}
