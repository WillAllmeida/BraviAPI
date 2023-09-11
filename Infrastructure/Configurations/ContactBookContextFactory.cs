using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Configurations;
public class ContactBookContextFactory : IDesignTimeDbContextFactory<ContactBookContext>
{
    public ContactBookContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<ContactBookContext>();
        optionsBuilder.UseSqlite("Data Source=../contactbook.db");

        return new ContactBookContext(optionsBuilder.Options);
    }
}
