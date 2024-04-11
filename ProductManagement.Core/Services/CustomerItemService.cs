using Microsoft.EntityFrameworkCore;
using ProductManagement.Core.Models;
using ProductManagement.Core.Persistences;
using ProductManagement.Core.Services.Interfaces;

namespace ProductManagement.Core.Services
{
    public class CustomerItemService : IGeneridCrudExtService<CustomerItem>
    {
        private readonly PMDbContext _dbContext;

        public CustomerItemService(PMDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<CustomerItem>> GetAll()
        {
            try
            {
                var customerItems = await _dbContext.CustomersItems
                    .Include(x => x.Customer)
                    .Include(x => x.Item)
                    .Where(x => x.DeletedAt == null).ToListAsync();

                return customerItems;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<CustomerItem>> GetAllById(int id)
        {
            try
            {
                var customerItems = await _dbContext.CustomersItems
                    .Include(x => x.Item)
                    .Where(x => x.DeletedAt == null && x.CustomerId == id)
                    .ToListAsync();

                return customerItems;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<CustomerItem> GetById(int id)
        {
            try
            {
                var customerItem = await _dbContext.CustomersItems.Where(x => x.DeletedAt == null && x.Id == id).FirstOrDefaultAsync();

                return customerItem ?? new CustomerItem();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> Create(CustomerItem dto)
        {
            try
            {
                if(dto != null)
                {
                    dto.CreatedBy = "Odalis Test"; // Delete hard code when adding authentication.
                    dto.CreatedAt = DateTime.Now;

                    _dbContext.CustomersItems.Add(dto);
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

        public async Task<bool> Update(int id, CustomerItem dto)
        {
            try
            {
                if (id > 0 && dto != null)
                {
                    var customerItem = await _dbContext.CustomersItems.Where(x => x.DeletedAt == null && x.Id == id).FirstOrDefaultAsync();

                    if(customerItem != null && customerItem.Id == dto.Id)
                    {
                        dto.UpdatedBy = "Odalis Test"; // Delete hard code when adding authentication.
                        dto.UpdatedAt = DateTime.Now;

                        _dbContext.CustomersItems.Update(dto);
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
                var customerItem = await _dbContext.CustomersItems.Where(x => x.DeletedAt == null && x.Id == id).FirstOrDefaultAsync();

                if(customerItem != null)
                {
                    customerItem.DeletedBy = "Odalis Test"; // Delete hard code when adding authentication.
                    customerItem.DeletedAt = DateTime.Now;

                    _dbContext.Update(customerItem);
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

        public async Task<bool> ChangeStatus(int id)
        {
            try
            {
                var customerItem = await _dbContext.CustomersItems.Where(x => x.DeletedAt == null && x.Id == id).FirstOrDefaultAsync();

                if (customerItem != null)
                {
                    customerItem.Status = !customerItem.Status;
                    customerItem.UpdatedBy = "Odalis Test"; // Delete hard code when adding authentication.
                    customerItem.UpdatedAt = DateTime.Now;

                    _dbContext.Update(customerItem);
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
