using AutoMapper;
using Core.Domain.Entities;
using Core.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Mvc.Models;

namespace Mvc.Controllers
{
    public class ProdutosController : Controller
    {
        private readonly IProdutoService _produtoService;
        private readonly IClienteService _clienteService;
        public readonly IMapper _mapper;

        public ProdutosController(IProdutoService produtoApp, IClienteService clienteService, IMapper mapper)
        {
            _produtoService = produtoApp;
            _clienteService = clienteService;
            _mapper = mapper;
        }

        public ActionResult Index()
        {
            var produtosTodos = _produtoService.ObterTodos();
            var produtoViewModel = _mapper.Map<IEnumerable<Produto>, IEnumerable<ProdutoViewModel>>(produtosTodos);

            return View(produtoViewModel);
        }

        public ActionResult Details(int id)
        {
            var produto = _produtoService.ObterPorId(id);
            var produtoViewModel = _mapper.Map<Produto, ProdutoViewModel>(produto);

            return View(produtoViewModel);
        }

        public ActionResult Create()
        {
            var clientesTodos = _clienteService.ObterTodos();
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
                _produtoService.Adicionar(produtoDomain);

                return RedirectToAction("Index");
            }

            var clientesTodos = _clienteService.ObterTodos();
            ViewBag.ClienteId = new SelectList(clientesTodos, "ClienteId", "Nome", produto.ClienteId);
            return View(produto);
        }

        public ActionResult Edit(int id)
        {
            var produto = _produtoService.ObterPorId(id);
            var produtoViewModel = _mapper.Map<Produto, ProdutoViewModel>(produto);

            ViewBag.ClienteId = new SelectList(_clienteService.ObterTodos(), "ClienteId", "Nome", produtoViewModel.ClienteId);

            return View(produtoViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ProdutoViewModel produto)
        {
            if (ModelState.IsValid)
            {
                var produtoDomain = _mapper.Map<ProdutoViewModel, Produto>(produto);
                _produtoService.Atualizar(produtoDomain);

                return RedirectToAction("Index");
            }

            var clientesTodos = _clienteService.ObterTodos();

            ViewBag.ClienteId = new SelectList(clientesTodos, "ClienteId", "Nome", produto.ClienteId);
            return View(produto);
        }

        public ActionResult Delete(int id)
        {
            var produto = _produtoService.ObterPorId(id);
            var produtoViewModel = _mapper.Map<Produto, ProdutoViewModel>(produto);

            return View(produtoViewModel);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var produto = _produtoService.ObterPorId(id);
            _produtoService.Remover(produto);

            return RedirectToAction("Index");
        }
    }
}