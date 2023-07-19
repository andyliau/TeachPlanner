﻿using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

public class ErrorsController : ControllerBase
{
    [Route("/error")]
    public IActionResult Error()
    {
        Exception? e = HttpContext.Features.Get<IExceptionHandlerFeature>()?.Error;

        return Problem(e?.Message);
    }
}
