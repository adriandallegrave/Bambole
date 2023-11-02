using Bambole.Application.Dtos;
using Bambole.Application.Interfaces;
using Bambole.Domain.Interfaces.Services;
using Bambole.Domain.Models;

namespace Bambole.Application.Services;

public class AlunoAppService : IAlunoAppService
{
    private readonly IAlunoService _alunoService;

    public AlunoAppService(IAlunoService alunoService)
    {
        _alunoService = alunoService;
    }

    public async Task<Aluno> Delete(Guid id)
    {
        var aluno = await GetById(id);

        if (aluno is null)
        {
            return aluno;
        }

        return await _alunoService.Delete(aluno);
    }

    public async Task<bool> Exists(Guid id)
    {
        return await GetById(id) != null;
    }

    public async Task<List<Aluno>> GetAll()
    {
        return await _alunoService.GetAll();
    }

    public async Task<Aluno> GetById(Guid id)
    {
        return await _alunoService.GetById(id);
    }

    public async Task<Aluno> Post(AlunoDto dto)
    {
        var aluno = new Aluno()
        {
            Id = Guid.NewGuid(),
            Nome = dto.Nome,
            CPF = dto.CPF,
            Nascimento = dto.Nascimento,
            NomeMae = dto.NomeMae,
            TurmaId = dto.TurmaId,
            MensalidadeValor = dto.MensalidadeValor
        };

        return await _alunoService.Post(aluno);
    }

    public async Task<Aluno> Update(Guid id, AlunoDto dto)
    {
        var aluno = await GetById(id);

        if (aluno is null)
        {
            return aluno;
        }

        aluno.Nome = dto.Nome;
        aluno.CPF = dto.CPF;
        aluno.Nascimento = dto.Nascimento;
        aluno.NomeMae = dto.NomeMae;
        aluno.TurmaId = dto.TurmaId;
        aluno.MensalidadeValor = dto.MensalidadeValor;

        return await _alunoService.Update(aluno);
    }
}
