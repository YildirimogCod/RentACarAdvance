namespace Core.Security.JWT
{
    public class AccessToken
    {
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
        public AccessToken()
        {
        }
        public AccessToken(string token, DateTime expiration)
        {
            Token = token;
            Expiration = expiration;
        }
    }
}
