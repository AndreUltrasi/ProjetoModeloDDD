using AutoMapper;
using ProjetoModeloDDD.Mvc.ViewModels;
using ProjetoModeloDDD.Core.Domain.Entities;

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