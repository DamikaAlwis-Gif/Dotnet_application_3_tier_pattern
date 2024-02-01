using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace BusinessLogicLayer
{
    public class CustomerService: ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;   
        }

        public  void CreateCustomerAsync(Customer customer)
        {
             _customerRepository.CreateCustomerAsync(customer);
            
        }

        public async Task<Customer> Details(int? id)
        {
            var customer = await _customerRepository.Details(id);
            return customer;
        }

        public async Task<Customer> GetCustomerById(int? id)
        {
            var customer =await _customerRepository.GetCustomerById(id) ;
            return customer;
        }

        public async Task<IEnumerable<Customer>> GetCustomerAsync()
        {
            return await _customerRepository.GetCustomerAsync();
        }

        public void UpdateCustomerAsync(Customer customer)
        {
            _customerRepository.UpdateCustomerAsync(customer);
        }

        public Task<bool> CheckCustomerExists(int id)
        {
            return _customerRepository.CheckCustomerExists(id);
           
        }

        public void DeleteCustomerAsync(Customer customer)
        {
            // we have to wait only when there is a reponce coming
            _customerRepository.DeleteCustomerAsync(customer);
        }
    }
}
