using AutoMapper;
using ProjetoModeloDDD.Mvc.ViewModels;
using ProjetoModeloDDD.Core.Domain.Entities;

namespace ProjetoModeloDDD.Mvc.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<ClienteViewModel, Cliente>();
            CreateMap<ClienteViewModel, Produto>();
        }
    }
}