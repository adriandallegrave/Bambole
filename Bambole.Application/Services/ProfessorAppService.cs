using Bambole.Application.Dtos;
using Bambole.Application.Interfaces;
using Bambole.Domain.Interfaces.Services;
using Bambole.Domain.Models;

namespace Bambole.Application.Services;

public class ProfessorAppService : IProfessorAppService
{
    private readonly IProfessorService _professorService;

    public ProfessorAppService(IProfessorService professorService)
    {
        _professorService = professorService;
    }

    public async Task<Professor> Delete(Guid id)
    {
        var professor = await GetById(id);

        if (professor is null)
        {
            return professor;
        }

        return await _professorService.Delete(professor);
    }

    public async Task<bool> Exists(Guid id)
    {
        return await GetById(id) != null;
    }

    public async Task<List<Professor>> GetAll()
    {
        return await _professorService.GetAll();
    }

    public async Task<Professor> GetById(Guid id)
    {
        return await _professorService.GetById(id);
    }

    public async Task<Professor> Post(ProfessorDto dto)
    {
        var professor = new Professor()
        {
            Id = Guid.NewGuid(),
            Nome = dto.Nome,
            CPF = dto.CPF
        };

        return await _professorService.Post(professor);
    }

    public async Task<Professor> Update(Guid id, ProfessorDto dto)
    {
        var professor = await GetById(id);

        if (professor is null)
        {
            return professor;
        }

        professor.Nome = dto.Nome;
        professor.CPF = dto.CPF;

        return await _professorService.Update(professor);
    }
}
