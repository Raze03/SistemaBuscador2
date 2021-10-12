using Microsoft.EntityFrameworkCore;
using SistemaBuscador.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaBuscador.Repositories
{
    public class RolRepositorio : IRolRepositorio
    {
        private readonly ApplicationDbContext _context;

        public RolRepositorio(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<RolListaModelo>> ObtenerListaRoles()
        {
            var respuesta = new List<RolListaModelo>();
            var listaDelaBd = await _context.Roles.ToListAsync();

            foreach (var rolDb in listaDelaBd)
            {
                //Mapeo de entidades
                var newRolLista = new RolListaModelo()
                {
                    Id = rolDb.Id,
                    Nombre = rolDb.Nombre,                  
                };

                respuesta.Add(newRolLista);
            }


            return respuesta;
        }

    }
}
