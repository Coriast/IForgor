using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IForgor.API.Controllers;

[Route("[controller]")]
public class DesksController : ApiController
{

    [HttpGet]
    public IActionResult ListDesks()
    {
        return Ok(Array.Empty<string>());
    }
}
