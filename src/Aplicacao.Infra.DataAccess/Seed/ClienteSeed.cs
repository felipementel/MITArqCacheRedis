using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Aplicacao.Domain.Model;
using System;

namespace Aplicacao.Infra.DataAccess.Seed
{
    public class ClienteSeed : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.ToTable("Clientes");

            builder.HasData(
                new Cliente { Id = 1, Nome = "Felipe", Cadastro = DateTime.Now, OrientacaoSexual = Sexo.Masculino },
                new Cliente { Id = 2, Nome = "Rafael", Cadastro = DateTime.Now, OrientacaoSexual = Sexo.Masculino },
                new Cliente { Id = 3, Nome = "Denise", Cadastro = DateTime.Now, OrientacaoSexual = Sexo.Feminino },
                new Cliente { Id = 4, Nome = "Carlos", Cadastro = DateTime.Now, OrientacaoSexual = Sexo.Masculino },
                new Cliente { Id = 5, Nome = "Fernando", Cadastro = DateTime.Now, OrientacaoSexual = Sexo.Masculino },
                new Cliente { Id = 6, Nome = "Flavia", Cadastro = DateTime.Now, OrientacaoSexual = Sexo.Feminino },
                new Cliente { Id = 7, Nome = "Jose", Cadastro = DateTime.Now, OrientacaoSexual = Sexo.Masculino },
                new Cliente { Id = 8, Nome = "Manuel", Cadastro = DateTime.Now, OrientacaoSexual = Sexo.Masculino },
                new Cliente { Id = 9, Nome = "Carla", Cadastro = DateTime.Now, OrientacaoSexual = Sexo.Feminino },
                new Cliente { Id = 10, Nome = "Joao", Cadastro = DateTime.Now, OrientacaoSexual = Sexo.Masculino },
                new Cliente { Id = 11, Nome = "Hugo", Cadastro = DateTime.Now, OrientacaoSexual = Sexo.Masculino },
                new Cliente { Id = 12, Nome = "Maria", Cadastro = DateTime.Now, OrientacaoSexual = Sexo.Feminino },
                new Cliente { Id = 13, Nome = "Luiz", Cadastro = DateTime.Now, OrientacaoSexual = Sexo.Masculino },
                new Cliente { Id = 14, Nome = "Marcio", Cadastro = DateTime.Now, OrientacaoSexual = Sexo.Masculino },
                new Cliente { Id = 15, Nome = "Amanada", Cadastro = DateTime.Now, OrientacaoSexual = Sexo.Feminino },
                new Cliente { Id = 16, Nome = "Vinicius", Cadastro = DateTime.Now, OrientacaoSexual = Sexo.Masculino },
                new Cliente { Id = 17, Nome = "Romulo", Cadastro = DateTime.Now, OrientacaoSexual = Sexo.Masculino },
                new Cliente { Id = 18, Nome = "Daniela", Cadastro = DateTime.Now, OrientacaoSexual = Sexo.Feminino }
                );
        }
    }
}
