using Microsoft.Extensions.Caching.Distributed;
using Aplicacao.Domain.Interfaces.Repositories;
using Aplicacao.Domain.Model;
using Aplicacao.Infra.DataAccess.Util;
using System.Collections.Generic;
using System.Text.Json;

namespace Aplicacao.Infra.DataAccess.Repositories.Redis
{
    public class ClienteRedisRepository : IClienteRedisRepository
    {
        private readonly IDistributedCache _cacheRedis;

        public ClienteRedisRepository(IDistributedCache cacheRedis)
        {
            _cacheRedis = cacheRedis;
        }

        public void Set(Cliente cliente)
        {
            var ClienteJson = JsonSerializer.Serialize<Cliente>(cliente,
                new JsonSerializerOptions
                {
                    WriteIndented = true,
                });

            _cacheRedis.SetString(
                $"{nameof(ClienteRedisRepository)}:{cliente.Id}", ClienteJson);
        }

        public void Setm(IEnumerable<Cliente> clientes)
        {
            var ClienteJson = JsonSerializer.Serialize<IEnumerable<Cliente>>(clientes,
               new JsonSerializerOptions
               {
                   WriteIndented = true,
               });

            _cacheRedis.SetString(
                $"{nameof(ClienteRedisRepository)}", ClienteJson);
        }

        public Cliente Get(int key)
        {
            var cliente = _cacheRedis.GetString(
                $"{nameof(ClienteRedisRepository)}:{key}");

            if (!string.IsNullOrEmpty(cliente))
            {
                return ConverterSimpleJson<Cliente>.CriarJson(cliente);
                //return JsonSerializer.Deserialize<Cliente>(cliente,
                //    new JsonSerializerOptions
                //    {
                //        WriteIndented = true
                //    });
            }
            else
            {
                return null;
            }
        }

        public IEnumerable<Cliente> Getm()
        {
            var cliente = _cacheRedis.GetString(
                $"{nameof(ClienteRedisRepository)}");

            if (!string.IsNullOrEmpty(cliente))
            {
                return JsonSerializer.Deserialize<IEnumerable<Cliente>>(cliente,
                    new JsonSerializerOptions
                    {
                        WriteIndented = true
                    });
            }
            else
            {
                return null;
            }
        }

        public void Remove(int key)
        {
            _cacheRedis.Remove($"{nameof(ClienteRedisRepository)}:{key}");
        }
    }
}