using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EkalEntities.Models;
using Microsoft.EntityFrameworkCore;

namespace Ekal_App.Data
{
    public class EkaiTypeService
    {
        public async Task<List<MstEkaiType>> GetAsync()
        {
            using (EkalContext dbContext = new EkalContext())
            {
                return await dbContext.MstEkaiType.ToListAsync();
            }
        }

        public async Task<MstEkaiType> GetAsync(int id)
        {
            using (EkalContext dbContext = new EkalContext())
            {
                return await dbContext.MstEkaiType.Where(x => x.EkaiTypeId == id).FirstOrDefaultAsync();
            }
        }

        public async Task<bool> AddAsync(MstEkaiType entity)
        {
            using (EkalContext dbContext = new EkalContext())
            {
                try
                {
                    await dbContext.MstEkaiType.AddAsync(entity);
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
                    var tmpRecord = await dbContext.MstEkaiType.Where(x => x.EkaiTypeId == id).FirstOrDefaultAsync();
                    dbContext.MstEkaiType.Remove(tmpRecord);
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
