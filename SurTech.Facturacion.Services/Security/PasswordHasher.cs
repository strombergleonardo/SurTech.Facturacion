using System.Security.Cryptography;
using System.Text;

namespace SurTech.Facturacion.Services.Security
{
    public static class PasswordHasher
    {
        // Convierte una clave en texto plano a un Hash SHA-256
        public static string HashPassword(string password)
        {
            if (string.IsNullOrWhiteSpace(password))
                return string.Empty;

            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }

        // Verifica si la clave en texto plano coincide con el Hash guardado
        public static bool VerifyPassword(string password, string storedHash)
        {
            string hashOfInput = HashPassword(password);
            return string.Equals(hashOfInput, storedHash, System.StringComparison.OrdinalIgnoreCase);
        }
    }
}
