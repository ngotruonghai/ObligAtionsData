using ObligAtions.ViewModel;

namespace ObligAtions.Interface
{
    public interface ITokenRepository
    {
        Task<JwtTokenViewModel> GenerateJwtToken(UserLoginViewModel request);
    }
}
