
using System.Collections.Generic;
using ProjetoModeloDDD.Domain.Entities;

namespace ProjetoModeloDDD.Application.Interface
{
    public interface IClienteAppService
    {
        IEnumerable<Cliente> ObterClientesEspeciais();
    }
}
