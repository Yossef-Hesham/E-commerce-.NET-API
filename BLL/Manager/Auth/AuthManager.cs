using DAL.Context;
using DAL.system;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.Http;



namespace BLL.System
{
    public class AuthManager : IAuthManager
    {
        private readonly AppDbContext _context;
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AuthManager(AppDbContext context, IConfiguration configuration, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _configuration = configuration;
            _httpContextAccessor = httpContextAccessor;
        }


        public Guid GetUserId()
        {
            var userId = _httpContextAccessor.HttpContext?
                .User?
                .FindFirstValue(ClaimTypes.NameIdentifier);

            if (!Guid.TryParse(userId, out var guid))
                throw new Exception("User not authenticated");

            return guid;
        }
        public async Task<User?> RegisterAnync(UserDto request)
        {
            if(await _context.Users.AnyAsync(e => e.Name == request.Name))
            {
                return null;            
            }


            var user = new User();
            var PassHash = new PasswordHasher<User>().HashPassword(user, request.password);


            user.Name = request.Name;
            user.password = PassHash;
            await _context.Users.AddAsync(user);


            // need to put at UnitOfWork Folder
            await _context.SaveChangesAsync();


            return user;

        }
    
        public async Task<TokenResponseDto?> LoginAnync(UserDto request)
        {
            var user = await _context.Users.FirstOrDefaultAsync(e => e.Name == request.Name);

            if (user is null)
            {
                return null;
            }

            if (new PasswordHasher<User>().VerifyHashedPassword(user, user.password, request.password) == PasswordVerificationResult.Failed)
            {
                return null;

            }

            var Tokens = new TokenResponseDto {
                AccessToken = GenerateToken(user),
                RefreshToken = await GenerateRefrestTokenUser(user)
            
            };

            return Tokens;
        }


        private async Task<User?> ValidateRefreshTokenAsync(Guid UserId, string RT)
        {
            var user = await _context.Users.FindAsync(UserId);
            if (user is null) 
                return null;

            if (user.RefreshToken != RT || user.RefreshTokenTime <= DateTime.Now)
                return null;

            return user;
        }
        public async Task<TokenResponseDto?> RefreshTokenAsync(RefreshTokenDto request)
        {
            var user = await ValidateRefreshTokenAsync(request.UserId, request.RefreshToken);


            if (user is null)
                return null;

            var Tokens = new TokenResponseDto
            {
                AccessToken = GenerateToken(user),
                RefreshToken = await GenerateRefrestTokenUser(user)
            };

            return Tokens;
        }


        private string GenerateToken(User user)
        {

            var Claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Name),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Role, user.Role)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetValue<string>("AppSettings:Token")!));


            var crads = new SigningCredentials(key, SecurityAlgorithms.HmacSha512);

            var tokenDesc = new JwtSecurityToken(
                issuer: _configuration.GetValue<string>("AppSettings:Issuer"),
                audience: _configuration.GetValue<string>("AppSettings:Audience"),
                claims: Claims,
                signingCredentials: crads,
                expires: DateTime.UtcNow.AddDays(1)
                );

            return new JwtSecurityTokenHandler().WriteToken(tokenDesc);
        }
         

        private string GenerateRefreshToken()
        {
            var RandomValues = new byte[32];

            using var random =  RandomNumberGenerator.Create();
            random.GetBytes(RandomValues);

            return Convert.ToBase64String(RandomValues);
        }


        private async Task<string> GenerateRefrestTokenUser(User user)
        {
            var RT = GenerateRefreshToken();
            user.RefreshToken = RT;
            user.RefreshTokenTime = DateTime.UtcNow.AddDays(7);
            await _context.SaveChangesAsync();

            return RT;
        }



    }




}
