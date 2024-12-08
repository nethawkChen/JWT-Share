/*
 *  Description: �ϥΪ����ҪA��
 *       Author: Kevin
 *  Create Date: 2024.12.06
 */

namespace Service.A.Api.Services {
    public class UserService : IUserService {
        /// <summary>
        /// �����ϥΪ̸��
        /// </summary>
        private readonly Dictionary<string, string> _users = new() {
            { "tester1", "a12345" }
        };

        /// <summary>
        /// ���ҨϥΪ�
        /// ��@�ɧאּ�P��Ʈw���� user ����
        /// </summary>
        /// <param name="username">�b��</param>
        /// <param name="password">�K�X</param>
        /// <returns></returns>
        public bool ValidateCredentials(string username, string password) {
            return _users.TryGetValue(username, out var storedPassword) && storedPassword == password;
        }

        ///// <summary>
        ///// �@��ϥΪ̸�Ʒ|�x�s�b��Ʈw, �o��u�O�����q��ƮwŪ������
        ///// </summary>
        //private readonly IConfiguration _configuration;
        //private readonly DbContext _dbContext;

        //public UserService(IConfiguration configuration, DbContext dbContext) {
        //    _configuration = configuration;
        //    _dbContext = dbContext;
        //}

        ///// <summary>
        ///// ���ҨϥΪ�
        ///// </summary>
        ///// <param name="username">�b��</param>
        ///// <param name="password">�K�X</param>
        ///// <returns></returns>
        //public async Task<bool> ValidateCredentials(string username, string password) {
        //    var user = await _dbContext.Users.FirstOrDefaultAsync(u => u.Username == username);

        //    if (user == null) return fasle;

        //    return user.Password == password;
        //}
    }
}