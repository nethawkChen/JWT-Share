/// <summary>
/// JWT設定的模型類別
/// </summary>
public class JwtSettings
{
    /// <summary>
    /// 用於簽署和驗證JWT的安全密鑰
    /// </summary>
    public string SecurityKey { get; set; } = string.Empty;

    /// <summary>
    /// JWT的發行者
    /// </summary>
    public string ValidIssuer { get; set; } = string.Empty;

    /// <summary>
    /// JWT的目標接收者
    /// </summary>
    public string ValidAudience { get; set; } = string.Empty;

    /// <summary>
    /// JWT的有效期限(分鐘)
    /// </summary>
    public int ExpiryInMinutes { get; set; }
} 