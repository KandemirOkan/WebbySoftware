using WebbySoftware.DBOperations;
using WebbySoftware.TokenOperations;

namespace WebbySoftware.Application.UserOperations.Commands.RefreshToken
{
    public class RefreshTokenCommand
    {
        public string RefreshToken { get; set; }
        private readonly IWebbySoftDBContext _context;
        private readonly IConfiguration _configuration;

        public RefreshTokenCommand(IWebbySoftDBContext context,IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }
        public Token Handle()
        {
            var user = _context.Users.FirstOrDefault(x=>x.RefreshToken == RefreshToken && x.RefreshTokenExpireDate>DateTime.Now);
            if (user is not null)
            {
                TokenHandler tokenHandler = new(_configuration);
                Token token = tokenHandler.CreateAccessToken(user);

                user.RefreshToken = token.RefreshToken;
                user.RefreshTokenExpireDate = token.Expiration.AddMinutes(5);
                _context.SaveChanges();
                return token;
            }
            else
                throw new InvalidOperationException("No valid refresh token was found!");
        }
    }
}