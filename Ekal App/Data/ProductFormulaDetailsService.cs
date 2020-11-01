using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EkalEntities.Models;
using Microsoft.EntityFrameworkCore;

namespace Ekal_App.Data
{
    public class ProductFormulaDetailsService
    {
        public async Task<List<TxnProductionFormulaDetails>> GetAsync()
        {
            using (EkalContext dbContext = new EkalContext())
            {
                return await dbContext.TxnProductionFormulaDetails.ToListAsync();
            }
        }

        public async Task<TxnProductionFormulaDetails> GetAsync(int id)
        {
            using (EkalContext dbContext = new EkalContext())
            {
                return await dbContext.TxnProductionFormulaDetails.Where(x => x.ProductionFormulaDetailsId == id).FirstOrDefaultAsync();
            }
        }

        public async Task<bool> AddAsync(TxnProductionFormulaDetails entity)
        {
            using (EkalContext dbContext = new EkalContext())
            {
                try
                {
                    await dbContext.TxnProductionFormulaDetails.AddAsync(entity);
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
                    var tmpRecord = await dbContext.TxnProductionFormulaDetails.Where(x => x.ProductionFormulaDetailsId == id).FirstOrDefaultAsync();
                    dbContext.TxnProductionFormulaDetails.Remove(tmpRecord);
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
