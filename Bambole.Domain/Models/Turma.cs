namespace Bambole.Domain.Models;

public class Turma
{
    public Guid Id { get; set; }
    public string Nome { get; set; }
    public Guid ProfessorId { get; set; }
}
