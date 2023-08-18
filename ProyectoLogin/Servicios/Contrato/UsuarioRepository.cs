using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.Update.Internal;
using ProyectoLogin.Models;

namespace ProyectoLogin.Servicios.Contrato
{
    public class UsuarioRepository
    {
        private readonly AppDbContext _dbContext;

        public UsuarioRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Usuario> GetByIdAsync(int id)
        {
            return await _dbContext.Set<Usuario>().FindAsync(id);
        }
    }
}
