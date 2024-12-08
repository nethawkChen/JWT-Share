namespace JwtAuth.Common.Services {
    /// <summary>
    /// JWT認證服務的介面
    /// </summary>
    public interface IJwtAuthService {
        /// <summary>
        /// 產生JWT Token
        /// </summary>
        /// <param name="username">使用者名稱</param>
        /// <param name="roles">使用者角色清單</param>
        /// <returns>JWT Token字串</returns>
        string GenerateToken(string username, string[] roles);
    }
}