using AutoMapper;
using ProjetoModeloDDD.Domain.Entities;
using ProjetoModeloDDD.Domain.Interfaces.Services;
using ProjetoModeloDDD.MVC.ViewModels;
using System;
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

        public ActionResult Detalhes(int id)
        {
            try
            {
                var cliente = _clienteApp.ObterPorId(id);
                var clienteViewModel = Mapper.Map<Cliente, ClienteViewModel>(cliente);

                return View(clienteViewModel);
            }
            catch (Exception ex)
            {
                ViewBag.Erro = ex.Message;
                return RedirectToAction("Index");
            }
        }

        public ActionResult Criar()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Criar(ClienteViewModel cliente)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var clienteDomain = Mapper.Map<ClienteViewModel, Cliente>(cliente);
                    _clienteApp.Adicionar(clienteDomain);

                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                ViewBag.Erro = ex.Message;
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
            try
            {
                _clienteApp.Remover(id);
            }
            catch (Exception ex)
            {
                TempData["DeleteError"] = ex.Message;
            }
            return RedirectToAction("Index");
        }
    }
}
