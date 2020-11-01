using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using EkalEntities.Models;
using Microsoft.AspNetCore.Server.IIS.Core;
using Microsoft.EntityFrameworkCore;

namespace Ekal_App.Data
{
    public class StateService
    {
        public async Task<List<MstStates>> GetAsync()
        {
            using (EkalContext dbContext = new EkalContext())
            {
                return await dbContext.MstStates.ToListAsync();
            }
        }

        public async Task<MstStates> GetAsync(string code)
        {
            using (EkalContext dbContext = new EkalContext())
            {
                return await dbContext.MstStates.Where(x=>x.StateCode == code).FirstOrDefaultAsync();
            }
        }

        public async Task<bool> AddAsync(MstStates entity)
        {
            using (EkalContext dbContext = new EkalContext())
            {
                try
                {
                    await dbContext.MstStates.AddAsync(entity);
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
                    var tmpRecord = await dbContext.MstStates.Where(x => x.StateCode == code).FirstOrDefaultAsync();
                    dbContext.MstStates.Remove(tmpRecord);
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
