using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TaskManager_server.Domain;

namespace TaskManager_server.Data
{
    public class ReadDbContext : DbContext
    {
        public DbSet<TaskItem> Tasks { get; set; }

        public ReadDbContext(DbContextOptions<ReadDbContext> options) : base(options) { }
    }
}