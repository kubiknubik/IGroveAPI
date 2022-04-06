namespace Shared.Utils.WebAPI.Security
{
    public class JWTSettings
    {
        public string HmacSecretKey { get; set; }

        public string Issuer { get; set; }
    }
}
