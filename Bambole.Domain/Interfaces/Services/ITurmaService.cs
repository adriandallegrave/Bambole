using Bambole.Domain.Models;
using System.Linq.Expressions;

namespace Bambole.Domain.Interfaces.Services;

public interface ITurmaService
{
    public Task<Turma> Delete(Turma turma);

    public Task<List<Turma>> GetAll();

    public Task<Turma> GetById(Guid id);

    public Task<List<Turma>> GetByProperty(Expression<Func<Turma, bool>> expression);

    public Task<Turma> Post(Turma turma);

    public Task<Turma> Update(Turma turma);
}
