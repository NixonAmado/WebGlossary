using Domain;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;


namespace Application.Repository;

    public class PhaseTypeRepository : GenericRepository<Phasetype>, IPhaseType
    {
        private readonly DbAppContext _context;

        public PhaseTypeRepository(DbAppContext context): base(context)
        {
            _context = context;
        }
    public override async Task<(int totalRegistros, IEnumerable<Phasetype> registros)> GetAllAsync(int pageIndex, int pageSize, string search)
            {
                var query = _context.Phasetypes as IQueryable<Phasetype>;
    
                if(!string.IsNullOrEmpty(search))
                {
                    query = query.Where(p => p.Description.ToLower().Contains(search.ToLower()));

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