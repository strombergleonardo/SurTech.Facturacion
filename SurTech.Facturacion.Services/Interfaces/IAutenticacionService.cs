using SurTech.Facturacion.Core.Entities;

namespace SurTech.Facturacion.Services.Interfaces
{
    public interface IAutenticacionService
    {
        // Intenta iniciar sesión y devuelve el objeto Usuario si es exitoso o null si falla
        Usuario? IniciarSesion(string nombreUsuario, string clave);

        // Permite registrar nuevos alumnos
        bool RegistrarAlumno(string nombreUsuario, string clave);
    }
}