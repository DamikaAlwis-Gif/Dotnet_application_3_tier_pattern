using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Entities;

namespace BusinessLogicLayer
{
    public interface ICustomerService
    {
        Task<IEnumerable<Customer>> GetCustomerAsync();
        void CreateCustomerAsync(Customer customer);

        Task<Customer> Details(int? id);
        Task<Customer> GetCustomerById(int? id);

        void UpdateCustomerAsync(Customer customer);
        Task<bool> CheckCustomerExists(int id);
        void DeleteCustomerAsync(Customer customer);
     }
}
