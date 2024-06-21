using AutoMapper;
using Core.Domain.Entities;
using Core.Interfaces.UseCases;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Mvc.Models;
using System;

namespace Mvc.Controllers
{
    public class ProdutosController : Controller
    {
        private readonly IProdutoUseCase _produtoUseCase;
        public readonly IMapper _mapper;

        public ProdutosController(IProdutoUseCase produtoUseCase, 
                                  IMapper mapper)
        {
            _produtoUseCase = produtoUseCase;
            _mapper = mapper;
        }

        public ActionResult Index()
        {
            var produtosTodos = _produtoUseCase.ObterTodos();
            var produtoViewModel = _mapper.Map<IEnumerable<Produto>, IEnumerable<ProdutoViewModel>>(produtosTodos);

            return View(produtoViewModel);
        }

        public ActionResult Details(int id)
        {
            var produto = _produtoUseCase.ObterPorId(id);
            var produtoViewModel = _mapper.Map<Produto, ProdutoViewModel>(produto);

            return View(produtoViewModel);
        }

        public ActionResult Create()
        {
            var clientesTodos = _produtoUseCase.ObterTodosClientes();
            ViewBag.ClienteId = new SelectList(clientesTodos, "ClienteId", "Nome");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProdutoViewModel produto)
        {
            if (ModelState.IsValid)
            {
                var produtoDomain = _mapper.Map<ProdutoViewModel, Produto>(produto);
                _produtoUseCase.Adicionar(produtoDomain);

                return RedirectToAction("Index");
            }

            var clientesTodos = _produtoUseCase.ObterTodosClientes();
            ViewBag.ClienteId = new SelectList(clientesTodos, "ClienteId", "Nome", produto.ClienteId);
            return View(produto);
        }

        public ActionResult Edit(int id)
        {
            var produto = _produtoUseCase.ObterPorId(id);
            var produtoViewModel = _mapper.Map<Produto, ProdutoViewModel>(produto);
            var clientesTodos = _produtoUseCase.ObterTodosClientes();

            ViewBag.ClienteId = new SelectList(clientesTodos, "ClienteId", "Nome", produtoViewModel.ClienteId);

            return View(produtoViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ProdutoViewModel produto)
        {
            if (ModelState.IsValid)
            {
                var produtoDomain = _mapper.Map<ProdutoViewModel, Produto>(produto);
                _produtoUseCase.Atualizar(produtoDomain);

                return RedirectToAction("Index");
            }

            var clientesTodos = _produtoUseCase.ObterTodosClientes();

            ViewBag.ClienteId = new SelectList(clientesTodos, "ClienteId", "Nome", produto.ClienteId);
            return View(produto);
        }

        public ActionResult Delete(int id)
        {
            var produto = _produtoUseCase.ObterPorId(id);
            var produtoViewModel = _mapper.Map<Produto, ProdutoViewModel>(produto);

            return View(produtoViewModel);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var produto = _produtoUseCase.ObterPorId(id);
            _produtoUseCase.Remover(produto);

            return RedirectToAction("Index");
        }
    }
}