using Domain.Entities;
using Domain.Models;

namespace Domain.Interfaces.Services;

public interface IContactService
{
    Task<List<ContactResponse>> GetContactList();
    Task<int> CreateContact(CreateContactRequest newContact);
    Task<ContactResponse?> UpdateContact(UpdateContactRequest newData);
    Task<bool> DeleteContact(int id);
}

