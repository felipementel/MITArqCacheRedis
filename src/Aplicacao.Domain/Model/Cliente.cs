using System;

namespace Aplicacao.Domain.Model
{
    public class Cliente
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public DateTime Cadastro { get; set; }

        public Sexo OrientacaoSexual { get; set; }
    }

    public enum Sexo
    {
        Feminino = 1,
        Masculino
    }
}
