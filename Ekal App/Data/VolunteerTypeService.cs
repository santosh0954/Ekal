using EkalEntities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ekal_App.Data
{
    public class VolunteerTypeService
    {
        public async Task<List<MstVolunteerType>> GetAsync()
        {
            using (EkalContext dbContext = new EkalContext())
            {
                return await dbContext.MstVolunteerType.ToListAsync();
            }
        }

        public async Task<MstVolunteerType> GetAsync(int id)
        {
            using (EkalContext dbContext = new EkalContext())
            {
                return await dbContext.MstVolunteerType.Where(x => x.VolunteerTypeId == id).FirstOrDefaultAsync();
            }
        }

        public async Task<bool> AddAsync(MstVolunteerType entity)
        {
            using (EkalContext dbContext = new EkalContext())
            {
                try
                {
                    await dbContext.MstVolunteerType.AddAsync(entity);
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
                    var tmpRecord = await dbContext.MstVolunteerType.Where(x => x.VolunteerTypeId == id).FirstOrDefaultAsync();
                    dbContext.MstVolunteerType.Remove(tmpRecord);
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
