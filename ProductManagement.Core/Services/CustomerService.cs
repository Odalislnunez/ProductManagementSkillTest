using Microsoft.EntityFrameworkCore;
using ProductManagement.Core.Models;
using ProductManagement.Core.Persistences;
using ProductManagement.Core.Services.Interfaces;

namespace ProductManagement.Core.Services
{
    public class CustomerService : IGeneridCrudService<Customer>
    {
        private readonly PMDbContext _dbContext;

        public CustomerService(PMDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IEnumerable<Customer>> GetAll()
        {
            try
            {
                var customers = await _dbContext.Customers.ToListAsync();

                return customers;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Customer> Get(int id)
        {
            try
            {
                var customer = await _dbContext.Customers.Where(x => x.Id == id).FirstOrDefaultAsync();

                return customer ?? new Customer();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> Create(Customer dto)
        {
            try
            {
                if(dto != null)
                {
                    dto.CreatedBy = "Odalis Test"; // Delete hard code when adding authentication.
                    dto.CreatedAt = DateTime.Now;

                    _dbContext.Customers.Add(dto);
                    await _dbContext.SaveChangesAsync();

                    return true;
                }

                return false;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> Update(int id, Customer dto)
        {
            try
            {
                if (id > 0 && dto != null)
                {
                    var customer = await _dbContext.Customers.Where(x => x.Id == id).FirstOrDefaultAsync();

                    if(customer != null && customer.Id == dto.Id)
                    {
                        dto.UpdatedBy = "Odalis Test"; // Delete hard code when adding authentication.
                        dto.UpdatedAt = DateTime.Now;

                        _dbContext.Customers.Update(dto);
                        await _dbContext.SaveChangesAsync();

                        return true;
                    }

                    return false;
                }

                return false;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> Delete(int id)
        {
            try
            {
                var customer = await _dbContext.Customers.Where(x => x.Id == id).FirstOrDefaultAsync();

                if(customer != null)
                {
                    customer.Status = !customer.Status;
                    customer.UpdatedBy = "Odalis Test"; // Delete hard code when adding authentication.
                    customer.UpdatedAt = DateTime.Now;

                    _dbContext.Update(customer);
                    await _dbContext.SaveChangesAsync();

                    return true;
                }

                return false;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
