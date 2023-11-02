using Bambole.Domain.Models;
using System.Linq.Expressions;

namespace Bambole.Domain.Interfaces.Services;

public interface IAlunoService
{
    public Task<Aluno> Delete(Aluno aluno);

    public Task<List<Aluno>> GetAll();

    public Task<Aluno> GetById(Guid id);

    public Task<List<Aluno>> GetByProperty(Expression<Func<Aluno, bool>> expression);

    public Task<Aluno> Post(Aluno aluno);

    public Task<Aluno> Update(Aluno aluno);
}
