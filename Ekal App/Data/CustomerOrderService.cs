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
        public async Task<List<VCustomerOrderWithDetails>> GetAsync()
        {
            using (EkalContext dbContext = new EkalContext())
            {
                return await dbContext.VCustomerOrderWithDetails.ToListAsync();
            }
        }

        public async Task<TxnCustomerOrder> GetAsync(int id)
        {
            using (EkalContext dbContext = new EkalContext())
            {
                return await dbContext.TxnCustomerOrder.Where(x => x.CustomerOrderId == id).FirstOrDefaultAsync();
            }
        }

        public async Task<string> GetNextOrderNoAsync()
        {
            using (EkalContext dbContext = new EkalContext())
            {
                string OrderNoPrefix = "O";
                var totalOrders = await dbContext.TxnCustomerOrder.CountAsync();
                if (totalOrders == 0)
                    OrderNoPrefix = "O001";
                else
                    OrderNoPrefix = "O"+(totalOrders+1).ToString().PadLeft(3,'0');

                return OrderNoPrefix;
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
