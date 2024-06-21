using AutoMapper;
using Core.Domain.Entities;
using Core.Interfaces.UseCases;
using Microsoft.AspNetCore.Mvc;
using Mvc.Models;
using System;

namespace Mvc.Controllers
{
    public class ClientesController : Controller
    {
        private readonly IClienteUseCase _clienteUseCase;
        public readonly IMapper _mapper;

        public ClientesController(IClienteUseCase clienteUseCase,
                                  IMapper mapper)
        {
            _clienteUseCase = clienteUseCase;
            _mapper = mapper;
        }

        public ActionResult Index()
        {
            var clientesTodos = _clienteUseCase.ObterTodos();
            var clienteViewModel = _mapper.Map<IEnumerable<Cliente>, IEnumerable<ClienteViewModel>>(clientesTodos);

            return View(clienteViewModel);
        }

        public ActionResult Especiais()
        {
            var clientesEspeciais = _clienteUseCase.ObterClientesEspeciais();
            var clienteViewModel = _mapper.Map<IEnumerable<Cliente>, IEnumerable<ClienteViewModel>>(clientesEspeciais);

            return View(clienteViewModel);
        }

        public ActionResult Details(int id)
        {
            var cliente = _clienteUseCase.ObterPorId(id);
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
                _clienteUseCase.Adicionar(clienteDomain);

                return RedirectToAction("Index");
            }

            return View(cliente);
        }

        public ActionResult Edit(int id)
        {
            var cliente = _clienteUseCase.ObterPorId(id);
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
                _clienteUseCase.Atualizar(clienteDomain);

                return RedirectToAction("Index");
            }

            return View(cliente);
        }

        public ActionResult Delete(int id)
        {
            var cliente = _clienteUseCase.ObterPorId(id);
            var clienteViewModel = _mapper.Map<Cliente, ClienteViewModel>(cliente);
            return View(clienteViewModel);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _clienteUseCase.Remover(id);
            return RedirectToAction("Index");
        }
    }
}
