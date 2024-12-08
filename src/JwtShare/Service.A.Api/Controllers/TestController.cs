using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class TestController : ControllerBase {
    [HttpGet]
    public IActionResult Get() {
        return Ok(new { message = "Hello from Service A!", user = User.Identity?.Name });
    }
}