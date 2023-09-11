using AutoMapper;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services;
public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;
    public UserService(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<int> CreateUser(CreateUserRequest newUser)
    {
        return await _userRepository.AddUser(_mapper.Map<User>(newUser));
    }

    public async Task<UserResponse?> UpdateUser(UpdateUserRequest newData)
    {
        var existingUser = await _userRepository.GetUserById(newData.Id);
        if(existingUser == null)
        {
            return null;
        }

        existingUser.Name = newData.Name;

        return _mapper.Map<UserResponse>(await _userRepository.UpdateUser(existingUser));
    }

    public async Task<bool> DeleteUser(int id)
    {
        return await _userRepository.RemoveUser(id);
    }

    public async Task<List<UserResponse>> GetUserList()
    {
        var users = _mapper.Map<List<UserResponse>>(await _userRepository.GetUserList());

        return users;
    }
}
