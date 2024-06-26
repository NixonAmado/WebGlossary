using Domain;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;

namespace Application.Repository
{
    public class UserRepository : GenericRepository<User>, IUser
    {
        private readonly DbAppContext _context;

        public UserRepository(DbAppContext context) : base(context)
        {
            _context = context;
        }

        public async Task<User> GetByUserNameAsync(string nameEmail)
        {
            return await _context.Users
                            .Include(p => p.Roles)
                            .FirstOrDefaultAsync(
                                u => u.User_name.ToLower() == nameEmail.ToLower() ||
                                    u.User_email.ToLower() == nameEmail.ToLower());
        }
        
        public async Task<User> GetByRefreshTokenAsync(string refreshToken)
        {
        return await _context.Users
            .Include(u => u.Roles)
            .Include(u => u.RefreshTokens)
            .FirstOrDefaultAsync(u => u.RefreshTokens.Any(t => t.Token == refreshToken));
        }
        public override async Task<(int totalRegistros, IEnumerable<User> registros)> GetAllAsync(int pageIndex, int pageSize, string search)
        {
            var query = _context.Users as IQueryable<User>;

            if(!string.IsNullOrEmpty(search))
            {
                query = query.Where(p => p.Id.ToString() == search);
            }

            query = query.OrderBy(p => p.Id);
            var totalRegistros = await query.CountAsync();
            var registros = await query
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return (totalRegistros, registros);
        }

    }
}