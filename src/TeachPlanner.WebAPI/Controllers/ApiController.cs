using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TeachPlanner.Api.Controllers;

[ApiController]
[Authorize]
public abstract class ApiController : ControllerBase
{
}
