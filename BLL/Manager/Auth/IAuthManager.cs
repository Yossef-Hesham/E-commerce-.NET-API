using DAL.system;

namespace BLL.System
{
    public interface IAuthManager
    {
        Task<User?> RegisterAnync(UserDto request);
        Task<TokenResponseDto?> LoginAnync(UserDto request);
        Task<TokenResponseDto?> RefreshTokenAsync(RefreshTokenDto request);

        public Guid GetUserId();


    }
}
