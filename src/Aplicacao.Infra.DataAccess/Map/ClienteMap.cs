using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Aplicacao.Domain.Model;
using System;

namespace Aplicacao.Infra.DataAccess.Map
{
    public class ClienteMap : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.ToTable("Clientes");

            builder
                .HasKey(pk => pk.Id)
                .HasName("Identificador");

            builder.Property(p => p.Id)
                .ValueGeneratedOnAdd();

            builder
                .Property(n => n.Nome)
                .HasColumnName("nm_nome")
                .HasMaxLength(300)
                .IsRequired();

            builder
                .Property(n => n.Cadastro)
                .HasColumnName("dt_cadastro")
                .HasDefaultValue(DateTime.Now)
                .IsRequired();

            builder
                .Property(n => n.OrientacaoSexual)
                .HasColumnName("nm_sexo")
                .HasMaxLength(100)
                .IsRequired()
                .HasConversion(
                s => s.ToString(),
                s => (Sexo)Enum.Parse(typeof(Sexo), s));
        }
    }
}
