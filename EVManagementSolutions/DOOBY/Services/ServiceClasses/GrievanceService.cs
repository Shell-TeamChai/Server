using DOOBY.DTOs;
using DOOBY.GloablExceptions;
using DOOBY.Models;
using DOOBY.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DOOBY.Services.ServiceClasses
{
    public class GrievanceService : IGrievance
    {
        private CaseStudyContext _context;

        public GrievanceService(CaseStudyContext context)
        {
            _context = context;
        }

        public Task<List<Grievance>> GetAllGrievances()
        {
            var result = _context.Grievances.ToListAsync();

            if (result == null)
            {
                throw new Exception(ExceptionDetails.exceptionMessages[10]);
            }
            return result;
        }

        public async Task<List<Grievance>> GetAllGrievancesFromCustomer(int cust_id)
        {
            var res = await _context.Grievances.Include(item => item.User).Where(item => item.UserId == cust_id).ToListAsync();

            if (res == null)
            {
                throw new Exception(ExceptionDetails.exceptionMessages[11]);
            }

            return res;
        }

        public async Task<Grievance> PostGrievance(CustomerGrievanceDTO response)
        {
            var res = await _context.Customers.Where(item => item.CustId == response.UserId).ToListAsync();

            if (res == null)
            {
                throw new Exception(ExceptionDetails.exceptionMessages[0]);
            }
            int id;
            try{
                id = _context.Grievances.Max(item => item.GrievanceId) + 1;

            }catch(Exception ex)
            {
                id = 1;
            }
            Grievance grievance = new Grievance(id, response, res[0]);
            
            await _context.Grievances.AddAsync(grievance);
            await _context.SaveChangesAsync();
            var result = await _context.Grievances.FindAsync(grievance.GrievanceId);

            if (result == null)
            {
                throw new Exception(ExceptionDetails.exceptionMessages[12]);
            }
            return result;
        }

        public async Task<Grievance> UpdateGrievance(CustomerGrievanceDTO grievance)
        {
            var _grievance = await _context.Grievances.FindAsync(grievance.GrievanceId);

            if (_grievance == null)
            {
                throw new ArgumentException(ExceptionDetails.exceptionMessages[11]);
            }
            else
            {
                _grievance.Status = grievance.Status;

                await _context.SaveChangesAsync();

                _grievance = await _context.Grievances.FindAsync(grievance.GrievanceId);
                return _grievance;
            }

        }
    }
}
