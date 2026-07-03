using System;
using System.Text.RegularExpressions;

namespace GDM.Business
{
    /// <summary>
    /// Proporciona utilidades para la validación de documentos oficiales dominicanos.
    /// </summary>
    public static class ValidadorDocumentos
    {
        /// <summary>
        /// Valida una Cédula de Identidad y Electoral dominicana (con o sin guiones) mediante el algoritmo de Luhn (Mod 10).
        /// </summary>
        /// <param name="cedula">Cédula a verificar.</param>
        /// <returns>true si es matemáticamente válida; de lo contrario, false.</returns>
        public static bool ValidarCedula(string cedula)
        {
            if (string.IsNullOrEmpty(cedula)) return false;

            // Eliminar guiones y espacios
            string limpia = cedula.Replace("-", "").Replace(" ", "");

            // Debe tener exactamente 11 caracteres y ser numérico
            if (limpia.Length != 11 || !Regex.IsMatch(limpia, @"^[0-9]+$"))
            {
                return false;
            }

            // Exclusión de cédula nula / inválida común
            if (limpia == "00000000000")
            {
                return false;
            }

            int[] pesos = { 1, 2, 1, 2, 1, 2, 1, 2, 1, 2 };
            int suma = 0;

            for (int i = 0; i < 10; i++)
            {
                int digito = limpia[i] - '0';
                int producto = digito * pesos[i];

                // Si el producto es de 2 dígitos, sumamos sus dígitos individuales
                if (producto >= 10)
                {
                    producto = (producto / 10) + (producto % 10);
                }

                suma += producto;
            }

            int resto = suma % 10;
            int digitoVerificadorCalculado = (10 - resto) % 10;
            int digitoVerificadorReal = limpia[10] - '0';

            return digitoVerificadorCalculado == digitoVerificadorReal;
        }
    }
}
