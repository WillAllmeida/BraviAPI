using Domain.Entities;

namespace Domain.Interfaces.Repositories;

public interface IContactRepository
{
    Task<List<Contact>> GetContactList();
    Task<int> AddContact(Contact contact);
}

