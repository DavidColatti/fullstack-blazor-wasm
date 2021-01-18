using System;
using Microsoft.EntityFrameworkCore;
using fullstackblazorwasm.Shared;

namespace fullstackblazorwasm.Server.Models
{
    public class UserContext : DbContext
    {
        public UserContext(DbContextOptions<UserContext> options) : base(options) { }
        public DbSet<User> Users { get; set; }
    }
}
