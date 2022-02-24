using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exobry.Examples.AD_GraphQL_EF.Application.Abstractions;
using Exobry.Examples.AD_GraphQL_EF.Application.Abstractions.Specifications;
using Exobry.Examples.AD_GraphQL_EF.Application.Exceptions;
using Exobry.Examples.AD_GraphQL_EF.Application.Specifications;
using Exobry.Examples.AD_GraphQL_EF.Domain.Interfaces;
using Exobry.Examples.AD_GraphQL_EF.Infrastructure.EntityFramework;
using Microsoft.EntityFrameworkCore;

namespace Exobry.Examples.AD_GraphQL_EF.Infrastructure.Repository;

public class GenericRepository : IGenericRepository
{
    private readonly ExobryExamplesTodoDbContext _context;


    public GenericRepository(IDbContextFactory<ExobryExamplesTodoDbContext> dbContextFactory)
    {
        _context = dbContextFactory.CreateDbContext();
    }

    private IQueryable<T> ApplySpecification<T>(ISpecification<T> spec) where T : class
    {
        return SpecificationEvaluator<T>.GetQuery(_context.Set<T>().AsQueryable(), spec);
    }

    public async Task<T> GetById<T>(Guid id) where T : class
    {
        return await _context.Set<T>().FindAsync(id) 
               ?? throw new EntityNotFoundException($"{nameof(T)} with Id = '{id}' not found.");
    }

    public async Task<T> Get<T>(ISpecification<T> spec) where T : class
    {
        return await ApplySpecification(spec).FirstAsync()
               ?? throw new EntityNotFoundException($"Requested entity of type {nameof(T)}, not found!");
    }

    public async Task<IEnumerable<T>> GetAll<T>(ISpecification<T>? spec = null) where T : class
    {
        return spec != null
            ? await ApplySpecification(spec).ToListAsync()
            : await _context.Set<T>().ToListAsync();
    }

    public async Task<int> Count<T>(ISpecification<T>? spec = null) where T : class
    {
        return spec != null 
            ? await ApplySpecification(spec).CountAsync()
            : await _context.Set<T>().CountAsync();
    }

    public async Task<bool> IfExists<T>(ISpecification<T> spec) where T : class
    {
        return await ApplySpecification(spec).AnyAsync();
    }

    public async Task<T> Insert<T>(T entity) where T : class
    {
        await _context.Set<T>().AddAsync(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task<int> Insert<T>(IEnumerable<T> entities) where T : class
    {
        await _context.Set<T>().AddRangeAsync(entities);
        return await _context.SaveChangesAsync();
    }

    public async Task<T> Update<T>(T entity) where T : class
    {
        _context.Set<T>().Update(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task Delete<T>(T entity) where T : class
    {
        _context.Set<T>().Remove(entity);
        await _context.SaveChangesAsync();
    }
}

