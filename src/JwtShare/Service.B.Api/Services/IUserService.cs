namespace Service.B.Api.Services {
    public interface IUserService {
        bool ValidateCredentials(string username, string password);
    }
}
