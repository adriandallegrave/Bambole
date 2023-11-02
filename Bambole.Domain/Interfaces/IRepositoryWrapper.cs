using Bambole.Domain.Interfaces.Repositories;

namespace Bambole.Domain.Interfaces;

public interface IRepositoryWrapper
{
    IProfessorRepository Professor { get; }
    IAlunoRepository Aluno { get; }
    ITurmaRepository Turma { get; }

    Task<bool> Commit();

    void Dispose();
}
