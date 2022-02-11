using PetShop.Domain.SeedWork.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace PetShop.Domain.SeedWork.Contracts
{
    public interface IRepositoryGet<TEntity> where TEntity : BaseEntity
    {
        bool Exists(Expression<Func<TEntity, bool>> filter);

        List<TEntity> GetAll(Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy);

        List<TEntity> GetAll(List<Expression<Func<TEntity, object>>> includes, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy);
        List<TEntity> GetByFilter(Expression<Func<TEntity, bool>> filter, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy);

        List<TEntity> GetByFilter(Expression<Func<TEntity, bool>> filter, List<Expression<Func<TEntity, object>>> includes, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy);

        TEntity GetById(long Id);

    }
}
