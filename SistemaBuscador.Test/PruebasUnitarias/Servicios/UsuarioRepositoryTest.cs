using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SistemaBuscador.Models;
using SistemaBuscador.Repositories;
using SistemaBuscador.Utilidades;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SistemaBuscador.Test.PruebasUnitarias.Servicios
{
    [TestClass]
    public class UsuarioRepositoryTest : TestBase
    {
        [TestMethod]
        public async Task InsertarUsuario()
        {
            //Preparacion
            var nombreBd = Guid.NewGuid().ToString();
            var context = BuildContext(nombreBd);
            var seguridad = new Mock<ISeguridad>();
            seguridad.Setup(x => x.Encriptar(It.IsAny<string>())).Returns("aadbbccsss333ee55asdasda31as2d31a32sd1a32s1das3");
            var rolRepo = new RolRepositorio(context);
            var repo = new UsuarioRepository(context, seguridad.Object, rolRepo);
            var modelo = new UsuarioCreacionModel() { 
                Apellidos = "Test",
                Nombres = "Test",
                NombreUsuario = "Test",
                Password = "Test",
                RePassword = "Test",
                RolId = 1 };
            //Ejecucion
            await repo.InsertatUsuario(modelo);
            var context2 = BuildContext(nombreBd);
            var list = await context2.Usuarios.ToListAsync();
            var resultado = list.Count;
            Assert.AreEqual(1, resultado);
        }
    }
}
