using Microsoft.EntityFrameworkCore;
using Aplicacao.Domain.Interfaces.Repositories;
using Aplicacao.Domain.Model;
using System.Collections.Generic;

namespace Aplicacao.Infra.DataAccess.Repositories.SQL
{
    public class ClienteSQLRepository : IClienteSqlServerRepository
    {
        private DbContext _context;

        public ClienteSQLRepository(DbContext context)
        {
            _context = context;
        }

        public IEnumerable<Cliente> SelectAll()
        {
            return _context.Set<Cliente>();
        }

        public Cliente Select(int id)
        {
            return _context.Set<Cliente>().Find(id);
        }

        public Cliente Insert(Cliente cliente)
        {
            return _context.Set<Cliente>().Add(cliente).Entity;
        }

        public void Update(Cliente cliente)
        {
            _context.Set<Cliente>().Update(cliente);
        }

        public void Delete(int id)
        {
            var clienteTemp = this.Select(id);
            _context.Set<Cliente>().Remove(clienteTemp);

        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
