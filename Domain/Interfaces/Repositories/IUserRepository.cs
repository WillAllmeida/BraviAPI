using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Repositories;
public interface IUserRepository
{
    Task<List<User>> GetUserList();
    Task<int> AddUser(User user);
    Task<bool> RemoveUser(int id);
}
