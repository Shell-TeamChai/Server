using DOOBY.Models;
using DOOBY.Models.Auth;
using DOOBY.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DOOBY.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        IUser _user;
        IToken _tokenizer;

        public UsersController(IUser _user, IToken tokenizer = null)
        {
            this._user = _user;
            _tokenizer = tokenizer;
        }

        [HttpPost]
        public async Task<ActionResult<AuthenticateResponse>> Authenticate(AuthenticateRequest request)
        {
            //var result = await _user.Authenticate(request);
            //return result;
        }

        [HttpGet("{user_id}")]
        public async Task<ActionResult<User>> GetUserDetailById(int user_id)
        {
            var result = await _user.GetUserDetailById(user_id);

            return result;

        }
    }
}
