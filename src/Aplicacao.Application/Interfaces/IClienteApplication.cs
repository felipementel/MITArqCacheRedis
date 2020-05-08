using Aplicacao.Application.ViewModel;
using System;
using System.Collections.Generic;

namespace Aplicacao.Application.Interfaces
{
    public interface IClienteApplication : IDisposable
    {
        void Add(ClienteViewModel cliente);

        IEnumerable<ClienteViewModel> GetAll();

        ClienteViewModel Get(int id);

        void Update(ClienteViewModel cliente);

        void Remove(int id);
    }
}