using AutoMapper;
using ProjetoModeloDDD.Domain.Entities;
using ProjetoModeloDDD.Domain.Interfaces.Services;
using ProjetoModeloDDD.MVC.ViewModels;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Web.Routing;

namespace ProjetoModeloDDD.MVC.Controllers
{
    public class ClientesController : Controller
    {
        private readonly IClienteService _clienteApp;

        public ClientesController(IClienteService clienteApp)
        {
            _clienteApp = clienteApp;
        }

        protected override void OnException(ExceptionContext filterContext)
        {
            TempData["Erro"] = filterContext.Exception.Message;

            filterContext.Result = new RedirectToRouteResult(
                                       new RouteValueDictionary(new { controller = "Clientes", action = "Index" }));
            
        }

        public ActionResult Index()
        {
            var clientesTodos = _clienteApp.ObterTodos();
            var clienteViewModel = Mapper.Map<IEnumerable<Cliente>, IEnumerable<ClienteViewModel>>(clientesTodos);

            return View(clienteViewModel);
        }

        public ActionResult Especiais()
        {
            var clientesEspeciais = _clienteApp.ObterClientesEspeciais();
            var clienteViewModel = Mapper.Map<IEnumerable<Cliente>, IEnumerable<ClienteViewModel>>(clientesEspeciais);

            return View(clienteViewModel);
        }

        public ActionResult Detalhes(int id)
        {
            var cliente = _clienteApp.ObterPorId(id);
            var clienteViewModel = Mapper.Map<Cliente, ClienteViewModel>(cliente);

            return View(clienteViewModel);
        }

        public ActionResult Criar()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Criar(ClienteViewModel cliente)
        {
            if (ModelState.IsValid)
            {
                var clienteDomain = Mapper.Map<ClienteViewModel, Cliente>(cliente);
                _clienteApp.Adicionar(clienteDomain);

                return RedirectToAction("Index");
            }

            return View(cliente);
        }

        public ActionResult Editar(int id)
        {
            var cliente = _clienteApp.ObterPorId(id);
            var clienteViewModel = Mapper.Map<Cliente, ClienteViewModel>(cliente);

            return View(clienteViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(ClienteViewModel cliente)
        {
            if (ModelState.IsValid)
            {
                var clienteDomain = Mapper.Map<ClienteViewModel, Cliente>(cliente);
                _clienteApp.Atualizar(clienteDomain);

                return RedirectToAction("Index");
            }

            return View(cliente);
        }

        public ActionResult Deletar(int id)
        {
            var cliente = _clienteApp.ObterPorId(id);
            var clienteViewModel = Mapper.Map<Cliente, ClienteViewModel>(cliente);
            return View(clienteViewModel);
        }

        [HttpPost, ActionName("Deletar")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _clienteApp.Remover(id);
            return RedirectToAction("Index");
        }
    }
}
