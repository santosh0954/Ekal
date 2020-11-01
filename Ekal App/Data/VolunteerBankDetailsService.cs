using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EkalEntities.Models;
using Microsoft.EntityFrameworkCore;

namespace Ekal_App.Data
{
    public class VolunteerBankDetailsService
    {
        public async Task<List<TxnVolunteerBankDetails>> GetAsync()
        {
            using (EkalContext dbContext = new EkalContext())
            {
                return await dbContext.TxnVolunteerBankDetails.ToListAsync();
            }
        }

        public async Task<TxnVolunteerBankDetails> GetAsync(int id)
        {
            using (EkalContext dbContext = new EkalContext())
            {
                return await dbContext.TxnVolunteerBankDetails.Where(x => x.VolunteerBankDetailsId == id).FirstOrDefaultAsync();
            }
        }

        public async Task<bool> AddAsync(TxnVolunteerBankDetails entity)
        {
            using (EkalContext dbContext = new EkalContext())
            {
                try
                {
                    await dbContext.TxnVolunteerBankDetails.AddAsync(entity);
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
                    var tmpRecord = await dbContext.TxnVolunteerBankDetails.Where(x => x.VolunteerId == id).FirstOrDefaultAsync();
                    dbContext.TxnVolunteerBankDetails.Remove(tmpRecord);
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
