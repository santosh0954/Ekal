using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EkalEntities.Models;
using Microsoft.EntityFrameworkCore;

namespace Ekal_App.Data
{
    public class ItemFormulaDetailsService
    {
        public async Task<List<VItemFormulaDetails>> GetAsync()
        {
            using (EkalContext dbContext = new EkalContext())
            {
                return await dbContext.VItemFormulaDetails.ToListAsync();
            }
        }

        public async Task<TxnItemFormulaDetails> GetAsync(int id)
        {
            using (EkalContext dbContext = new EkalContext())
            {
                return await dbContext.TxnItemFormulaDetails.Where(x => x.ItemFormulaDetailsId == id).FirstOrDefaultAsync();
            }
        }

        public async Task<bool> AddAsync(TxnItemFormulaDetails entity)
        {
            using (EkalContext dbContext = new EkalContext())
            {
                try
                {
                    await dbContext.TxnItemFormulaDetails.AddAsync(entity);
                    dbContext.SaveChanges();
                    return true;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.ToString());
                }
            }
        }

        public async Task<bool> AddRangeAsync(List<TxnItemFormulaDetails> entities)
        {
            using (EkalContext dbContext = new EkalContext())
            {
                try
                {
                    await dbContext.TxnItemFormulaDetails.AddRangeAsync(entities);
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
                    var tmpRecord = await dbContext.TxnItemFormulaDetails.Where(x => x.ItemFormulaDetailsId == id).FirstOrDefaultAsync();
                    dbContext.TxnItemFormulaDetails.Remove(tmpRecord);
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
