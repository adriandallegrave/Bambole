using Bambole.Application.Dtos;
using Bambole.Domain.Models;

namespace Bambole.Application.Interfaces;

public interface IAlunoAppService
{
    public Task<List<Aluno>> GetAll();

    public Task<Aluno> GetById(Guid id);

    public Task<Aluno> Post(AlunoDto dto);

    public Task<bool> Exists(Guid id);

    public Task<Aluno> Update(Guid id, AlunoDto dto);

    public Task<Aluno> Delete(Guid id);
}
