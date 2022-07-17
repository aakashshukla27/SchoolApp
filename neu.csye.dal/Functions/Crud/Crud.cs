using Microsoft.EntityFrameworkCore;
using neu.csye.dal.DataContext;
using neu.csye.dal.Entities;
using neu.csye.dal.Functions.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace neu.csye.dal.Functions.Crud
{
    public class Crud : ICrud
    {
        #region CRUD

        /// <summary>
        /// Create a new record of type T
        /// </summary>
        /// <typeparam name="T">Generic Type</typeparam>
        /// <param name="dbObject"></param>
        /// <returns></returns>
        public async Task<T> Create<T>(T dbObject) where T : class
        {
            try
            {
                using(var context = new DatabaseContext(DatabaseContext.Options.DatabaseOptions))
                {
                    await context.AddAsync<T>(dbObject);
                    await context.SaveChangesAsync();
                    return dbObject;
                }
            }
            catch (Exception ex)
            {
                // logger.LogException(ex.ToString(), DateTime.Now);
                throw;
            }
        }

        public async Task<bool> Delete<T>(int entityId) where T : class
        {
            try
            {
                using(var context = new DatabaseContext(DatabaseContext.Options.DatabaseOptions))
                {
                    T recordToDelete = await context.FindAsync<T>(entityId);
                    if(recordToDelete != null)
                    {
                        context.Remove(recordToDelete);
                        await context.SaveChangesAsync();
                        return true;
                    }
                    return false;
                }
            }
            catch(Exception ex)
            {
                throw;
            }
        }

        public async Task<T> Read<T>(int entityId) where T : class
        {
            try
            {
                using(DatabaseContext context = new DatabaseContext(DatabaseContext.Options.DatabaseOptions))
                {
                    var result = await context.FindAsync<T>(entityId);
                    return result;
                }
            }
            catch(Exception ex)
            {
                throw;
            }
        }

        public async Task<List<T>> ReadAll<T>() where T : class
        {
            try
            {
                using(var context =new DatabaseContext(DatabaseContext.Options.DatabaseOptions))
                {
                    var result = await context.Set<T>().ToListAsync();
                    return result;
                }
            }
            catch(Exception ex)
            {
                throw;
            }
        }

        public async Task<T> Update<T>(int entityId, T dbObject) where T : class
        {
            try
            {
                using(var context = new DatabaseContext(DatabaseContext.Options.DatabaseOptions))
                {
                    var foundObject = await context.FindAsync<T>(entityId);
                    if(foundObject != null)
                    {
                        context.Entry(foundObject).CurrentValues.SetValues(dbObject);
                        await context.SaveChangesAsync();
                    }
                    return foundObject;
                }
            }
            catch(Exception ex)
            {
                throw;
            }
        }
        #endregion

       
    }
}

