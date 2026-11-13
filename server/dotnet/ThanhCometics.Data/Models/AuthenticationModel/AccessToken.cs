namespace ThanhCometics.Repository.Models.AuthenticationModel
{
    public class AccessToken
    {
        public string Token { get; set; }
        public DateTime ExpirationTime { get; set; }
    }
}
