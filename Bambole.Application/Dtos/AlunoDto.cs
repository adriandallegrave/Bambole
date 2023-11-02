namespace Bambole.Application.Dtos;

public class AlunoDto
{
    public string Nome { get; set; }
    public string CPF { get; set; }
    public DateOnly Nascimento { get; set; }
    public string NomeMae { get; set; }
    public Guid TurmaId { get; set; }
    public float MensalidadeValor { get; set; }
}
