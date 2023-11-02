using Bambole.Domain.Interfaces;
using Bambole.Domain.Interfaces.Services;
using Bambole.Domain.Models;
using System.Linq.Expressions;

namespace Bambole.Domain.Services;

public class AlunoService : IAlunoService
{
    private readonly IRepositoryWrapper _repository;

    public AlunoService(IRepositoryWrapper repository)
    {
        _repository = repository;
    }

    public async Task<Aluno> Delete(Aluno aluno)
    {
        if (aluno is null)
        {
            return aluno;
        }

        if (await GetById(aluno.Id) == default)
        {
            return null;
        }

        _repository.Aluno.Delete(aluno);
        var commitSuccessful = await _repository.Commit();

        return !commitSuccessful ? null : aluno;
    }

    public async Task<List<Aluno>> GetAll()
    {
        return await _repository.Aluno.Get();
    }

    public async Task<Aluno> GetById(Guid id)
    {
        return await _repository.Aluno.GetFirstByProperty(aluno => aluno.Id == id);
    }

    public async Task<List<Aluno>> GetByProperty(Expression<Func<Aluno, bool>> expression)
    {
        return await _repository.Aluno.GetAllByProperty(expression);
    }

    public async Task<Aluno> Post(Aluno aluno)
    {
        if (aluno is null)
        {
            return aluno;
        }

        await _repository.Aluno.Post(aluno);
        var commitSucessful = await _repository.Commit();

        return !commitSucessful ? null : aluno;
    }

    public async Task<Aluno> Update(Aluno aluno)
    {
        if (aluno is null)
        {
            return aluno;
        }

        var old = await GetById(aluno.Id);

        if (old is null)
        {
            return old;
        }

        old.Nome = aluno.Nome;
        old.CPF = aluno.CPF;
        old.Nascimento = aluno.Nascimento;
        old.NomeMae = aluno.NomeMae;
        old.TurmaId = aluno.TurmaId;
        old.MensalidadeValor = aluno.MensalidadeValor;

        _repository.Aluno.Update(old);
        var commitSucessful = await _repository.Commit();

        return !commitSucessful ? null : aluno;
    }
}
