using Microsoft.AspNetCore.Mvc;
using SistemaBuscador.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaBuscador.Controllers
{
    public class RolesController : Controller
    {
        private readonly IRolRepositorio _repositorio;

        public RolesController(IRolRepositorio repositorio)
        {
            _repositorio = repositorio;
        }
        public async Task<IActionResult> Index()
        {
            var listaRoles = await _repositorio.ObtenerListaRoles();
            return View(listaRoles);
        }

        public IActionResult NuevoRol()
        {
            return View();
        } 
    }
}
