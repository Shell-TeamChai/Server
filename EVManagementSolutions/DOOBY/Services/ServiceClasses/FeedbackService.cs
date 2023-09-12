using DOOBY.GloablExceptions;
using DOOBY.Models;
using DOOBY.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DOOBY.Services.ServiceClasses
{
    public class FeedbackService : IFeedback
    {

        private CaseStudyContext _context;

        public FeedbackService(CaseStudyContext context)
        {
            _context = context;
        }

        public Task<List<Feedback>> GetAllFeedbacks()
        {
            var result = _context.Feedbacks.ToListAsync();

            if(result == null)
            {
                throw new Exception(ExceptionDetails.exceptionMessages[0]);
            }
            return result;
        }

        public async Task<Feedback> PostFeedback(Feedback feedback)
        {
            await _context.Feedbacks.AddAsync(feedback);
            await _context.SaveChangesAsync();
            var result = await _context.Feedbacks.FindAsync(feedback.FeedbackId);

            if (result == null)
            {
                throw new Exception(ExceptionDetails.exceptionMessages[0]);
            }
            return result;
        }
    }
}
