using Btg.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace Btg.Persistence;

public class DbContextBase : DbContext
{
    public DbSet<Cliente> Clientes { get; set; }
    
    public DbContextBase(DbContextOptions<DbContextBase> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("dbo");

       
        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.ToTable("Clientes"); // Nome da tabela no banco
            entity.HasKey(c => c.Id);   // Define Id como chave primária
            entity.Property(c => c.Id)
                  .ValueGeneratedOnAdd(); // Configura auto-incremento (se for identity)

            entity.Property(c => c.Name)
                  .IsRequired()          // Torna o campo obrigatório
                  .HasMaxLength(100);    // Define tamanho máximo
        });
    }
}