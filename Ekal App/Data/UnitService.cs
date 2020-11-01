using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EkalEntities.Models;
using Microsoft.EntityFrameworkCore;

namespace Ekal_App.Data
{
    public class UnitService
    {
        public async Task<List<MstUnit>> GetAsync()
        {
            using (EkalContext dbContext = new EkalContext())
            {
                return await dbContext.MstUnit.ToListAsync();
            }
        }

        public async Task<MstUnit> GetAsync(int id)
        {
            using (EkalContext dbContext = new EkalContext())
            {
                return await dbContext.MstUnit.Where(x => x.UnitId == id).FirstOrDefaultAsync();
            }
        }

        public async Task<bool> AddAsync(MstUnit entity)
        {
            using (EkalContext dbContext = new EkalContext())
            {
                try
                {
                    await dbContext.MstUnit.AddAsync(entity);
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
                    var tmpRecord = await dbContext.MstUnit.Where(x => x.UnitId == id).FirstOrDefaultAsync();
                    dbContext.MstUnit.Remove(tmpRecord);
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
