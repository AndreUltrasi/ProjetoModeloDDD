using AutoMapper;
using Core.Domain.Entities;
using Mvc.Models;

namespace ProjetoModeloDDD.Mvc.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<Cliente, ClienteViewModel>();
            CreateMap<Produto, ProdutoViewModel>();
        }
    }
}