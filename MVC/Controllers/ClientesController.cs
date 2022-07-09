using AutoMapper;
using ProjetoModeloDDD.Domain.Entities;
using ProjetoModeloDDD.Domain.Interfaces.Services;
using ProjetoModeloDDD.MVC.ViewModels;
using System.Collections.Generic;
using System.Web.Mvc;

namespace ProjetoModeloDDD.MVC.Controllers
{
    public class ClientesController : Controller
    {
        private readonly IClienteService _clienteApp;

        public ClientesController(IClienteService clienteApp)
        {
            _clienteApp = clienteApp;
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

        public ActionResult Details(int id)
        {
            var cliente = _clienteApp.ObterPorId(id);
            var clienteViewModel = Mapper.Map<Cliente, ClienteViewModel>(cliente);

            return View(clienteViewModel);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ClienteViewModel cliente)
        {
            if (ModelState.IsValid)
            {
                var clienteDomain = Mapper.Map<ClienteViewModel, Cliente>(cliente);
                _clienteApp.Adicionar(clienteDomain);

                return RedirectToAction("Index");
            }

            return View(cliente);
        }

        public ActionResult Edit(int id)
        {
            var cliente = _clienteApp.ObterPorId(id);
            var clienteViewModel = Mapper.Map<Cliente, ClienteViewModel>(cliente);

            return View(clienteViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ClienteViewModel cliente)
        {
            if (ModelState.IsValid)
            {
                var clienteDomain = Mapper.Map<ClienteViewModel, Cliente>(cliente);
                _clienteApp.Atualizar(clienteDomain);

                return RedirectToAction("Index");
            }

            return View(cliente);
        }

        public ActionResult Delete(int id)
        {
            var cliente = _clienteApp.ObterPorId(id);
            var clienteViewModel = Mapper.Map<Cliente, ClienteViewModel>(cliente);

            return View(clienteViewModel);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var cliente = _clienteApp.ObterPorId(id);
            _clienteApp.Remover(cliente);

            return RedirectToAction("Index");
        }
    }
}
