using Domain.Entities;
using Domain.Interfaces.Repositories;
using Infrastructure.Configurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories;
public class ContactRepository : IContactRepository
{
    private readonly ContactBookContext _context;

    public ContactRepository(ContactBookContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }
    public async Task<List<Contact>> GetContactList()
    {
        var contacts = await _context.Contacts.ToListAsync();

        return contacts;
    }

    public async Task<int> AddContact(Contact contact)
    {
        await _context.Contacts.AddAsync(contact);
        await _context.SaveChangesAsync();

        return contact.Id;
    }

    public async Task<bool> RemoveContact(int id)
    {
        var contactToDelete = await _context.Contacts.SingleOrDefaultAsync(c => c.Id == id);
        if(contactToDelete is null)
        {
            return false;
        }
        
        _context.Contacts.Remove(contactToDelete);
        await _context.SaveChangesAsync();

        return true;
    }
}
