using System.Net.Sockets;
using FinanceGub.Application.Interfaces.Repositories;
using FinanceHub.Core.Entities;
using FinanceHub.Core.Exceptions;
using FinanceHub.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Npgsql;

namespace FinanceHub.Infrastructure.Repositories;

public class GenericRepository<T>: IGenericRepository<T> where T: Base
{
    protected readonly DbContext _context;
    protected readonly DbSet<T> _dbSet;

    public GenericRepository(FinHubDbContext context)
    {
        _context = context;
        _dbSet = _context.Set<T>();
    }
    
    public virtual async Task<T> GetByIdAsync(Guid id, string? includeProperties = null)
    {
        var query = _context.Set<T>().AsQueryable();
        
        if (!string.IsNullOrEmpty(includeProperties))
        {
            foreach (var prop in includeProperties.Split(',', StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(prop);
            }
        }
        
        var entity = await query.FirstOrDefaultAsync(x => x.Id == id);

        if (entity == null)
        {
            throw new NotFoundException($"Entity of type {typeof(T).Name} with id {id} was not found.");
        }

        return entity;
    }

    public virtual async Task<IEnumerable<T>> GetAllAsync(string? includeProperties = null)
    {
        try
        {
            var query = _context.Set<T>().AsQueryable();

            if (!string.IsNullOrEmpty(includeProperties))
            {
                foreach (var prop in includeProperties.Split(',', StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(prop);
                }
            }
    
            var results = await query.ToListAsync();

            if (!results.Any())
            {
                throw new NotFoundException($"No entities of type {typeof(T).Name} were found.");
            }

            return results;
        }
        catch (Exception ex) when (ex is not NotFoundException)
        {
            throw new RepositoryException($"Failed to fetch entities of type {typeof(T).Name}", ex);
        }
    }

    public virtual async Task AddAsync(T entity)
    {
        try
        {
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
        }
        catch (NpgsqlException ex)
        {
            throw new RepositoryException("Failed to connect to the database. Please try again later.", ex);
        }
        catch (SocketException ex)
        {
            throw new RepositoryException("Failed to connect to the database. Network issues detected.", ex);
        }
        catch (DbUpdateException ex)
        {
            throw new RepositoryException($"Failed to add entity of type {typeof(T).Name}", ex);
        }
        catch (Exception ex)
        {
            throw new Exception($"An error occurred while adding entity of type {typeof(T).Name}", ex);
        }
    }


    public virtual async Task UpdateAsync(T entity)
    {
        try
        {
            _dbSet.Update(entity);
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException ex)
        {
            throw new RepositoryException($"Concurrency error: Failed to update entity of type {typeof(T).Name}", ex);
        }
        catch (DbUpdateException ex)
        {
            throw new RepositoryException($"Failed to update entity of type {typeof(T).Name}", ex);
        }
    }

    public virtual async Task DeleteAsync(Guid id)
    {
        try
        {
            var entity = await _dbSet.FindAsync(id);
            if (entity == null)
            {
                throw new NotFoundException($"Entity of type {typeof(T).Name} with ID {id} not found.");
            }

            _dbSet.Remove(entity);
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateException ex)
        {
            throw new RepositoryException($"Failed to delete entity of type {typeof(T).Name} with ID {id}", ex);
        }
    }
}