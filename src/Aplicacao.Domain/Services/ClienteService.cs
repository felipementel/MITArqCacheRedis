using Microsoft.Extensions.Caching.Distributed;
using Aplicacao.Domain.Interfaces.Repositories;
using Aplicacao.Domain.Interfaces.Services;
using Aplicacao.Domain.Model;
using System.Collections.Generic;
using System.Text.Json;

namespace Aplicacao.Domain.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteSqlServerRepository _clienteSQLServerRepository;

        private readonly IClienteRedisRepository _clienteRedisRepository;

        public ClienteService(IClienteSqlServerRepository clienteSQLServerRepository, IClienteRedisRepository clienteRedisRepository)
        {
            _clienteSQLServerRepository = clienteSQLServerRepository;
            _clienteRedisRepository = clienteRedisRepository;
        }

        public void Add(Cliente cliente)
        {
            Cliente clienteProcessado = _clienteSQLServerRepository.Insert(cliente);

            _clienteSQLServerRepository.SaveChanges();

            _clienteRedisRepository.Set(clienteProcessado);
        }

        public Cliente Get(int id)
        {
            var valorCache = _clienteRedisRepository.Get(id);

            if (valorCache != null)
            {
                return valorCache;
            }
            else
            {
                var Cliente = _clienteSQLServerRepository.Select(id);

                _clienteRedisRepository.Set(Cliente);

                return Cliente;
            }
        }

        public IEnumerable<Cliente> GetAll()
        {
            var valorCache = _clienteRedisRepository.Getm();

            if (valorCache != null)
            {
                return valorCache;
            }
            else
            {
                var Cliente = _clienteSQLServerRepository.SelectAll();

                _clienteRedisRepository.Setm(Cliente);

                return Cliente;
            }
        }

        public void Remove(int id)
        {
            _clienteSQLServerRepository.Delete(id);
            _clienteRedisRepository.Remove(id);
        }

        public void Update(Cliente cliente)
        {
            _clienteSQLServerRepository.Update(cliente);

            JsonSerializer.Serialize<Cliente>(cliente,
                   new JsonSerializerOptions
                   {
                       WriteIndented = true
                   });

            _clienteRedisRepository.Set(cliente);
        }
    }
}
