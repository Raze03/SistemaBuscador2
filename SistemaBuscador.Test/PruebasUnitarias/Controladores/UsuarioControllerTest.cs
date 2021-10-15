using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SistemaBuscador.Controllers;
using SistemaBuscador.Models;
using SistemaBuscador.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SistemaBuscador.Test.PruebasUnitarias.Controladores
{
    [TestClass]
    public class UsuarioControllerTest
    {
        [TestMethod]
        public async Task NuevoUsuarioExiste()
        {
            //Preparacion
            var usuario = new Mock<IUsuarioRepository>();
            var model = new UsuarioCreacionModel();
            var controller = new UsuariosController(usuario.Object);

            //Ejecucio
            var resultado = await controller.NuevoUsuarioExiste(model) as RedirectToActionResult;

            //Validacion
            Assert.AreEqual(resultado.ActionName, "Index");
        }
    }
}
