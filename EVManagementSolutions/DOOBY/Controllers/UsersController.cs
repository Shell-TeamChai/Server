using DOOBY.Models;
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

        [HttpGet("{user_id}")]
        public async Task<ActionResult<User>> GetUserDetailById(int user_id)
        {
            var result = await _user.GetUserDetailById(user_id);

            return result;

        }
    }
}
