using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EkalEntities.Models;
using Microsoft.EntityFrameworkCore;

namespace Ekal_App.Data
{
    public class ItemStockService
    {
        public async Task<List<VItemStock>> GetAsync()
        {
            using (EkalContext dbContext = new EkalContext())
            {
                return await dbContext.VItemStock.ToListAsync();
            }
        }

        public async Task<TxnItemStock> GetAsync(int id)
        {
            using (EkalContext dbContext = new EkalContext())
            {
                return await dbContext.TxnItemStock.Where(x => x.ItemStockId == id).FirstOrDefaultAsync();
            }
        }

        public async Task<bool> AddAsync(TxnItemStock entity)
        {
            using (EkalContext dbContext = new EkalContext())
            {
                try
                {
                    await dbContext.TxnItemStock.AddAsync(entity);
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
                    var tmpRecord = await dbContext.TxnItemStock.Where(x => x.ItemStockId == id).FirstOrDefaultAsync();
                    dbContext.TxnItemStock.Remove(tmpRecord);
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
