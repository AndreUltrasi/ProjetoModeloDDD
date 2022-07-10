
using ProjetoModeloDDD.Domain.Entities;
using ProjetoModeloDDD.Domain.Interfaces.Repositories;
using ProjetoModeloDDD.Domain.Interfaces.Services;
using System;
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

        public IEnumerable<Produto> ObterPorNome(string nome)
        {
            var produto = _produtoRepository.BuscarPorNome(nome);
            return produto;
        }

        public Produto ObterPorId(int id)
        {
            try
            {
                var produto = _produtoRepository.ObterPorId(id);
                return produto;
            }
            catch (Exception ex)
            {
                throw new Exception($"Ocorreu um erro ao obter o produto da base | Erro: {ex.Message}");
            }
        }

        public IEnumerable<Produto> ObterTodos()
        {
            try
            {
                var produtosTodos = _produtoRepository.ObterTodos();
                return produtosTodos;
            }
            catch (Exception ex)
            {
                throw new Exception($"Ocorreu um erro ao obter todos os produto da base | Erro: {ex.Message}");
            }
        }

        public bool Adicionar(Produto produto)
        {
            try
            {
                _produtoRepository.Adicionar(produto);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception($"Ocorreu um erro ao adicionar o produto na base | Erro: {ex.Message}");
            }
        }
        public bool Atualizar(Produto produto)
        {
            try
            {
                _produtoRepository.Atualizar(produto);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception($"Ocorreu um erro ao obter o produto da base | Erro: {ex.Message}");
            }
        }
        public bool Remover(Produto produto)
        {
            try
            {
                _produtoRepository.Remover(produto);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception($"Ocorreu um erro ao remover o produto da base | Erro: {ex.Message}");
            }
        }
    }
}
