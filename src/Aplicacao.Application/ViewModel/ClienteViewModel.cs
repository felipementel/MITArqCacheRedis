using System;

namespace Aplicacao.Application.ViewModel
{
    public class ClienteViewModel
    {
        public int Identificador { get; set; }

        public string NomeCompleto { get; set; }

        public DateTime DataDeCadastro { get; set; }

        public Sexo Sexo { get; set; }
    }

    public enum Sexo
    {
        Feminino = 1,
        Masculino
    }
}
