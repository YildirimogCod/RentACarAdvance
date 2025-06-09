namespace Core.Security.JWT
{
    public class TokenOptions
    {
        public string Audience { get; set; }
        public string Issuer { get; set; }
        public int AccessTokenExpiration { get; set; } // in minutes
        public string SecurityKey { get; set; }
        public string RefreshTokenTTL { get; set; }

        public TokenOptions()
        {
            Audience = string.Empty;
            Issuer = string.Empty;
            SecurityKey = string.Empty;
        }
        public TokenOptions(string audience, string issuer, int accessTokenExpiration, string securityKey, string refreshTokenTTL)
        {
            Audience = audience;
            Issuer = issuer;
            AccessTokenExpiration = accessTokenExpiration;
            SecurityKey = securityKey;
            RefreshTokenTTL = refreshTokenTTL;
        }

    }
}
