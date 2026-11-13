namespace ThanhCometics.Repository.Models.AuthenticationModel
{
    public class VerifyNewEmailRequest
    {
        public string CurrentEmail { get; set; }
        public string NewEmail { get; set; }
    }
}
