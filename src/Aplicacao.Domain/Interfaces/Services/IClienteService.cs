using Aplicacao.Domain.Model;
using System.Collections.Generic;

namespace Aplicacao.Domain.Interfaces.Services
{
    public interface IClienteService
    {
        void Add(Cliente cliente);

        IEnumerable<Cliente> GetAll();

        Cliente Get(int id);

        void Update(Cliente cliente);

        void Remove(int id);
    }
}
