using Domain.Interfaces.Services;
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
}
