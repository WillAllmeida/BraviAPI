using Domain.Entities;
using Domain.Models;

namespace Domain.Interfaces.Services;

public interface IContactService
{
    Task<List<ContactListResponse>> GetContactList();
}

