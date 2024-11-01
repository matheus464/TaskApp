using Gerenciador_de_Tarefas.Model;
using System.Collections.Generic;
using System.Data.Common;

using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Pessoa> Pessoas { get; set; }
    public DbSet<Tarefa> Tarefas { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder) // Configuração Explicita relacionamento entre tarefa e pessoa.
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Tarefa>()
            .HasOne(t => t.PessoaResponsavel)
            .WithMany(p => p.Tarefas)
            .HasForeignKey(t => t.IdPessoaResponsavel)
            .OnDelete(DeleteBehavior.SetNull);
    }
}
