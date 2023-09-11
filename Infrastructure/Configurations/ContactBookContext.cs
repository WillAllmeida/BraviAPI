using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Configurations;
public class ContactBookContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Contact> Contacts { get; set; }

    public ContactBookContext(DbContextOptions<ContactBookContext> options) : base(options)
    {
        Database.EnsureCreated();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        // connect to sqlite database
        options.UseSqlite("Data Source=../contactbook.db");
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>()
            .HasMany<Contact>(u => u.Contacts)
            .WithOne(c => c.User)
            .HasForeignKey(u => u.UserId)
            .IsRequired();

        base.OnModelCreating(modelBuilder);
    }
}
