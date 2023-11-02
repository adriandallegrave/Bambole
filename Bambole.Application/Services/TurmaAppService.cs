using Bambole.Application.Dtos;
using Bambole.Application.Interfaces;
using Bambole.Domain.Interfaces.Services;
using Bambole.Domain.Models;

namespace Bambole.Application.Services;

public class TurmaAppService : ITurmaAppService
{
    private readonly ITurmaService _turmaService;

    public TurmaAppService(ITurmaService turmaService)
    {
        _turmaService = turmaService;
    }

    public async Task<Turma> Delete(Guid id)
    {
        var turma = await GetById(id);

        if (turma is null)
        {
            return turma;
        }

        return await _turmaService.Delete(turma);
    }

    public async Task<bool> Exists(Guid id)
    {
        return await GetById(id) != null;
    }

    public async Task<List<Turma>> GetAll()
    {
        return await _turmaService.GetAll();
    }

    public async Task<Turma> GetById(Guid id)
    {
        return await _turmaService.GetById(id);
    }

    public async Task<Turma> Post(TurmaDto dto)
    {
        var turma = new Turma()
        {
            Id = Guid.NewGuid(),
            Nome = dto.Nome,
            ProfessorId = dto.ProfessorId
        };

        return await _turmaService.Post(turma);
    }

    public async Task<Turma> Update(Guid id, TurmaDto dto)
    {
        var turma = await GetById(id);

        if (turma is null)
        {
            return turma;
        }

        turma.Nome = dto.Nome;
        turma.ProfessorId = dto.ProfessorId;

        return await _turmaService.Update(turma);
    }
}
