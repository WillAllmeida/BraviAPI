using AutoMapper;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using Domain.Models;

namespace Domain.Services;

public class ContactService : IContactService
{
    private readonly IContactRepository _contactRepository;
    private readonly IMapper _mapper;
    public ContactService(IContactRepository contactRepository, IMapper mapper) { 
        _contactRepository = contactRepository;
        _mapper = mapper;
    }

    public async Task<List<ContactResponse>> GetContactList()
    {
        var contacts = _mapper.Map<List<ContactResponse>>(await _contactRepository.GetContactList());

        return contacts;
    }

    public async Task<int> CreateContact(CreateContactRequest newContact)
    {
        return await _contactRepository.AddContact(_mapper.Map<Contact>(newContact));
    }

    public async Task<bool> DeleteContact(int id)
    {
        return await _contactRepository.RemoveContact(id);
    }

    public async Task<ContactResponse?> UpdateContact(UpdateContactRequest newData)
    {
        var existingContact = await _contactRepository.GetContactById(newData.Id);
        if (existingContact == null)
        {
            return null;
        }

        existingContact.Value = newData.Value;
        existingContact.Type = newData.Type;

        return _mapper.Map<ContactResponse>(await _contactRepository.UpdateContact(existingContact));
    }
}

