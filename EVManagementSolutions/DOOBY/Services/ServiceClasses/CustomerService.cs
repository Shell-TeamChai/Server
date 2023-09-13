﻿using DOOBY.GloablExceptions;
using DOOBY.Models;
using DOOBY.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DOOBY.Services.ServiceClasses
{
    public class CustomerService : ICustomer 
    {
        private CaseStudyContext _context;

        public CustomerService(CaseStudyContext context)
        {
            _context = context;
        }

        public async Task<Customer> GetCustomerDetailById(int custId)
        {
            var findUserById = await _context.Users.Where(item => item.UserId == custId).ToListAsync();

            if(findUserById == null)
            {
                throw new NullReferenceException(ExceptionDetails.exceptionMessages[3]);
            }

            var result = await _context.Customers.FirstOrDefaultAsync(item => item.CustId == custId);

            if (result == null)
            {
                throw new Exception(ExceptionDetails.exceptionMessages[1]);
            }

            return result;
        }


        public async Task<Customer> AddNewCustomer(Customer customer)
        {
            var _customer = await _context.Customers.FirstOrDefaultAsync(item => item.CustId == customer.CustId);

            _customer.Fname = customer.Fname;
            _customer.Lname = customer.Lname;
            _customer.PhoneNum = customer.PhoneNum;

            await _context.SaveChangesAsync();

            var newCustomer = await _context.Customers.Where(item => item.CustId == customer.CustId).ToListAsync();

            if (newCustomer == null)
            {
                throw new Exception(ExceptionDetails.exceptionMessages[0]);
            }
            return newCustomer[0];
        }
    }
}
