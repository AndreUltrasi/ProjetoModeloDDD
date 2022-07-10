using AutoMapper;
using ProjetoModeloDDD.Mvc.ViewModels;
using ProjetoModeloDDD.Core.Domain.Entities;
using ProjetoModeloDDD.Core.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace ProjetoModeloDDD.Mvc.Controllers
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

        //protected override void OnException(ExceptionContext filterContext)
        //{
        //    TempData["Erro"] = filterContext.Exception.Message;

        //    //filterContext.Result = new RedirectToRouteResult(
        //    //                           new RouteValueDictionary(new { controller = "Clientes", action = "Index" }));

        //}

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

        public ActionResult Detalhes(int id)
        {
            var cliente = _clienteApp.ObterPorId(id);
            var clienteViewModel = _mapper.Map<Cliente, ClienteViewModel>(cliente);

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
                var clienteDomain = _mapper.Map<ClienteViewModel, Cliente>(cliente);
                _clienteApp.Adicionar(clienteDomain);

                return RedirectToAction("Index");
            }

            return View(cliente);
        }

        public ActionResult Editar(int id)
        {
            var cliente = _clienteApp.ObterPorId(id);
            var clienteViewModel = _mapper.Map<Cliente, ClienteViewModel>(cliente);

            return View(clienteViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(ClienteViewModel cliente)
        {
            if (ModelState.IsValid)
            {
                var clienteDomain = _mapper.Map<ClienteViewModel, Cliente>(cliente);
                _clienteApp.Atualizar(clienteDomain);

                return RedirectToAction("Index");
            }

            return View(cliente);
        }

        public ActionResult Deletar(int id)
        {
            var cliente = _clienteApp.ObterPorId(id);
            var clienteViewModel = _mapper.Map<Cliente, ClienteViewModel>(cliente);
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
