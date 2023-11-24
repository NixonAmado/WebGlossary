using Application.Repository;
using Domain;
using Domain.Interfaces;
using Persistence.Data;

namespace Application.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly DbAppContext _context;  
        private RoleRepository _Roles;
        private UserRepository _Users; 
        private PhaseRepository _Phases; 
        private PhaseStructureRepository _PhaseStructures; 
        private PhaseTypeRepository _PhaseTypes; 
        private PhaseVerbalTenseRepository _PhaseVerbalTenses; 
        private VerbalTenseRepository _VerbalTenses;
        private WordRepository _Words;
        private WordTypeRepository _WordTypes; 

        public IRole Roles 
        {
            get
            {
                _Roles ??= new RoleRepository(_context);
                return _Roles;
            }
        }
        public IUser Users
        {
            get
            {
                _Users ??= new UserRepository(_context);
                return _Users;
            }
        }
        public IPhase Phases 
        {
            get
            {
                _Phases ??= new PhaseRepository(_context);
                return _Phases;
            }
        }
        public IPhaseStructure PhaseStructures
        {
            get
            {
                _PhaseStructures ??= new PhaseStructureRepository(_context);
                return _PhaseStructures;
            }
        }
        public IPhaseType PhaseTypes 
        {
            get
            {
                _PhaseTypes ??= new PhaseTypeRepository(_context);
                return _PhaseTypes;
            }
        }
        public IPhaseVerbalTense PhaseVerbalTenses 
        {
            get
            {
                _PhaseVerbalTenses ??= new PhaseVerbalTenseRepository(_context);
                return _PhaseVerbalTenses;
            }
        }
        public IVerbalTense VerbalTenses 
        {
            get
            {
                _VerbalTenses ??= new VerbalTenseRepository(_context);
                return _VerbalTenses;
            }
        }        
        public IWord Words 
        {
            get
            {
                _Words ??= new WordRepository(_context);
                return _Words;
            }
        }        
        
        public IWordType WordType 
        {
            get
            {
                _WordTypes ??= new WordTypeRepository(_context);
                return _WordTypes;
            }
        }        

        public void Dispose()
        {
            _context.Dispose();
        }

        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }
        
    }
}