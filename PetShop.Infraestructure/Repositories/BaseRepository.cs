using Microsoft.EntityFrameworkCore;
using PetShop.Domain.SeedWork.Contracts;
using PetShop.Domain.SeedWork.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace PetShop.Infraestructure.Repositories
{
    public abstract class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        protected readonly DbContext _context;
        protected readonly DbSet<TEntity> _dbSet;

        public BaseRepository(DbContext context)
        {
            if (context is null)
                throw new ArgumentNullException(nameof(context));

            _context = context;
            _dbSet = context.Set<TEntity>();
        }
        public virtual void Delete(long id)
        {
            if (id == 0)
                throw new ArgumentNullException(nameof(id));

            TEntity entity = _dbSet.Find(id);

            if (entity is null)
                throw new ArgumentException("Entity No Found.", nameof(id));

            _dbSet.Remove(entity);
            _context.SaveChanges();
        }


        public bool Exists(Expression<Func<TEntity, bool>> filter)
        {
            if (filter is null)
                throw new ArgumentNullException(nameof(filter));

            return _dbSet.Any(filter);
        }


        public List<TEntity> GetAll(List<Expression<Func<TEntity, object>>> includes, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy)
        {
            IQueryable<TEntity> query = _dbSet.AsNoTracking();

            if (includes != null)
            {
                foreach (var include in includes)
                {
                    query = query.Include(include);
                }
            }

            if (orderBy != null)
                query = orderBy(query);

            return query.ToList();
        }

        public List<TEntity> GetAll(Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy)
        {
            IQueryable<TEntity> query = _dbSet.AsNoTracking();

            if (orderBy != null)
                query = orderBy(query);

            return query.ToList();
        }

        public List<TEntity> GetByFilter(Expression<Func<TEntity, bool>> filter, List<Expression<Func<TEntity, object>>> includes, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy)
        {
            if (filter is null)
                throw new ArgumentNullException(nameof(filter));


            IQueryable<TEntity> query = _dbSet.AsNoTracking();

            query = query.Where(filter);


            if (includes != null)
            {
                foreach (var include in includes)
                {
                    query = query.Include(include);
                }
            }

            if (orderBy != null)
                query = orderBy(query);

            return query.ToList();
        }

        public List<TEntity> GetByFilter(Expression<Func<TEntity, bool>> filter, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy)
        {
            if (filter is null)
                throw new ArgumentNullException(nameof(filter));


            IQueryable<TEntity> query = _dbSet.AsNoTracking();

            query = query.Where(filter);

            if (orderBy != null)
                query = orderBy(query);

            return query.ToList();
        }

        public virtual TEntity GetById(long id)
        {
            if (id == 0)
                throw new ArgumentNullException(nameof(id));

            var entity = _dbSet.Find(id);

            return entity;
        }


        public virtual void Insert(TEntity entity)
        {
            if (entity is null)
                throw new ArgumentNullException(nameof(entity));

            _dbSet.Add(entity);
            _context.SaveChanges();
        }

        public virtual void Update(TEntity entity)
        {
            if (entity is null)
                throw new ArgumentNullException(nameof(entity));

            _dbSet.Update(entity);
            _context.SaveChanges();
        }

    }
}
