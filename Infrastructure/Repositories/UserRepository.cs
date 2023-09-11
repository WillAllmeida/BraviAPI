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
public class UserRepository : IUserRepository
{
    private readonly ContactBookContext _context;

    public UserRepository(ContactBookContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public async Task<int> AddUser(User user)
    {
        await _context.Users.AddAsync(user);
        await _context.SaveChangesAsync();

        return user.Id;
    }

    public async Task<User> UpdateUser(User userToUpdate)
    {
        _context.Users.Update(userToUpdate);
        await _context.SaveChangesAsync();

        return userToUpdate;
    }

    public async Task<List<User>> GetUserList()
    {
        var users = await _context.Users.Include(u => u.Contacts).ToListAsync();

        return users;
    }

    public async Task<User?> GetUserById(int id)
    {
        return await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
    }

    public async Task<bool> RemoveUser(int id)
    {
        var userToDelete = await _context.Users.SingleOrDefaultAsync(c => c.Id == id);
        if (userToDelete is null)
        {
            return false;
        }

        _context.Users.Remove(userToDelete);
        await _context.SaveChangesAsync();

        return true;
    }
}
