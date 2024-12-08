/// <summary>
/// 登入請求的模型類別
/// </summary>
public class LoginRequest
{
    /// <summary>
    /// 使用者名稱
    /// </summary>
    public string Username { get; set; } = string.Empty;

    /// <summary>
    /// 使用者密碼
    /// </summary>
    public string Password { get; set; } = string.Empty;
} 