using DataAccessLayer.Data;
using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace DataAccessLayer.Interfaces
{
    public class CustomerRepository : ICustomerRepository

    {
        private readonly ApplicationDbContext _dbContext;
        public CustomerRepository()
        {
            _dbContext = new ApplicationDbContext();
            
        }

        public async void CreateCustomerAsync(Customer customer)
        {   //dbContext reperesents a session with the database(it provides a set of API to work with the database)
            _dbContext.Add(customer);// add a customer to the dbContext
            await _dbContext.SaveChangesAsync(); //save changes to the database
           
        }

        public async Task<Customer> Details(int? id)
        {
            // retrive an entity based on a condition
            var customer = await _dbContext.Customers.FirstOrDefaultAsync(x => x.Id == id);
            return customer;
            
        }

        public async Task<Customer> GetCustomerById(int? id)
        {
            // retrive an entity based on its primary key (the id must be the primary key here)
            var customer = await _dbContext.Customers.FindAsync(id);
            return customer;
        }

        public async Task<IEnumerable<Customer>> GetCustomerAsync()
        {
            var customers = await _dbContext.Customers.ToListAsync();
            return customers;
            
        }

        public async void UpdateCustomerAsync(Customer customer)
        {
            _dbContext.Update(customer);
            await _dbContext.SaveChangesAsync();
            
        }

        public async Task<bool> CheckCustomerExists(int id)
        {
            // return true if the condition is correct
            // should use async methods to use async and await words
            bool res = await _dbContext.Customers.AnyAsync(x => x.Id == id);
            return res;
        }

        public async void DeleteCustomerAsync(Customer customer)
        {
            _dbContext.Remove(customer); // we can do the deletion with id also
            await _dbContext.SaveChangesAsync(); // to ensure the data consistency of the database
            
        }
    }
}
