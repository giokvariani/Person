﻿using BasePerson.Application.Interfaces;
using BasePerson.Model.BusinessObjects;
using BasePerson.Persistence.DataLayer;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;


namespace BasePerson.Persistence.Repositories
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : BusinessObject
    {
        protected readonly DataContext context;
        public Repository(DataContext context) => this.context = context;
        // create
        public virtual async Task<int> CreateAsync(TEntity entity)
        {
            context.Set<TEntity>().Add(entity);
            await context.SaveChangesAsync();
            return entity.Id;
        }
        public virtual async Task<int> CreaRangeteAsync(IEnumerable<TEntity> entity)
        {
            context.Set<TEntity>().AddRange(entity);
            return await context.SaveChangesAsync();
        }
        // read
        public virtual async Task<TEntity> ReadAsync(int id)
        {
            return await context.Set<TEntity>().FindAsync(id);
        }
        public virtual async Task<IEnumerable<TEntity>> ReadAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await ReadCustom(predicate).ToListAsync();
        }
        protected virtual IQueryable<TEntity> ReadCustom(Expression<Func<TEntity, bool>> predicate)
        {
            return context.Set<TEntity>().Where(predicate);
        }
        public virtual async Task<IEnumerable<TEntity>> ReadAsync()
        {
            return await context.Set<TEntity>().ToListAsync();
        }
        // update
        public virtual async Task<int> UpdateAsync(TEntity entity)
        {
            context.Set<TEntity>().Update(entity);
            return await context.SaveChangesAsync();
        }
        public virtual async Task<int> UpdateAsync(int id, TEntity entity)
        {
            var existing = context.Set<TEntity>().Find(id);
            context.Entry(existing).CurrentValues.SetValues(entity);
            return await context.SaveChangesAsync();
        }
        // delete
        public virtual async Task<int> DeleteAsync(int id)
        {
            var item = await ReadAsync(id);
            context.Set<TEntity>().Remove(item);
            return await context.SaveChangesAsync();
        }
        public virtual async Task<int> DeleteAsync(TEntity entity)
        {
            context.Set<TEntity>().Remove(entity);
            return await context.SaveChangesAsync();
        }
        public virtual async Task<int> DeleteRangeAsync(IEnumerable<TEntity> entity)
        {
            context.Set<TEntity>().RemoveRange(entity);
            return await context.SaveChangesAsync();
        }
        // check
        public virtual async Task<bool> CheckAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await context.Set<TEntity>().AnyAsync(predicate);
        }
        public virtual async Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await context.Set<TEntity>().CountAsync(predicate);
        }
    }
}

