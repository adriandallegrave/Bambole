using Bambole.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace Bambole.Persistence;

public class BamboleContext : DbContext
{
    public BamboleContext(DbContextOptions<BamboleContext> options) : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.ConfigureWarnings(warning => warning.Ignore(CoreEventId.MultipleNavigationProperties));
    }

    public DbSet<Turma> Turmas { get; set; }
    public DbSet<Professor> Professores { get; set; }
    public DbSet<Aluno> Alunos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Professor

        modelBuilder.Entity<Professor>()
            .ToTable("Professores")
            .HasKey(professor => professor.Id);
        modelBuilder.Entity<Professor>()
            .Property(professor => professor.Nome)
            .HasMaxLength(100)
            .IsRequired();
        modelBuilder.Entity<Professor>()
            .Property(professor => professor.CPF)
            .HasMaxLength(11)
            .IsRequired();

        // Turma

        modelBuilder.Entity<Turma>()
            .ToTable("Turmas")
            .HasKey(turma => turma.Id);
        modelBuilder.Entity<Turma>()
            .Property(turma => turma.Nome)
            .HasMaxLength(100)
            .IsRequired();
        modelBuilder.Entity<Turma>()
            .Property(turma => turma.ProfessorId)
            .IsRequired();

        // Aluno

        modelBuilder.Entity<Aluno>()
            .ToTable("Alunos")
            .HasKey(bet => bet.Id);
        modelBuilder.Entity<Aluno>()
            .Property(aluno => aluno.Nome)
            .HasMaxLength(100)
            .IsRequired();
        modelBuilder.Entity<Aluno>()
            .Property(aluno => aluno.CPF)
            .HasMaxLength(11)
            .IsRequired();
        modelBuilder.Entity<Aluno>()
            .Property(aluno => aluno.NomeMae)
            .HasMaxLength(100)
            .IsRequired();
        modelBuilder.Entity<Aluno>()
            .Property(aluno => aluno.TurmaId)
            .IsRequired();
        modelBuilder.Entity<Aluno>()
            .Property(aluno => aluno.Nascimento)
            .HasColumnType("datetime2")
            .IsRequired();

        // Inserts

        var firstGuid = Guid.NewGuid();
        var secondGuid = Guid.NewGuid();
        var thirdGuid = Guid.NewGuid();
        var fourthGuid = Guid.NewGuid();

        modelBuilder.Entity<Professor>()
            .HasData(new Professor()
            {
                Id = firstGuid,
                Nome = "Larissa Oliveira",
                CPF = "12345678910"
            });
        modelBuilder.Entity<Professor>()
            .HasData(new Professor()
            {
                Id = secondGuid,
                Nome = "Mariana Santos",
                CPF = "23456789021"
            });

        modelBuilder.Entity<Turma>()
            .HasData(new Turma()
            {
                Id = thirdGuid,
                Nome = "Aline Silva",
                ProfessorId = firstGuid
            });
        modelBuilder.Entity<Turma>()
            .HasData(new Turma()
            {
                Id = fourthGuid,
                Nome = "Isabela Costa",
                ProfessorId = secondGuid
            });

        modelBuilder.Entity<Aluno>()
            .HasData(new Aluno()
            {
                Id = Guid.NewGuid(),
                Nome = "Ana Luiza Pereira",
                CPF = "34567890132",
                MensalidadeValor = 40,
                NomeMae = "Gabriela Souza",
                Nascimento = DateOnly.MinValue,
                TurmaId = thirdGuid
            });
        modelBuilder.Entity<Aluno>()
            .HasData(new Aluno()
            {
                Id = Guid.NewGuid(),
                Nome = "Juliana Rodrigues",
                CPF = "45678901243",
                MensalidadeValor = 40,
                NomeMae = "Fernanda Almeida",
                Nascimento = DateOnly.MinValue,
                TurmaId = thirdGuid
            });
        modelBuilder.Entity<Aluno>()
            .HasData(new Aluno()
            {
                Id = Guid.NewGuid(),
                Nome = "Carolina Lima",
                CPF = "56789012354",
                MensalidadeValor = 40,
                NomeMae = "Bianca Fernandes",
                Nascimento = DateOnly.MinValue,
                TurmaId = thirdGuid
            });
        modelBuilder.Entity<Aluno>()
            .HasData(new Aluno()
            {
                Id = Guid.NewGuid(),
                Nome = "Livia Ribeiro",
                CPF = "67890123465",
                MensalidadeValor = 40,
                NomeMae = "Thais Ferreira",
                Nascimento = DateOnly.MinValue,
                TurmaId = thirdGuid
            });

        // aaaaaaaaaaaa

        modelBuilder.Entity<Aluno>()
            .HasData(new Aluno()
            {
                Id = Guid.NewGuid(),
                Nome = "Priscila Costa",
                CPF = "89012345687",
                MensalidadeValor = 40,
                NomeMae = "Camila Barbosa",
                Nascimento = DateOnly.MinValue,
                TurmaId = fourthGuid
            });
        modelBuilder.Entity<Aluno>()
            .HasData(new Aluno()
            {
                Id = Guid.NewGuid(),
                Nome = "Nathalia Santos",
                CPF = "78901234576",
                MensalidadeValor = 40,
                NomeMae = "Lorena Martins",
                Nascimento = DateOnly.MinValue,
                TurmaId = fourthGuid
            });
        modelBuilder.Entity<Aluno>()
            .HasData(new Aluno()
            {
                Id = Guid.NewGuid(),
                Nome = "Beatriz Gomes",
                CPF = "90123456798",
                MensalidadeValor = 40,
                NomeMae = "Raquel Cardoso",
                Nascimento = DateOnly.MinValue,
                TurmaId = fourthGuid
            });
        modelBuilder.Entity<Aluno>()
            .HasData(new Aluno()
            {
                Id = Guid.NewGuid(),
                Nome = "Renata Oliveira",
                CPF = "76543210988",
                MensalidadeValor = 40,
                NomeMae = "Amanda Castro",
                Nascimento = DateOnly.MinValue,
                TurmaId = fourthGuid
            });
    }
}
