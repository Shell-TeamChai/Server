namespace DOOBY.Models.Auth
{
    public class AuthenticateResponse
    {
        public int UserId { get; set; }
        public string Token { get; set; }

        public AuthenticateResponse(User user, string token) {
            UserId = user.UserId;
            Token = token;
        }
    }
}
