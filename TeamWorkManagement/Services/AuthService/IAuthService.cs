namespace TeamWorkManagement.Services.AuthService
{
    public interface IAuthService
    {
        Task<string> Login(UserLogin userLogin);
    }
}
