using DOOBY.DTOs;
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

            if (result == null)
            {
                throw new Exception(ExceptionDetails.exceptionMessages[0]);
            }
            return result;
        }

        public async Task<List<Feedback>> GetAllFeedbacksFromCustomer(int cust_id)
        {
            var res = await _context.Feedbacks.Where(item => item.UserId == cust_id).ToListAsync();

            if (res == null)
            {
                throw new Exception("No feedbacks from given customer");
            }

            return res;
        }

        public async Task<Feedback> PostFeedback(CustomerFeedbackDTO response)
        {
            var res = await _context.Customers.Where(item => item.CustId == response.UserId).ToListAsync();

            if (res == null)
            {
                throw new Exception(ExceptionDetails.exceptionMessages[1]);
            }
            //Feedback feedback = new Feedback();
            Feedback feedback = new Feedback(response, res[0]);
            //feedback.FeedbackId = response.FeedbackId;
            //feedback.UserId = response.UserId;
            //feedback.Rating = response.Rating;
            //feedback.Description = response.Description;
            //feedback.StationId = response.StationId;
            //feedback.User = res[0];

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
