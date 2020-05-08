using AutoMapper;
using Aplicacao.Application.ViewModel;
using Aplicacao.Domain.Model;

namespace Aplicacao.Application.AutoMapperConfigs
{
    public class ClienteProfile : Profile
    {
        public ClienteProfile()
        {
            CreateMap<ClienteViewModel, Cliente>()
                .ForMember(m => m.Id, vm => vm.MapFrom(src => src.Identificador))
                .ForMember(m => m.Nome, vm => vm.MapFrom(src => src.NomeCompleto))
                .ForMember(m => m.Cadastro, vm => vm.MapFrom(src => src.DataDeCadastro))
                .ForMember(m => m.OrientacaoSexual, vm => vm.MapFrom(src => src.Sexo))
                .ReverseMap();
        }
    }
}
