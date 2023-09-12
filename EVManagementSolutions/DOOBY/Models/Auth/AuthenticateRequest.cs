namespace DOOBY.Models.Auth
{
    public class AuthenticateRequest
    {
        public string Email { get; set; } = null!;

        public string Password { get; set; } = null!;

        public AuthenticateRequest(User user) { 
            Email = user.Email;
            Password = user.Password;
        }
    }
}
