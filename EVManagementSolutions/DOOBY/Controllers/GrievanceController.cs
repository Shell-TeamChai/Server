using DOOBY.DTOs;
using DOOBY.Models;
using DOOBY.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DOOBY.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class GrievanceController : ControllerBase
    {

        IGrievance _grievance;

        public GrievanceController(IGrievance grievance)
        {
            _grievance = grievance;
        }

        [HttpGet]
        public async Task<ActionResult<List<Grievance>>> GetAllGrievances()
        {
            var result = await _grievance.GetAllGrievances();

            return result;
        }

        [HttpGet("{cust_id}")]
        public async Task<List<Grievance>> GetAllGrievancesFromCustomer(int cust_id)
        {
            var result = await _grievance.GetAllGrievancesFromCustomer(cust_id);

            return result;
        }

        [HttpPost]
        public async Task<Grievance> PostGrievance(CustomerGrievanceDTO response)
        {
            var result = await _grievance.PostGrievance(response);

            return result;
        }
    }
}

