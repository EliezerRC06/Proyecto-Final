using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using ProyectoLogin.Models;
using ProyectoLogin.Servicios.Contrato;

namespace ProyectoLogin.Servicios.Implementacion
{
    public class UsuarioService : IUsuarioService
    {
        private readonly AppDbContext _dbContext;

        private readonly UsuarioRepository _usuarioRepository;

        public UsuarioService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
            _usuarioRepository = new(dbContext);

        }
        public async Task<Usuario> GetById(int id)
        {
            Usuario usuario = await _dbContext.Set<Usuario>().FindAsync(id);
            return usuario;
        }


        public async Task<Usuario> GetUsuario(string correo, string clave)
        {
            Usuario usuario_encontrado = await _dbContext.Usuarios.Where(u => u.Correo == correo && u.Clave == clave)
                 .FirstOrDefaultAsync();

            return usuario_encontrado;
        }

        public async Task<Usuario> SaveUsuario(Usuario modelo)
        {
            _dbContext.Usuarios.Add(modelo);
            await _dbContext.SaveChangesAsync();
            return modelo;
        }

        public async Task<UsuarioViewModel> GetByIdSaveViewModel(int id)
        {
            Usuario usuario = await _usuarioRepository.GetByIdAsync(id);

            if (usuario != null)
            {
                UsuarioViewModel vm = new()
                {
                    NombreUsuario = usuario.NombreUsuario,
                    Telefono = usuario.Telefono,
                    Foto = usuario.Foto
                };

                return vm;
            }
            else
            {
                return null;
            }
        }
    }
}
