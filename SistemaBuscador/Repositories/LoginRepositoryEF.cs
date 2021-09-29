using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaBuscador.Repositories
{
    public class LoginRepositoryEF : ILoginRepository
    {
        private readonly ApplicationDbContext context;

        public LoginRepositoryEF(ApplicationDbContext _context)
        {
            _context = context;
        }
        public void SetSessionAndCookie(HttpContext context)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UserExist(string usuario, string password)
        {
            var resultado = false;

            //logica que ocupa EF

            var usuarioBD = context.Usuarios
                .FirstOrDefault(x => x.NombreUsuario == usuario && x.Password == password);

            if(usuarioBD!=null)
            {
                resultado = true;
            }

            return resultado;
        }
    }
}
