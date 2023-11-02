using Bambole.Domain.Interfaces.Repositories;
using Bambole.Domain.Models;
using Bambole.Persistence.Repositories.Base;

namespace Bambole.Persistence.Repositories;

public class AlunoRepository : BaseRepository<Aluno>, IAlunoRepository
{
    public AlunoRepository(BamboleContext context) : base(context)
    {
    }
}
