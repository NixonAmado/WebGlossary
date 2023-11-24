using Domain;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;


namespace Application.Repository;

    public class PhaseRepository : GenericRepository<Phase>, IPhase
    {
        private readonly DbAppContext _context;

        public PhaseRepository(DbAppContext context): base(context)
        {
            _context = context;
        }

        public override async Task<IEnumerable<Phase>> GetAllAsync()
        {
            return await _context.Phases
                                .Include(p => p.PhaseVerbalTense)
                                .Include(p => p.PhaseStructure)
                                .Include(p => p.PhaseVerbalTense)
                                .ToListAsync();


        }
    public override async Task<(int totalRegistros, IEnumerable<Phase> registros)> GetAllAsync(int pageIndex, int pageSize, string search)
            {
                var query = _context.Phases as IQueryable<Phase>;
    
                if(!string.IsNullOrEmpty(search))
                {
                    query = query.Where(p => p.Phase1.ToLower().Contains(search.ToLower()));

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