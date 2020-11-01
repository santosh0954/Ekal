using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EkalEntities.Models;
using Microsoft.EntityFrameworkCore;

namespace Ekal_App.Data
{
    public class ItemProviderService
    {
        public async Task<List<TxnItemProvider>> GetAsync()
        {
            using (EkalContext dbContext = new EkalContext())
            {
                return await dbContext.TxnItemProvider.ToListAsync();
            }
        }

        public async Task<TxnItemProvider> GetAsync(int id)
        {
            using (EkalContext dbContext = new EkalContext())
            {
                return await dbContext.TxnItemProvider.Where(x => x.ItemProviderId == id).FirstOrDefaultAsync();
            }
        }

        public async Task<bool> AddAsync(TxnItemProvider entity)
        {
            using (EkalContext dbContext = new EkalContext())
            {
                try
                {
                    await dbContext.TxnItemProvider.AddAsync(entity);
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
                    var tmpRecord = await dbContext.TxnItemProvider.Where(x => x.ItemProviderId == id).FirstOrDefaultAsync();
                    dbContext.TxnItemProvider.Remove(tmpRecord);
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
