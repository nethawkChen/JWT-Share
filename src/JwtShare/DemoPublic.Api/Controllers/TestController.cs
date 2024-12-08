using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

/// <summary>
/// 測試控制器
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class TestController : ControllerBase {
    /// <summary>
    /// 可接受來自Service A 和 B 的 Token 的端點
    /// </summary>
    /// <returns>測試訊息</returns>
    [HttpGet("both")]
    [Authorize(AuthenticationSchemes = "ServiceAScheme,ServiceBScheme")]
    public IActionResult GetForBoth() {
        return Ok(new { message = "This endpoint accepts tokens from both Service A and B", user = User.Identity?.Name });
    }

    /// <summary>
    /// 只接受來自Service A 的 Token 的端點
    /// </summary>
    /// <returns>測試訊息</returns>
    [HttpGet("serviceA")]
    [Authorize(AuthenticationSchemes = "ServiceAScheme")]
    public IActionResult GetForServiceA() {
        return Ok(new { message = "This endpoint only accepts tokens from Service A", user = User.Identity?.Name });
    }

    /// <summary>
    /// 只接受來自Service B 的 Token 的端點
    /// </summary>
    /// <returns>測試訊息</returns>
    [HttpGet("serviceB")]
    [Authorize(AuthenticationSchemes = "ServiceBScheme")]
    public IActionResult GetForServiceB() {
        return Ok(new { message = "This endpoint only accepts tokens from Service B", user = User.Identity?.Name });
    }
}