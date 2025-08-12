using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace VenueSyncWeb.Models
{
    public class VenueSyncDbContext : DbContext
    {
        public VenueSyncDbContext(DbContextOptions<VenueSyncDbContext> options) : base(options) { }
        public DbSet<User> Users { get; set; }
        public DbSet<Venue> Venues { get; set; }
        public DbSet<Headcount> Headcounts { get; set; }
    }
}