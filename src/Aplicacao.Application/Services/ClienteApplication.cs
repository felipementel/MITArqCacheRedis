using AutoMapper;
using Aplicacao.Application.Interfaces;
using Aplicacao.Application.ViewModel;
using Aplicacao.Domain.Interfaces.Services;
using Aplicacao.Domain.Model;
using System;
using System.Collections.Generic;

namespace Aplicacao.Application.Services
{
    public class ClienteApplication : IClienteApplication
    {
        private readonly IMapper _mapper;

        private readonly IClienteService _clienteService;

        public ClienteApplication(IMapper mapper, IClienteService clienteService)
        {
            _mapper = mapper;
            _clienteService = clienteService;
        }

        public void Add(ClienteViewModel clienteViewModel)
        {
            _clienteService.Add(_mapper.Map<Cliente>(clienteViewModel));
        }

        public ClienteViewModel Get(int id)
        {
            return _mapper.Map<ClienteViewModel>(_clienteService.Get(id));
        }

        public IEnumerable<ClienteViewModel> GetAll()
        {
            return _mapper.Map<IEnumerable<ClienteViewModel>>(_clienteService.GetAll());
        }

        public void Remove(int id)
        {
            _clienteService.Remove(id);
        }

        public void Update(ClienteViewModel clienteViewModel)
        {
            _clienteService.Update(_mapper.Map<Cliente>(clienteViewModel));
        }


        private bool disposedValue;
        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
                disposedValue = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
