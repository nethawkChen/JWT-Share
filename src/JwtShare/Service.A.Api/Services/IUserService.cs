namespace Service.A.Api.Services {
    public interface IUserService {
        /// <summary>
        /// ���ҨϥΪ�
        /// </summary>
        /// <param name="username">�b��</param>
        /// <param name="password">�K�X</param>
        /// <returns></returns>
        bool ValidateCredentials(string username, string password);
    }
}