using Aplicacao.Domain.Model;
using System.Collections.Generic;

namespace Aplicacao.Domain.Interfaces.Repositories
{
    public interface IClienteRedisRepository
    {
        void Set(Cliente cliente);

        void Setm(IEnumerable<Cliente> clientes);

        IEnumerable<Cliente> Getm();

        Cliente Get(int key);

        void Remove(int key);
    }
}