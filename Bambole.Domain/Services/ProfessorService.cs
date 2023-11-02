using Bambole.Domain.Interfaces;
using Bambole.Domain.Interfaces.Services;
using Bambole.Domain.Models;
using System.Linq.Expressions;

namespace Bambole.Domain.Services;

public class ProfessorService : IProfessorService
{
    private readonly IRepositoryWrapper _repository;

    public ProfessorService(IRepositoryWrapper repository)
    {
        _repository = repository;
    }

    public async Task<Professor> Delete(Professor professor)
    {
        if (professor is null)
        {
            return professor;
        }

        if (await GetById(professor.Id) == default)
        {
            return null;
        }

        _repository.Professor.Delete(professor);
        var commitSuccessful = await _repository.Commit();

        return !commitSuccessful ? null : professor;
    }

    public async Task<List<Professor>> GetAll()
    {
        return await _repository.Professor.Get();
    }

    public async Task<Professor> GetById(Guid id)
    {
        return await _repository.Professor.GetFirstByProperty(professor => professor.Id == id);
    }

    public async Task<List<Professor>> GetByProperty(Expression<Func<Professor, bool>> expression)
    {
        return await _repository.Professor.GetAllByProperty(expression);
    }

    public async Task<Professor> Post(Professor professor)
    {
        if (professor is null)
        {
            return professor;
        }

        await _repository.Professor.Post(professor);
        var commitSucessful = await _repository.Commit();

        if (!commitSucessful)
        {
            return null;
        }

        return professor;
    }

    public async Task<Professor> Update(Professor professor)
    {
        if (professor is null)
        {
            return professor;
        }

        var old = await GetById(professor.Id);

        if (old is null)
        {
            return old;
        }

        old.Nome = professor.Nome;
        old.CPF = professor.CPF;

        _repository.Professor.Update(old);
        var commitSucessful = await _repository.Commit();

        if (!commitSucessful)
        {
            return null;
        }

        return professor;
    }
}
