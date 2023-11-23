using Domain;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;


namespace Application.Repository;

    public class WordTenseRepository : GenericRepository<Wordtense>, IWordTense
    {
        private readonly DbAppContext _context;

        public WordTenseRepository(DbAppContext context): base(context)
        {
            _context = context;
        }
    public override async Task<(int totalRegistros, IEnumerable<Wordtense> registros)> GetAllAsync(int pageIndex, int pageSize, string search)
            {
                var query = _context.Words as IQueryable<WordTense>;
    
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