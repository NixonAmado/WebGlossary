using Domain;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;


namespace Application.Repository;

    public class WordRepository : GenericRepository<Word>, IWord
    {
        private readonly DbAppContext _context;

        public WordRepository(DbAppContext context): base(context)
        {
            _context = context;
        }

        public override async Task<IEnumerable<Word>> GetAllAsync()
        {
            return await _context.Words
                                .Include(p => p.WordType)
                                .Include(p => p.VerbalTense)
                                .ToListAsync();


        }

    public override async Task<(int totalRegistros, IEnumerable<Word> registros)> GetAllAsync(int pageIndex, int pageSize, string search)
            {
                var query = _context.Words as IQueryable<Word>;
    
                if(!string.IsNullOrEmpty(search))
                {
                    query = query.Where(p => p.WordText.ToLower().Contains(search.ToLower()));

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