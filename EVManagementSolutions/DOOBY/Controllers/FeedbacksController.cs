using DOOBY.DTOs;
using DOOBY.Models;
using DOOBY.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DOOBY.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeedbacksController : ControllerBase
    {

        IFeedback _feedback;

        public FeedbacksController(IFeedback feedback)
        {
            _feedback = feedback;
        }

        [HttpGet]
        public async Task<ActionResult<List<Feedback>>> GetAllFeedbacks()
        {
            var result = await _feedback.GetAllFeedbacks();

            return result;
        }

        [HttpGet("{cust_id}")]
        public async Task<List<Feedback>> GetAllFeedbacksFromCustomer(int cust_id)
        {
            var result = await _feedback.GetAllFeedbacksFromCustomer(cust_id);
            
            return result;
        }

        [HttpPost]
        public async Task<Feedback> PostFeedback(CustomerFeedbackDTO response)
        {
            var result = await _feedback.PostFeedback(response);

            return result;
        }


            //[HttpGet("{cust_id}")]
            //public async Task<ActionResult<List<Feedback>>> GetAllFeedbacksFromCustomer(int user_id)
            //{
            //    var result = await _feedback.GetAllFeedbacksFromCustomer(user_id);

            //    return result;
            //}
        }
}
