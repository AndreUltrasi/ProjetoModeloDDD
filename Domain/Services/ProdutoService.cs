
using ProjetoModeloDDD.Domain.Entities;
using ProjetoModeloDDD.Domain.Interfaces.Repositories;
using ProjetoModeloDDD.Domain.Interfaces.Services;
using System.Collections.Generic;

namespace ProjetoModeloDDD.Domain.Services
{
    public class ProdutoService : IProdutoService
    {
        private readonly IProdutoRepository _produtoRepository;

        public ProdutoService(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        public IEnumerable<Produto> BuscarPorNome(string nome)
        {
            return _produtoRepository.BuscarPorNome(nome);
        }

        public Produto ObterPorId(int id)
        {
            return _produtoRepository.ObterPorId(id);
        }

        public IEnumerable<Produto> ObterTodos()
        {
            return _produtoRepository.ObterTodos();
        }

        public void Adicionar(Produto produto)
        {
            _produtoRepository.Adicionar(produto);
        }
        public void Atualizar(Produto produto)
        {
            _produtoRepository.Atualizar(produto);
        }
        public void Remover(Produto produto)
        {
            _produtoRepository.Remover(produto);
        }
    }
}
