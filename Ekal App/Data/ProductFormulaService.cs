using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EkalEntities.Models;
using Microsoft.EntityFrameworkCore;

namespace Ekal_App.Data
{
    public class ProductFormulaService
    {
        public async Task<List<TxnProductionFormula>> GetAsync()
        {
            using (EkalContext dbContext = new EkalContext())
            {
                return await dbContext.TxnProductionFormula.ToListAsync();
            }
        }

        public async Task<TxnProductionFormula> GetAsync(int id)
        {
            using (EkalContext dbContext = new EkalContext())
            {
                return await dbContext.TxnProductionFormula.Where(x => x.ProductionFormulaId == id).FirstOrDefaultAsync();
            }
        }

        public async Task<bool> AddAsync(TxnProductionFormula entity)
        {
            using (EkalContext dbContext = new EkalContext())
            {
                try
                {
                    await dbContext.TxnProductionFormula.AddAsync(entity);
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
                    var tmpRecord = await dbContext.TxnProductionFormula.Where(x => x.ProductionFormulaId == id).FirstOrDefaultAsync();
                    dbContext.TxnProductionFormula.Remove(tmpRecord);
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
