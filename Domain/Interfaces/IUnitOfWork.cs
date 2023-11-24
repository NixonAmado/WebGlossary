namespace Domain.Interfaces
{
    public interface IUnitOfWork
    {
        public IRole Roles {get;}
        public IUser Users {get;}
        public IPhase Phases {get;}
        public IPhaseStructure PhaseStructures {get;}
        public IPhaseType PhaseTypes {get;}
        public IPhaseVerbalTense PhaseVerbalTenses {get;}
        public IVerbalTense VerbalTenses {get;}
        public IWord Words {get;}
        public IWordType WordType {get;}

        Task<int> SaveAsync();
    }
}