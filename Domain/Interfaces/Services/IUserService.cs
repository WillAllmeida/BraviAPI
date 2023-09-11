using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Services;
public interface IUserService
{
    Task<List<UserResponse>> GetUserList();
    Task<int> CreateUser(CreateUserRequest newUser);
    Task<UserResponse?> UpdateUser(UpdateUserRequest newUser);
    Task<bool> DeleteUser(int id);
}
