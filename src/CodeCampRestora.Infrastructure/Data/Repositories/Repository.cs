using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
﻿using CodeCampRestora.Application.Common.Interfaces.Repositories;
using CodeCampRestora.Application.Common.Helpers.Pagination;

namespace CodeCampRestora.Infrastructure.Data.Repositories;

public abstract class Repository<TEntity, TKey> :
    IRepository<TEntity, TKey> where TEntity : class
{
    private readonly DbContext _dbContext;
    private readonly DbSet<TEntity> _dbSet;

    public Repository(DbContext dbContext)
    {
        _dbContext = dbContext;
        _dbSet = _dbContext.Set<TEntity>();
    }

    public virtual async Task AddAsync(TEntity entity)
    {
        await _dbSet.AddAsync(entity);
    }

    public async Task DeleteAsync(TKey id)
    {
        var entity = await _dbSet.FindAsync(id);
        _dbSet.Remove(entity!);
    }

    public async Task<IReadOnlyList<TEntity>> GetAllAsync()
    {
        return await _dbSet.ToListAsync();
    }

    public async Task<TEntity?> GetByIdAsync(TKey id)
    {
        var entity = await _dbSet.FindAsync(id);
        return entity;
    }

    public async Task UpdateAsync(TKey id, TEntity entity)
    {
        var existingEntity = await _dbSet.FindAsync(id);

        if (existingEntity != null)
        {
            _dbContext.Entry(existingEntity).CurrentValues.SetValues(entity);
            await _dbContext.SaveChangesAsync();
        }
    }

    public IEnumerable<TEntity> GetByFilter(Expression<Func<TEntity, bool>> predicate)
    {
        var filteredEntities = _dbSet.Where(predicate).AsEnumerable();
        return filteredEntities;
    }

    public async Task<bool> DoesExist(Expression<Func<TEntity, bool>> predicate)
    {
        var doesExist = await _dbSet.AnyAsync(predicate);
        return doesExist;
    }

    public IQueryable<TEntity> IncludeProps(params Expression<Func<TEntity, object?>>[] navigationProperties)
    {
        IQueryable<TEntity> query = _dbSet;

        foreach (var navigationProperty in navigationProperties)
        {
            query = query.Include(navigationProperty);
        }

        return query;
    }
    public async Task<PagedList<TEntity?>> GetPaginatedAsync(int PageNumber, int PageSize)
    {
        var Entities = _dbSet.AsQueryable();
        var PagedList = await PagedList<TEntity>.ToPagedListAsync(Entities, PageNumber, PageSize);
        return PagedList;
    }
}