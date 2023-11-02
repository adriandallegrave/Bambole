using Bambole.Domain.Models;
using System.Linq.Expressions;

namespace Bambole.Domain.Interfaces.Services;

public interface IProfessorService
{
    public Task<Professor> Delete(Professor professor);

    public Task<List<Professor>> GetAll();

    public Task<Professor> GetById(Guid id);

    public Task<List<Professor>> GetByProperty(Expression<Func<Professor, bool>> expression);

    public Task<Professor> Post(Professor professor);

    public Task<Professor> Update(Professor professor);
}
