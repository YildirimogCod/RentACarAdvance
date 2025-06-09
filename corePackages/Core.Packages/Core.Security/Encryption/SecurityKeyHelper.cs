using Microsoft.IdentityModel.Tokens;

namespace Core.Security.Encryption
{
    public static class SecurityKeyHelper
    {
        public static SecurityKey CreateSecurityKey(string securityKey)
        {
            return new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(securityKey));
        }
    }
}
