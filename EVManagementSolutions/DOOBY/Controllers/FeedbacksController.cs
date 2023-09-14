using DOOBY.DTOs;
using DOOBY.Models;
using DOOBY.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
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
        [Authorize(Roles = "Admin, Customer")]
        [ProducesResponseType(typeof(Feedback), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Feedback), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<List<Feedback>>> GetAllFeedbacks()
        {
            var result = await _feedback.GetAllFeedbacks();

            return result;
        }

        [HttpGet("{cust_id}")]
        [Authorize(Roles = "Admin, Customer")]

        [ProducesResponseType(typeof(Feedback), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Feedback), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<List<Feedback>> GetAllFeedbacksFromCustomer(int cust_id)
        {
            var result = await _feedback.GetAllFeedbacksFromCustomer(cust_id);

            return result;
        }

        [HttpPost]
        [Authorize(Roles = Roles.Customer)]
        [ProducesResponseType(typeof(Feedback), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Feedback), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<Feedback> PostFeedback(CustomerFeedbackDTO response)
        {
            var result = await _feedback.PostFeedback(response);

            return result;
        }
     
    }
}
