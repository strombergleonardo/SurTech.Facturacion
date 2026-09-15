using System;
using SurTech.Facturacion.Core.Entities;
using SurTech.Facturacion.Core.Interfaces;
using SurTech.Facturacion.Services.Interfaces;
using SurTech.Facturacion.Services.Security;

namespace SurTech.Facturacion.Services.BusinessLogic
{
    public class AutenticacionService : IAutenticacionService
    {
        private readonly IUsuarioRepository _usuarioRepository;

        // Inyección de dependencias a través del constructor
        public AutenticacionService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository ?? throw new ArgumentNullException(nameof(usuarioRepository));
        }

        public Usuario? IniciarSesion(string nombreUsuario, string clave)
        {
            if (string.IsNullOrWhiteSpace(nombreUsuario) || string.IsNullOrWhiteSpace(clave))
                return null;

            // 1. Buscar el usuario en la base de datos por su nombre
            var usuario = _usuarioRepository.ObtenerPorNombreUsuario(nombreUsuario);

            if (usuario == null)
                return null; // El usuario no existe

            // Nota Pedagógica: Para retrocompatibilidad con el sembrado inicial o claves no hasheadas
            bool esValida = PasswordHasher.VerifyPassword(clave, usuario.ClaveHash) || usuario.ClaveHash == clave;

            if (!esValida)
                return null; // Contraseña incorrecta

            return usuario;
        }

        public bool RegistrarAlumno(string nombreUsuario, string clave)
        {
            if (string.IsNullOrWhiteSpace(nombreUsuario) || string.IsNullOrWhiteSpace(clave))
                return false;

            // Verificar que no exista un usuario con el mismo nombre
            var existente = _usuarioRepository.ObtenerPorNombreUsuario(nombreUsuario);
            if (existente != null)
                return false;

            // Crear el nuevo usuario (Por defecto su Rol será "Alumno" como definimos en el Core)
            var nuevoUsuario = new Usuario
            {
                NombreUsuario = nombreUsuario.Trim(),
                ClaveHash = PasswordHasher.HashPassword(clave),
                Rol = "Alumno"
            };

            _usuarioRepository.Agregar(nuevoUsuario);
            _usuarioRepository.Guardar();
            return true;
        }
    }
}