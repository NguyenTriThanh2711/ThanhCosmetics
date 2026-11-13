namespace ThanhCometics.Repository.Models.AuthenticationModel
{
    public class AuthenticationRepsonse
    {
        public AccessToken AccessToken { get; set; } = new AccessToken();
        public string RefreshToken { get; set; } = string.Empty;

    }
}
