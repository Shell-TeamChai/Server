using DOOBY.Models;
using DOOBY.Models.Auth;

namespace DOOBY.Services.Interfaces
{
    public interface IUser
    {
        public Task<User> GetUserDetailById(int user_id);

        //public AuthenticateResponse Authenticate(AuthenticateRequest request);
    }
}
