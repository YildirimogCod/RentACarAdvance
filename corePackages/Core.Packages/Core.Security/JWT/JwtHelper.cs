using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using Core.Security.Encryption;
using Core.Security.Entities;
using Core.Security.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Core.Security.JWT
{
    public class JwtHelper : ITokenHelper
    {
        private readonly IConfiguration _configuration;
        private readonly TokenOptions _tokenOptions;
        private DateTime _accessTokenExpiration;

        public JwtHelper(IConfiguration configuration)
        {
            _configuration = configuration;
            const string configurationSection = "TokenOptions";
            _tokenOptions = _configuration.GetSection("TokenOptions").Get<TokenOptions>();
        }

        public AccessToken CreateToken(User user, IList<OperationClaim> operationClaims)
        {
            _accessTokenExpiration = DateTime.Now.AddMinutes(_tokenOptions.AccessTokenExpiration);
            SecurityKey securityKey = SecurityKeyHelper.CreateSecurityKey(_tokenOptions.SecurityKey);
            SigningCredentials signingCredentials = SigningCredentialsHelper.CreateSigningCredentials(securityKey);
            JwtSecurityToken jwt = CreateJwtSecurityToken(_tokenOptions, user, signingCredentials, operationClaims);
            JwtSecurityTokenHandler jwtSecurityTokenHandler = new();
            string? token = jwtSecurityTokenHandler.WriteToken(jwt);

            return new AccessToken { Token = token, Expiration = _accessTokenExpiration };
        }

        public RefreshToken CreateRefreshToken(User user, string ipAddress)
        {
            RefreshToken refreshToken =
                new()
                {
                    UserId = user.Id,
                    Token = RandomRefreshToken(),
                    Expires = DateTime.UtcNow.AddDays(7),
                    CreatedByIp = ipAddress
                };

            return refreshToken;
        }
        public JwtSecurityToken CreateJwtSecurityToken(
            TokenOptions tokenOptions,
            User user,
            SigningCredentials signingCredentials,
            IList<OperationClaim> operationClaims
        )
        {
            JwtSecurityToken jwt =
                new(
                    tokenOptions.Issuer,
                    tokenOptions.Audience,
                    expires: _accessTokenExpiration,
                    notBefore: DateTime.Now,
                    claims: SetClaims(user, operationClaims),
                    signingCredentials: signingCredentials
                );
            return jwt;
        }
        private ICollection<Claim> SetClaims(User user, IList<OperationClaim> operationClaims)
        {
            List<Claim> claims = new();
            claims.AddNameIdentifier(user.Id.ToString());
            claims.AddName(user.FirstName + " " + user.LastName);
            claims.AddEmail(user.Email);
            claims.AddRoles(operationClaims.Select(x => x.Name).ToArray());
            return claims;
        }
        private string RandomRefreshToken()
        {
            byte[] numberByte = new byte[32];
            using var random = RandomNumberGenerator.Create();
            random.GetBytes(numberByte);
            return Convert.ToBase64String(numberByte);
        }
    }
}
