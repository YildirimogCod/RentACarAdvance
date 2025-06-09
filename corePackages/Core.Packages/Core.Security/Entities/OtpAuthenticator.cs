using Core.Persistence.Repositories;

namespace Core.Security.Entities
{
    public class OtpAuthenticator:Entity<int>
    {
        public int UserId { get; set; }
        public byte[] SecretKey { get; set; }
        public bool IsEnabled { get; set; }

        public virtual User User { get; set; } = null!;
        public OtpAuthenticator()
        {
            SecretKey = Array.Empty<byte>();
        }
        public OtpAuthenticator(int userId, byte[] secretKey, bool isEnabled)
        {
            UserId = userId;
            SecretKey = secretKey;
            IsEnabled = isEnabled;
        }
        public OtpAuthenticator(int userId, byte[] secretKey) : this(userId, secretKey, true)
        {
        }
    }
}
