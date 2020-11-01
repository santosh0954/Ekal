using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EkalEntities.Models;
using Microsoft.EntityFrameworkCore;

namespace Ekal_App.Data
{
    public class TaskService
    {
        public async Task<List<TxnTasks>> GetAsync()
        {
            using (EkalContext dbContext = new EkalContext())
            {
                return await dbContext.TxnTasks.ToListAsync();
            }
        }

        public async Task<TxnTasks> GetAsync(int id)
        {
            using (EkalContext dbContext = new EkalContext())
            {
                return await dbContext.TxnTasks.Where(x => x.TaskId == id).FirstOrDefaultAsync();
            }
        }

        public async Task<bool> AddAsync(TxnTasks entity)
        {
            using (EkalContext dbContext = new EkalContext())
            {
                try
                {
                    await dbContext.TxnTasks.AddAsync(entity);
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
                    var tmpRecord = await dbContext.TxnTasks.Where(x => x.TaskId == id).FirstOrDefaultAsync();
                    dbContext.TxnTasks.Remove(tmpRecord);
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
