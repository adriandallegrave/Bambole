using Bambole.Domain.Interfaces.Repositories;
using Bambole.Domain.Models;
using Bambole.Persistence.Repositories.Base;

namespace Bambole.Persistence.Repositories;

public class ProfessorRepository : BaseRepository<Professor>, IProfessorRepository
{
    public ProfessorRepository(BamboleContext context) : base(context)
    {
    }
}
