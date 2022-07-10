using AutoMapper;
using Mvc.Models;
using Core.Domain.Entities;

namespace ProjetoModeloDDD.Mvc.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<ClienteViewModel, Cliente>();
            CreateMap<ProdutoViewModel, Produto>();
        }
    }
}