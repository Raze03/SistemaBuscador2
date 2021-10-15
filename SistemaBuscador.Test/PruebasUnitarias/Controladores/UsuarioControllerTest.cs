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
        public async Task NuevoUsuario_modelo_valido()
        {
            //Preparacion
            var listausuarios = new Mock<IUsuarioRepository>();
            var model = new UsuarioCreacionModel();
            var controller = new UsuariosController(listausuarios.Object);

            //Ejecucio
            var resultado = await controller.NuevoUsuario(model) as RedirectToActionResult;

            //Validacion
            Assert.AreEqual(resultado.ActionName, "Index");

        }    
    }
}
