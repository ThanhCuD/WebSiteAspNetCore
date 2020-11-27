using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Tadu.NetCore.Data.Model;

namespace Tadu.NetCore.Data.Model
{
    public class TaduDBContext : DbContext
    {
        public TaduDBContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
    }
}
