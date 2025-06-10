using System.Net.Sockets;
using FinanceGub.Application.Interfaces.Repositories;
using FinanceHub.Core.Entities;
using FinanceHub.Core.Exceptions;
using FinanceHub.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Npgsql;

namespace FinanceHub.Infrastructure.Repositories;

public class UserRepository : IUserRepository
{
    private readonly DbContext _context;
    private readonly DbSet<User> _dbSet;

    public UserRepository(FinHubDbContext context)
    {
        _context = context;
        _dbSet = _context.Set<User>();
    }
    
    public async Task<IEnumerable<User>> SearchUsersAsync(string query, int takeCount)
    {
        return await _dbSet
            .Where(u => u.UserName.ToLower().Contains(query))
            .Take(takeCount)
            .ToListAsync();
    }

    public async Task<User> GetByEmailAsync(string email, string? includeProperties = null)
    {
        try
        {
            var query = _dbSet.AsQueryable();

            if (!string.IsNullOrEmpty(includeProperties))
            {
                foreach (var prop in includeProperties.Split(',', StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(prop);
                }
            }

            return await query.FirstOrDefaultAsync(u => u.Email == email);
        }
        catch (RepositoryException ex)
        {
            throw new RepositoryException("An error occurred while trying to retrieve the user by email.", ex);
        }
    }

    public async Task<User> GetByGoogleIdAsync(string googleId)
    {
        try
        {
            return await _dbSet.FirstOrDefaultAsync(u => u.GoogleId == googleId);
        }
        catch (RepositoryException ex)
        {
            throw new RepositoryException("An error occurred while trying to retrieve the user by Google ID.", ex);
        }
    }

    public async Task<User> GetByUsernameAsync(string username, string? includeProperties = null)
    {
        try
        {
            var query = _dbSet.AsQueryable();

            if (!string.IsNullOrEmpty(includeProperties))
            {
                foreach (var prop in includeProperties.Split(',', StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(prop);
                }
            }

            return await query.FirstOrDefaultAsync(u => u.UserName == username);
        }
        catch (Exception ex)
        {
            throw new RepositoryException("An error occurred while trying to retrieve the user by username.", ex);
        }
    }

    //generic repo
    public virtual async Task<User> GetByIdAsync(Guid id, string? includeProperties = null)
    {
        var query = _context.Set<User>().AsQueryable();

        if (!string.IsNullOrEmpty(includeProperties))
        {
            foreach (var prop in includeProperties.Split(',', StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(prop);
            }
        }

        var entity = await query.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);

        if (entity == null)
        {
            throw new NotFoundException($"Entity of type {typeof(User).Name} with id {id} was not found.");
        }

        return entity;
    }

    public virtual async Task<IEnumerable<User>> GetAllAsync(string? includeProperties = null)
    {
        try
        {
            var query = _context.Set<User>().AsQueryable();

            if (!string.IsNullOrEmpty(includeProperties))
            {
                foreach (var prop in includeProperties.Split(',', StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(prop);
                }
            }

            var results = await query.AsNoTracking().ToListAsync();

            return results;
        }
        catch (Exception ex) when (ex is not NotFoundException)
        {
            throw new RepositoryException($"Failed to fetch entities of type {typeof(User).Name}", ex);
        }
    }

    public virtual IQueryable<User> GetAllAsQueryable(string? includeProperties = null)
    {
        var query = _context.Set<User>().AsQueryable();

        if (!string.IsNullOrEmpty(includeProperties))
        {
            foreach (var prop in includeProperties.Split(',', StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(prop);
            }
        }

        return query.AsNoTracking();
    }

    public virtual async Task AddAsync(User entity)
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
            throw new RepositoryException($"Failed to add entity of type {typeof(User).Name}", ex);
        }
        catch (Exception ex)
        {
            throw new Exception($"An error occurred while adding entity of type {typeof(User).Name}", ex);
        }
    }

    public virtual async Task UpdateAsync(User entity)
    {
        try
        {
            _dbSet.Update(entity);
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException ex)
        {
            throw new RepositoryException($"Concurrency error: Failed to update entity of type {typeof(User).Name}",
                ex);
        }
        catch (DbUpdateException ex)
        {
            throw new RepositoryException($"Failed to update entity of type {typeof(User).Name}", ex);
        }
    }

    public virtual async Task<string> DeleteAsync(Guid id)
    {
        try
        {
            var entity = await _dbSet.FindAsync(id);
            if (entity == null)
            {
                throw new NotFoundException($"Entity of type {typeof(User).Name} with ID {id} not found.");
            }

            _dbSet.Remove(entity);
            await _context.SaveChangesAsync();
            return $"Entity of type {typeof(User).Name} with ID {id} was successfully deleted.";
        }
        catch (DbUpdateException ex)
        {
            throw new RepositoryException($"Failed to delete entity of type {typeof(User).Name} with ID {id}", ex);
        }
    }

    public async Task<bool> SaveAllAsync()
    {
        return await _context.SaveChangesAsync() > 0;
    }
}