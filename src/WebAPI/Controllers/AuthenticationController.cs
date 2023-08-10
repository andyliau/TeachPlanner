﻿using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MapsterMapper;
using Application.Authentication.Commands.Register;
using Application.Common.Errors;
using Contracts.Authentication;
using FluentValidation;
using Application.Authentication.Queries.Login;

namespace WebAPI.Controllers;

[Route("auth")]
[AllowAnonymous]
public class AuthenticationController : ApiController
{
    private readonly ISender _sender;
    private readonly IValidator<RegisterCommand> _registerValidator;
    private readonly IValidator<LoginQuery> _loginValidator;
    private readonly IMapper _mapper;

    public AuthenticationController(IMapper mapper, ISender sender,
        IValidator<RegisterCommand> registerValidator, IValidator<LoginQuery> loginValidator)
    {
        _mapper = mapper;
        _sender = sender;
        _registerValidator = registerValidator;
        _loginValidator = loginValidator;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterRequest request)
    {
        var command = _mapper.Map<RegisterCommand>(request);

        var validationResult = await _registerValidator.ValidateAsync(command);

        var authResult = await _sender.Send(command);



        return authResult.Match(
            authResult => Ok(_mapper.Map<AuthenticationResponse>(authResult)),
            errors => Problem(errors));
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginRequest request)
    {
        var query = _mapper.Map<LoginQuery>(request);
        var validationResult = await _loginValidator.ValidateAsync(query);

        var authenticationResult = await _sender.Send(query);

        if (authenticationResult.IsError && authenticationResult.FirstError == Errors.Authentication.InvalidCredentials)
        {
            return Problem(
                statusCode: StatusCodes.Status401Unauthorized,
                title: authenticationResult.FirstError.Description);

        }

        return authenticationResult.Match(
            authResult => Ok(_mapper.Map<AuthenticationResponse>(authResult)),
            errors => Problem(errors));
    }
}
