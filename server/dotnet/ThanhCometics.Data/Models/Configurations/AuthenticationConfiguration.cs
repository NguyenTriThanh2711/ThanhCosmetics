namespace ThanhCometics.Repository.Models.Configurations
{
    public class AuthenticationConfiguration
    {
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public string EmailVerificationSecret { get; set; }
        public double EmailVerificationExpiration { get; set; }
        public string PasswordResetSecret { get; set; }
        public double PasswordResetExpiration { get; set; }
        public string AccessTokenSecret { get; set; }
        public double AccessTokenExpiration { get; set; }
        public string RefreshTokenSecret { get; set; }
        public double RefreshTokenExpiration { get; set; }
    }
}
