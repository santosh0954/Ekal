using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EkalEntities.Models;
using Microsoft.EntityFrameworkCore;

namespace Ekal_App.Data
{
    public class DistrictService
    {
        public async Task<List<VDistricts>> GetAsync()
        {
            using (EkalContext dbContext = new EkalContext())
            {
                return await dbContext.VDistricts.ToListAsync();
            }
        }

        public async Task<MstDistricts> GetAsync(string code)
        {
            using (EkalContext dbContext = new EkalContext())
            {
                return await dbContext.MstDistricts.Where(x => x.DistrictCode == code).FirstOrDefaultAsync();
            }
        }

        public async Task<List<MstDistricts>> GetDistrictByStateCodeAsync(string stateCode)
        {
            using (EkalContext dbContext = new EkalContext())
            {
                return await dbContext.MstDistricts.Where(x => x.StateCode == stateCode)
                    .OrderBy(y=>y.DistrictName)
                    .ToListAsync();
            }
        }

        public async Task<bool> AddAsync(MstDistricts entity)
        {
            using (EkalContext dbContext = new EkalContext())
            {
                try
                {
                    await dbContext.MstDistricts.AddAsync(entity);
                    dbContext.SaveChanges();
                    return true;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.ToString());
                }
            }
        }

        public async Task<bool> DeleteAsync(string code)
        {
            using (EkalContext dbContext = new EkalContext())
            {
                try
                {
                    var tmpRecord = await dbContext.MstDistricts.Where(x => x.DistrictCode == code).FirstOrDefaultAsync();
                    dbContext.MstDistricts.Remove(tmpRecord);
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
