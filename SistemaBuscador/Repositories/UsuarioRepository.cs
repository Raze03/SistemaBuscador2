using SistemaBuscador.Entities;
using SistemaBuscador.Models;
using SistemaBuscador.Utilidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaBuscador.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly ISeguridad _seguridad;

        public UsuarioRepository(ApplicationDbContext context, ISeguridad seguridad)
        {
            _context = context;
            _seguridad = seguridad;
        }
        public async Task InsertatUsuario(UsuarioCreacionModel model)
        {
            var nuevoUsuario = new Usuario() 
            {
                NombreUsuario = model.NombreUsuario,
                Nombres = model.Nombres,
                Apellidos = model.Apellidos,
                RolId = (int)model.RolId,
                Password = _seguridad.Encriptar(model.Password)
            };

            _context.Usuarios.Add(nuevoUsuario);
            await _context.SaveChangesAsync();
        }
    }
}
