using Bambole.Application.Dtos;
using Bambole.Domain.Models;

namespace Bambole.Application.Interfaces;

public interface IProfessorAppService
{
    public Task<List<Professor>> GetAll();

    public Task<Professor> GetById(Guid id);

    public Task<Professor> Post(ProfessorDto dto);

    public Task<bool> Exists(Guid id);

    public Task<Professor> Update(Guid id, ProfessorDto dto);

    public Task<Professor> Delete(Guid id);
}
