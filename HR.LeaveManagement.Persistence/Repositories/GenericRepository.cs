using HRLeaveManagement.Application.Persistance.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Persistence.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly HRLeaveManagementDbContext _db;
        public GenericRepository(HRLeaveManagementDbContext db)
        {
            _db = db;
        }
        public async Task<T> Add(T entity)
        {
            await _db.AddAsync(entity);
            await _db.SaveChangesAsync();
            return entity;
        }

        public async Task Delete(T entity)
        {
            _db.Set<T>().Remove(entity);
            await _db.SaveChangesAsync();
        }

        public async Task<bool> Exists(int id)
        {
            var entity = await Get(id);
            return entity != null;
        }

        public async Task<T> Get(int id)
        {
            return await _db.Set<T>().FindAsync();
        }

        public async Task<IReadOnlyList<T>> GetAll()
        {
            return await _db.Set<T>().ToListAsync();
        }

        public async Task Update(T entity)
        {
            _db.Entry(entity).State = EntityState.Modified;
            await _db.SaveChangesAsync(); 
        }
    }
}
