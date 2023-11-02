using Bambole.Domain.Interfaces.Repositories;
using Bambole.Domain.Models;
using Bambole.Persistence.Repositories.Base;

namespace Bambole.Persistence.Repositories;

public class TurmaRepository : BaseRepository<Turma>, ITurmaRepository
{
    public TurmaRepository(BamboleContext context) : base(context)
    {
    }
}
