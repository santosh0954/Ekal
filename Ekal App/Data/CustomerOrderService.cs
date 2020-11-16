using EkalEntities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Ekal_App.Data
{
    public class CustomerOrderService
    {
        public async Task<List<TxnCustomerOrder>> GetAsync()
        {
            using (EkalContext dbContext = new EkalContext())
            {
                return await dbContext.TxnCustomerOrder.ToListAsync();
            }
        }

        public async Task<TxnCustomerOrder> GetAsync(int id)
        {
            using (EkalContext dbContext = new EkalContext())
            {
                return await dbContext.TxnCustomerOrder.Where(x => x.CustomerOrderId == id).FirstOrDefaultAsync();
            }
        }

        public async Task<bool> AddAsync(TxnCustomerOrder entity)
        {
            using (EkalContext dbContext = new EkalContext())
            {
                try
                {
                    await dbContext.TxnCustomerOrder.AddAsync(entity);
                    dbContext.SaveChanges();
                    return true;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.ToString());
                }
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            using (EkalContext dbContext = new EkalContext())
            {
                try
                {
                    var tmpRecord = await dbContext.TxnCustomerOrder.Where(x => x.CustomerOrderId == id).FirstOrDefaultAsync();
                    dbContext.TxnCustomerOrder.Remove(tmpRecord);
                    dbContext.SaveChanges();
                    return true;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.ToString());
                }
            }
        }
    }
}
