/*
 *  Description: 使用者驗證服務
 *       Author: Kevin
 *  Create Date: 2024.12.06
 */

namespace Service.A.Api.Services {
    public class UserService : IUserService {
        /// <summary>
        /// 模擬使用者資料
        /// </summary>
        private readonly Dictionary<string, string> _users = new() {
            { "tester1", "a12345" }
        };

        /// <summary>
        /// 驗證使用者
        /// 實作時改為與資料庫中的 user 驗證
        /// </summary>
        /// <param name="username">帳號</param>
        /// <param name="password">密碼</param>
        /// <returns></returns>
        public bool ValidateCredentials(string username, string password) {
            return _users.TryGetValue(username, out var storedPassword) && storedPassword == password;
        }

        ///// <summary>
        ///// 一般使用者資料會儲存在資料庫, 這邊只是模擬從資料庫讀取驗證
        ///// </summary>
        //private readonly IConfiguration _configuration;
        //private readonly DbContext _dbContext;

        //public UserService(IConfiguration configuration, DbContext dbContext) {
        //    _configuration = configuration;
        //    _dbContext = dbContext;
        //}

        ///// <summary>
        ///// 驗證使用者
        ///// </summary>
        ///// <param name="username">帳號</param>
        ///// <param name="password">密碼</param>
        ///// <returns></returns>
        //public async Task<bool> ValidateCredentials(string username, string password) {
        //    var user = await _dbContext.Users.FirstOrDefaultAsync(u => u.Username == username);

        //    if (user == null) return fasle;

        //    return user.Password == password;
        //}
    }
}