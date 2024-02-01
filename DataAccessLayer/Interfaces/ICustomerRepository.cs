using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces
{
    public interface ICustomerRepository
    {
        Task<IEnumerable<Customer>> GetCustomerAsync();
        void CreateCustomerAsync(Customer customer); // create customers

        Task<Customer> Details(int? id); // get customer details by id

        Task<Customer> GetCustomerById(int? id); // get customer details for edit

        void UpdateCustomerAsync(Customer customer); // update customer details

        Task<bool> CheckCustomerExists(int id);// check whether the customer exists or not
        void DeleteCustomerAsync(Customer customer);
    }

  
}
