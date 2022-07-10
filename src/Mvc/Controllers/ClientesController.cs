using AutoMapper;
using Core.Domain.Entities;
using Core.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Mvc.Models;

namespace Mvc.Controllers
{
    public class ClientesController : Controller
    {
        private readonly IClienteService _clienteApp;
        public readonly IMapper _mapper;

        public ClientesController(IClienteService clienteApp,
                                  IMapper mapper)
        {
            _clienteApp = clienteApp;
            _mapper = mapper;
        }

        public ActionResult Index()
        {
            var clientesTodos = _clienteApp.ObterTodos();
            var clienteViewModel = _mapper.Map<IEnumerable<Cliente>, IEnumerable<ClienteViewModel>>(clientesTodos);

            return View(clienteViewModel);
        }

        public ActionResult Especiais()
        {
            var clientesEspeciais = _clienteApp.ObterClientesEspeciais();
            var clienteViewModel = _mapper.Map<IEnumerable<Cliente>, IEnumerable<ClienteViewModel>>(clientesEspeciais);

            return View(clienteViewModel);
        }

        public ActionResult Details(int id)
        {
            var cliente = _clienteApp.ObterPorId(id);
            var clienteViewModel = _mapper.Map<Cliente, ClienteViewModel>(cliente);

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
                var clienteDomain = _mapper.Map<ClienteViewModel, Cliente>(cliente);
                _clienteApp.Adicionar(clienteDomain);

                return RedirectToAction("Index");
            }

            return View(cliente);
        }

        public ActionResult Edit(int id)
        {
            var cliente = _clienteApp.ObterPorId(id);
            var clienteViewModel = _mapper.Map<Cliente, ClienteViewModel>(cliente);

            return View(clienteViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ClienteViewModel cliente)
        {
            if (ModelState.IsValid)
            {
                var clienteDomain = _mapper.Map<ClienteViewModel, Cliente>(cliente);
                _clienteApp.Atualizar(clienteDomain);

                return RedirectToAction("Index");
            }

            return View(cliente);
        }

        public ActionResult Delete(int id)
        {
            var cliente = _clienteApp.ObterPorId(id);
            var clienteViewModel = _mapper.Map<Cliente, ClienteViewModel>(cliente);
            return View(clienteViewModel);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _clienteApp.Remover(id);
            return RedirectToAction("Index");
        }
    }
}
