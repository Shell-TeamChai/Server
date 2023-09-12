using DOOBY.GloablExceptions;
using DOOBY.Models;
using DOOBY.Models.Auth;
using DOOBY.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DOOBY.Services.ServiceClasses
{
    public class UserService : IUser
    {

        private CaseStudyContext _context;



        public UserService(CaseStudyContext context)
        {
            _context = context;
        }

        public AuthenticateResponse Authenticate(AuthenticateRequest request)
        {

        }

        public async Task<List<User>> AddUser(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return await _context.Users.ToListAsync();
        }



        public async Task<List<User>> DeleteUser(string username)
        {
            var ruser = await _context.Users.FindAsync(username);



            if (ruser != null)
            {
                _context.Users.Remove(ruser);
                _context.SaveChanges();
                return await _context.Users.ToListAsync();
            }
            else
            {
                throw new Exception(ExceptionDetails.exceptionMessages[1]);
            }
        }



        public async Task<User> GetUserDetailById(int user_id)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.UserId == user_id);
            
            if (user != null)
            {
                return user;
            }
            else
            {
                throw new Exception(ExceptionDetails.exceptionMessages[1]);
            }
        }
    }
}
