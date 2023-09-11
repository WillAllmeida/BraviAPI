using Application.Validators;
using Domain.Interfaces.Services;
using Domain.Models;
using Domain.Services;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace Application.Controllers;

[ApiController]
[Route("[controller]")]
public class ContactController : ControllerBase
{
    private readonly ILogger<ContactController> _logger;
    private readonly IContactService _contactService;
    private readonly IValidator<CreateContactRequest> _createContactValidator;
    private readonly IValidator<UpdateContactRequest> _updateContactValidator;

    public ContactController(ILogger<ContactController> logger, 
                                IContactService contactService,
                                IValidator<CreateContactRequest> createContactValidator,
                                IValidator<UpdateContactRequest> updateContactValidator)
    {
        _logger = logger;
        _contactService = contactService;
        _createContactValidator = createContactValidator;
        _updateContactValidator = updateContactValidator;
    }

    [HttpGet]
    public async Task<IActionResult> GetContacts()
    {
        var result = await _contactService.GetContactList();

        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> CreateContact([FromBody] CreateContactRequest request)
    {
        var validationResult = await _createContactValidator.ValidateAsync(request);

        if (!validationResult.IsValid)
        {
            return BadRequest(validationResult);
        }

        var result = await _contactService.CreateContact(request);

        return Ok(result);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateContact([FromBody] UpdateContactRequest request)
    {
        var validationResult = await _updateContactValidator.ValidateAsync(request);

        if (!validationResult.IsValid)
        {
            return BadRequest(validationResult);
        }

        var result = await _contactService.UpdateContact(request);

        if (result is null)
        {
            return UnprocessableEntity();
        }

        return Ok(result);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteContact([FromRoute] int id)
    {
        var result = await _contactService.DeleteContact(id);

        if (!result)
        {
            return UnprocessableEntity();
        }

        return Ok(result);
    }
}
