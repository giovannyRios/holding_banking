namespace ApplicationBanking.Application.Models
{
    public class JWT_Values
    {
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public string Key { get; set; }
        public string Subject { get; set; }

        public string ExpireTokenInMinutes { get; set; }
    }
}
