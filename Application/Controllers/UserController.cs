using Domain.Interfaces.Services;
using Domain.Models;
using Domain.Services;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Application.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private readonly ILogger<UserController> _logger;
    private readonly IUserService _userService;
    private readonly IValidator<CreateUserRequest> _createUserValidator;
    private readonly IValidator<UpdateUserRequest> _updateUserValidator;

    public UserController(ILogger<UserController> logger, 
                            IUserService userService,
                            IValidator<CreateUserRequest> createUserValidator,
                            IValidator<UpdateUserRequest> updateUserValidator)
    {
        _logger = logger;
        _userService = userService;
        _createUserValidator = createUserValidator;
        _updateUserValidator = updateUserValidator;
    }

    [HttpGet]
    public async Task<IActionResult> GetUsers()
    {
        var result = await _userService.GetUserList();

        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> CreateUser([FromBody] CreateUserRequest request)
    {
        var validationResult = await _createUserValidator.ValidateAsync(request);

        if(!validationResult.IsValid)
        {
            return BadRequest(validationResult);
        }

        var result = await _userService.CreateUser(request);

        return Ok(result);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateUser([FromBody] UpdateUserRequest request)
    {
        var validationResult = await _updateUserValidator.ValidateAsync(request);

        if (!validationResult.IsValid)
        {
            return BadRequest(validationResult);
        }

        var result = await _userService.UpdateUser(request);

        if(result is null)
        {
            return UnprocessableEntity();
        }

        return Ok(result);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteUser([FromRoute] int id)
    {
        var result = await _userService.DeleteUser(id);

        if (!result)
        {
            return UnprocessableEntity();
        }

        return Ok(result);
    }
}
