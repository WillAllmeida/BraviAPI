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

    public async Task<List<ContactListResponse>> GetContactList()
    {
        var contacts = _mapper.Map<List<ContactListResponse>>(await _contactRepository.GetContactList());

        return contacts;
    }
}

