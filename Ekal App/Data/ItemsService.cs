using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EkalEntities.Models;
using Microsoft.EntityFrameworkCore;

namespace Ekal_App.Data
{
    public class ItemsService
    {
        public async Task<List<MstItems>> GetAsync()
        {
            using (EkalContext dbContext = new EkalContext())
            {
                return await dbContext.MstItems.ToListAsync();
            }
        }

        public async Task<MstItems> GetAsync(int id)
        {
            using (EkalContext dbContext = new EkalContext())
            {
                return await dbContext.MstItems.Where(x => x.ItemId == id).FirstOrDefaultAsync();
            }
        }

        public async Task<bool> AddAsync(MstItems entity)
        {
            using (EkalContext dbContext = new EkalContext())
            {
                try
                {
                    await dbContext.MstItems.AddAsync(entity);
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
                    var tmpRecord = await dbContext.MstItems.Where(x => x.ItemId == id).FirstOrDefaultAsync();
                    dbContext.MstItems.Remove(tmpRecord);
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
