using Bambole.Domain.Interfaces;
using Bambole.Domain.Interfaces.Repositories;
using Bambole.Persistence.Repositories;

namespace Bambole.Persistence;

public class RepositoryWrapper : IRepositoryWrapper
{
    private readonly BamboleContext _context;

    private ITurmaRepository _turmaRepository;
    private IAlunoRepository _alunoRepository;
    private IProfessorRepository _professorRepository;

    public RepositoryWrapper(BamboleContext context)
    {
        _context = context;
    }

    public ITurmaRepository Turma
    {
        get
        {
            _turmaRepository ??= new TurmaRepository(_context);
            return _turmaRepository;
        }
    }

    public IAlunoRepository Aluno
    {
        get
        {
            _alunoRepository ??= new AlunoRepository(_context);
            return _alunoRepository;
        }
    }

    public IProfessorRepository Professor
    {
        get
        {
            _professorRepository ??= new ProfessorRepository(_context);
            return _professorRepository;
        }
    }

    public async Task<bool> Commit()
    {
        var rowsAffected = await _context.SaveChangesAsync();
        return rowsAffected > 0;
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}
