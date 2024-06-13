using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;
using System.Text;
using Newtonsoft.Json;

namespace AdmTarea.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PagoRSA : ControllerBase
    {
        private const string claveCifrado = "1aB3!2cDf@9ZxY&4"; // Reemplaza con tu clave de cifrado
        [HttpPost]
        public IActionResult ProcesarPago([FromBody] DatosCifradosRequest request)
        {
            try
            {
                Console.WriteLine($"Datos cifrados recibidos: {request.DatosCifrados}");

                var iv = request.IV; // Asegúrate de que el nombre del campo sea correcto

                // Descifrar datos utilizando AES
                var datosDescifrados = DecryptString(request.DatosCifrados, claveCifrado, iv);

                Console.WriteLine($"Datos descifrados: {datosDescifrados}");

                // Aquí puedes procesar los datos descifrados
                var datos = JsonConvert.DeserializeObject<DatosRequest>(datosDescifrados);

                // Ejemplo de procesamiento
                Console.WriteLine("Datos recibidos:");
                Console.WriteLine($"Nombre del tarjetahabiente: {datos.NombreTarjetahabiente}");
                Console.WriteLine($"PAN: {datos.PAN}");
                Console.WriteLine($"Fecha de vencimiento: {datos.FechaVencimiento}");
                Console.WriteLine($"Código de seguridad: {datos.CodigoSeguridad}");

                // Aquí procesar lógica de negocio, almacenamiento en base de datos, etc.

                return Ok(new { Mensaje = "Datos recibidos y procesados correctamente" });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al procesar los datos cifrados: {ex.Message}");
                return StatusCode(500, new { Error = "Error al procesar los datos cifrados" });
            }
        }

        private static string DecryptString(string encryptedText, string key, string iv)
        {
            using (var aes = Aes.Create())
            {
                aes.Key = Encoding.UTF8.GetBytes(key);
                aes.IV = Convert.FromBase64String(iv);
                aes.Mode = CipherMode.CBC;
                aes.Padding = PaddingMode.PKCS7;

                var encryptedBytes = Convert.FromBase64String(encryptedText);

                using (var decryptor = aes.CreateDecryptor(aes.Key, aes.IV))
                {
                    using (var ms = new MemoryStream(encryptedBytes))
                    {
                        using (var cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read))
                        {
                            using (var reader = new StreamReader(cs))
                            {
                                return reader.ReadToEnd();
                            }
                        }
                    }
                }
            }
        }

        public class DatosCifradosRequest
        {
            public string DatosCifrados { get; set; }
            public string IV { get; set; } // Propiedad para el IV
        }

        public class DatosRequest
        {
            public string NombreTarjetahabiente { get; set; }
            public string PAN { get; set; }
            public string FechaVencimiento { get; set; }
            public string CodigoSeguridad { get; set; }
        }
    }
}