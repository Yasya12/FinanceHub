using System.Net.Sockets;
using FinanceGub.Application.Interfaces.Repositories;
using FinanceHub.Core.Entities;
using FinanceHub.Core.Exceptions;
using FinanceHub.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Npgsql;

namespace FinanceHub.Infrastructure.Repositories;

public class HubRepository(FinHubDbContext context) : GenericRepository<Hub>(context), IHubRepository
{
    public async Task<Hub?> GetHubByNameAsync(string name)
    {
        return await _dbSet
            .Where(h => h.Name.ToLower() == name.ToLower())  // порівняння без урахування регістру
            .FirstOrDefaultAsync();  // або FirstOrDefaultAsync для отримання першого результату або null
    }

    
    public virtual async Task<Hub> AddHubAsync(Hub entity)
    {
        try
        {
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
        
            // After SaveChangesAsync, the entity will have its Id populated
            return entity;
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
            throw new RepositoryException($"Failed to add entity of type {typeof(Hub).Name}", ex);
        }
        catch (Exception ex)
        {
            throw new Exception($"An error occurred while adding entity of type {typeof(Hub).Name}", ex);
        }
    }

    // Method to get all members of a specific hub
    public async Task<IEnumerable<dynamic>> GetHubMembersAsync(Guid hubId)
    {
        try
        {
            var hubMembers = await _dbSet
                .Where(h => h.Id == hubId)
                .Include(h => h.Members)
                .ThenInclude(m => m.User) // Include the user details
                .SelectMany(h => h.Members)
                .Select(m => new 
                {
                    Username = m.User.UserName,
                    ProfilePhotoUrl = m.User.ProfilePictureUrl,
                    Role = m.Role,
                    Bio = m.User.Bio,
                    Description = m.Description
                })
                .ToListAsync();

            return hubMembers;
        }
        catch (Exception ex)
        {
            throw new RepositoryException("Error retrieving hub members.", ex);
        }
    }
    
    public async Task<bool> CheckIfUserCanWritePostAsync(Guid hubId, Guid userId)
    {
        try
        {
            var hub = await _dbSet
                .Include(h => h.Members)
                .ThenInclude(m => m.User)
                .FirstOrDefaultAsync(h => h.Id == hubId);

            if (hub == null)
                return false;

            // Check if the user is a member of the hub
            var member = hub.Members.FirstOrDefault(m => m.UserId == userId);
            if (member == null)
                return false;

            // Roles that are allowed to write posts
            var allowedRoles = new[] { "Admin", "Moderator", "Member" };
            return allowedRoles.Contains(member.Role);
        }
        catch (Exception ex)
        {
            throw new Exception("Error while checking user's write permission in the hub.", ex);
        }
    }

}