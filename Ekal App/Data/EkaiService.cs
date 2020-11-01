using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EkalEntities.Models;
using Microsoft.EntityFrameworkCore;

namespace Ekal_App.Data
{
    public class EkaiService
    {
        public async Task<List<MstEkai>> GetAsync()
        {
            using (EkalContext dbContext = new EkalContext())
            {
                return await dbContext.MstEkai.ToListAsync();
            }
        }

        public async Task<MstEkai> GetAsync(int id)
        {
            using (EkalContext dbContext = new EkalContext())
            {
                return await dbContext.MstEkai.Where(x => x.EkaiId == id).FirstOrDefaultAsync();
            }
        }

        public async Task<bool> AddAsync(MstEkai entity)
        {
            using (EkalContext dbContext = new EkalContext())
            {
                try
                {
                    await dbContext.MstEkai.AddAsync(entity);
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
                    var tmpRecord = await dbContext.MstEkai.Where(x => x.EkaiId == id).FirstOrDefaultAsync();
                    dbContext.MstEkai.Remove(tmpRecord);
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
