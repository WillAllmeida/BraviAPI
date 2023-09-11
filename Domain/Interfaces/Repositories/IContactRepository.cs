using Domain.Entities;

namespace Domain.Interfaces.Repositories;

public interface IContactRepository
{
    Task<List<Contact>> GetContactList();
    Task<int> AddContact(Contact contact);
    Task<Contact> UpdateContact(Contact contactToUpdate);
    Task<bool> RemoveContact(int id);
    Task<Contact?> GetContactById(int id);
}

