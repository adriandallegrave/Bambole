using Bambole.Application.Dtos;
using Bambole.Domain.Models;

namespace Bambole.Application.Interfaces;

public interface ITurmaAppService
{
    public Task<List<Turma>> GetAll();

    public Task<Turma> GetById(Guid id);

    public Task<Turma> Post(TurmaDto dto);

    public Task<bool> Exists(Guid id);

    public Task<Turma> Update(Guid id, TurmaDto dto);

    public Task<Turma> Delete(Guid id);
}
