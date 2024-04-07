using Microsoft.EntityFrameworkCore;
using ProductManagement.Core.Models;
using ProductManagement.Core.Persistences;
using ProductManagement.Core.Services.Interfaces;

namespace ProductManagement.Core.Services
{
    public class ItemService : IGeneridCrudService<Item>
    {
        private readonly PMDbContext _dbContext;

        public ItemService(PMDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IEnumerable<Item>> GetAll()
        {
            try
            {
                var items = await _dbContext.Items.ToListAsync();

                return items;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Item> GetById(int id)
        {
            try
            {
                var item = await _dbContext.Items.Where(x => x.Id == id).FirstOrDefaultAsync();

                return item ?? new Item();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> Create(Item dto)
        {
            try
            {
                if(dto != null)
                {
                    dto.CreatedBy = "Odalis Test"; // Delete hard code when adding authentication.
                    dto.CreatedAt = DateTime.Now;

                    _dbContext.Items.Add(dto);
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

        public async Task<bool> Update(int id, Item dto)
        {
            try
            {
                if (id > 0 && dto != null)
                {
                    var customer = await _dbContext.Items.Where(x => x.Id == id).FirstOrDefaultAsync();

                    if(customer != null && customer.Id == dto.Id)
                    {
                        dto.UpdatedBy = "Odalis Test"; // Delete hard code when adding authentication.
                        dto.UpdatedAt = DateTime.Now;

                        _dbContext.Items.Update(dto);
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
                var customer = await _dbContext.Items.Where(x => x.Id == id).FirstOrDefaultAsync();

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
