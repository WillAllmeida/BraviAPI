using Domain.Interfaces.Services;
using Domain.Models;
using Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace Application.Controllers;

[ApiController]
[Route("[controller]")]
public class ContactController : ControllerBase
{
    private readonly ILogger<ContactController> _logger;
    private readonly IContactService _contactService;

    public ContactController(ILogger<ContactController> logger, IContactService contactService)
    {
        _logger = logger;
        _contactService = contactService;
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
        var result = await _contactService.CreateContact(request);

        return Ok(result);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateContact([FromBody] UpdateContactRequest request)
    {
        var result = await _contactService.UpdateContact(request);

        if (result is null)
        {
            return BadRequest();
        }

        return Ok(result);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteContact([FromRoute] int id)
    {
        var result = await _contactService.DeleteContact(id);

        if (!result)
        {
            //TODO fix status
            return BadRequest();
        }

        return Ok(result);
    }
}
