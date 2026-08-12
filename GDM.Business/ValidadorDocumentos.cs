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
        /// Valida que una cadena tenga el formato estructural de una Cédula dominicana
        /// (11 dígitos numéricos, con o sin guiones). No aplica el algoritmo de Luhn
        /// porque muchos documentos emitidos por la JCE —incluidos extranjeros y
        /// nuevas generaciones— no satisfacen ese cálculo, lo que bloqueaba
        /// registros legítimos en producción.
        /// </summary>
        /// <param name="cedula">Cédula a verificar (se permiten guiones y espacios).</param>
        /// <returns>true si la cadena cumple el formato; de lo contrario, false.</returns>
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

            return true;
        }
    }
}
