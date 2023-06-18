namespace WebbySoftware.TokenOperations
{
    public class Token
    {
        // token details
        public string AccessToken { get; set; }
        public DateTime Expiration { get; set; }
        public string RefreshToken { get; set; }
    }
}