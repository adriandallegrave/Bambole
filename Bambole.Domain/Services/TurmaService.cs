using Bambole.Domain.Interfaces;
using Bambole.Domain.Interfaces.Services;
using Bambole.Domain.Models;
using System.Linq.Expressions;

namespace Bambole.Domain.Services;

public class TurmaService : ITurmaService
{
    private readonly IRepositoryWrapper _repository;

    public TurmaService(IRepositoryWrapper repository)
    {
        _repository = repository;
    }

    public async Task<Turma> Delete(Turma turma)
    {
        if (turma is null)
        {
            return turma;
        }

        if (await GetById(turma.Id) == default)
        {
            return null;
        }

        _repository.Turma.Delete(turma);
        var commitSuccessful = await _repository.Commit();

        return !commitSuccessful ? null : turma;
    }

    public async Task<List<Turma>> GetAll()
    {
        return await _repository.Turma.Get();
    }

    public async Task<Turma> GetById(Guid id)
    {
        return await _repository.Turma.GetFirstByProperty(turma => turma.Id == id);
    }

    public async Task<List<Turma>> GetByProperty(Expression<Func<Turma, bool>> expression)
    {
        return await _repository.Turma.GetAllByProperty(expression);
    }

    public async Task<Turma> Post(Turma turma)
    {
        if (turma is null)
        {
            return turma;
        }

        await _repository.Turma.Post(turma);
        var commitSucessful = await _repository.Commit();

        return !commitSucessful ? null : turma;
    }

    public async Task<Turma> Update(Turma turma)
    {
        if (turma is null)
        {
            return turma;
        }

        var old = await GetById(turma.Id);

        if (old is null)
        {
            return old;
        }

        old.Nome = turma.Nome;
        old.ProfessorId = turma.ProfessorId;

        _repository.Turma.Update(old);
        var commitSucessful = await _repository.Commit();

        return !commitSucessful ? null : turma;
    }
}
