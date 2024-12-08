namespace Service.B.Api.Services {
    public class UserService : IUserService {
        private readonly Dictionary<string, string> _users = new() {
            { "tester2", "b12345" }
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
    }
}
