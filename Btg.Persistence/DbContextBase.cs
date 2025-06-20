﻿using Btg.Core.Entities;
using Microsoft.EntityFrameworkCore;


namespace Btg.Persistence;

public class DbContextBase : DbContext
{
    public DbSet<Client> Clients { get; set; }
    
    public DbContextBase(DbContextOptions<DbContextBase> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("dbo");

       
        modelBuilder.Entity<Client>(entity =>
        {
            entity.ToTable("Clients"); // Nome da tabela no banco
            entity.HasKey(c => c.Id);   // Define Id como chave primária
            entity.Property(c => c.Id)
                  .ValueGeneratedOnAdd(); // Configura auto-incremento (se for identity)

            entity.Property(c => c.Name)
                  .IsRequired()          // Torna o campo obrigatório
                  .HasMaxLength(100);    // Define tamanho máximo

            entity.Property(c => c.LastName)
                    .IsRequired()
                    .HasMaxLength(100);
            entity.Property(c => c.Age)
                    .IsRequired()
                    .HasMaxLength(3);
            entity.Property(c => c.Andress)
                    .IsRequired()
                    .HasMaxLength(200);

        });
    }
}