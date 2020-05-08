using Aplicacao.Domain.Model;
using System.Collections.Generic;

namespace Aplicacao.Domain.Interfaces.Repositories
{
    public interface IClienteSqlServerRepository
    {
        Cliente Insert(Cliente cliente);

        IEnumerable<Cliente> SelectAll();

        Cliente Select(int id);

        void Update(Cliente cliente);

        void Delete(int id);

        void SaveChanges();
    }
}
