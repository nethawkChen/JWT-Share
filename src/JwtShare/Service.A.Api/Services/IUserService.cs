namespace Service.A.Api.Services {
    public interface IUserService {
        /// <summary>
        /// 驗證使用者
        /// </summary>
        /// <param name="username">帳號</param>
        /// <param name="password">密碼</param>
        /// <returns></returns>
        bool ValidateCredentials(string username, string password);
    }
}