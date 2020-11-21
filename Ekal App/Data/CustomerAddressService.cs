using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EkalEntities.Models;
using Microsoft.EntityFrameworkCore;

namespace Ekal_App.Data
{
    public class CustomerAddressService
    {
        public async Task<List<TxnCustomerDeliveryAddress>> GetAsync()
        {
            using (EkalContext dbContext = new EkalContext())
            {
                return await dbContext.TxnCustomerDeliveryAddress.ToListAsync();
            }
        }

        public async Task<TxnCustomerDeliveryAddress> GetAsync(int id)
        {
            using (EkalContext dbContext = new EkalContext())
            {
                return await dbContext.TxnCustomerDeliveryAddress.Where(x => x.CustomerDeliveryAddressId == id).FirstOrDefaultAsync();
            }
        }

        public async Task<bool> AddAsync(TxnCustomerDeliveryAddress entity)
        {
            using (EkalContext dbContext = new EkalContext())
            {
                try
                {
                    await dbContext.TxnCustomerDeliveryAddress.AddAsync(entity);
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
                    var tmpRecord = await dbContext.TxnCustomerDeliveryAddress.Where(x => x.CustomerDeliveryAddressId == id).FirstOrDefaultAsync();
                    dbContext.TxnCustomerDeliveryAddress.Remove(tmpRecord);
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
