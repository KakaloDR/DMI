using System;
using System.Collections.Generic;
using GDM.Data;
using GDM.Data.Modelos;

namespace GDM.Business
{
    /// <summary>
    /// Gestiona la lógica de negocio para los médicos.
    /// </summary>
    public class MedicoBLL
    {
        private readonly MedicoDAL _dal = new MedicoDAL();

        /// <summary>
        /// Obtiene todos los médicos registrados.
        /// </summary>
        /// <returns>Lista de Medico.</returns>
        public List<Medico> ObtenerTodos()
        {
            return _dal.ObtenerTodos();
        }

        /// <summary>
        /// Guarda un médico tras aplicar validaciones de datos requeridos, cédula dominicana y tanda horaria.
        /// </summary>
        /// <param name="m">La entidad Medico a guardar.</param>
        public void Guardar(Medico m)
        {
            if (m == null) throw new ArgumentNullException(nameof(m));

            // 1. Validar campos obligatorios
            if (string.IsNullOrWhiteSpace(m.Nombre))
                throw new ArgumentException("El nombre completo del médico es obligatorio.");

            if (string.IsNullOrWhiteSpace(m.Cedula))
                throw new ArgumentException("La cédula es obligatoria.");

            if (string.IsNullOrWhiteSpace(m.Especialidad))
                throw new ArgumentException("La especialidad médica es obligatoria.");

            // 2. Validar validez matemática de la Cédula (Luhn Mod 10)
            if (!ValidadorDocumentos.ValidarCedula(m.Cedula))
                throw new ArgumentException("La cédula ingresada no es válida según el formato oficial dominicano.");

            // 3. Validar Tanda Laboral
            string[] tandasValidas = { "Matutina", "Vespertina", "Nocturna" };
            bool tandaEsValida = false;
            foreach (var t in tandasValidas)
            {
                if (t.Equals(m.Tanda_Labor, StringComparison.OrdinalIgnoreCase))
                {
                    tandaEsValida = true;
                    m.Tanda_Labor = t; // Normalizar
                    break;
                }
            }
            if (!tandaEsValida)
                throw new ArgumentException("La tanda de labor debe ser: Matutina, Vespertina o Nocturna.");

            // 4. Validar Estado
            if (m.Estado != "Activo" && m.Estado != "Inactivo")
                throw new ArgumentException("El estado debe ser 'Activo' o 'Inactivo'.");

            // Normalización
            m.Nombre = m.Nombre.Trim();
            m.Cedula = m.Cedula.Replace("-", "").Replace(" ", "").Trim();
            m.Especialidad = m.Especialidad.Trim();

            // 5. Validar Duplicidad de Cédula
            var todos = _dal.ObtenerTodos();
            foreach (var item in todos)
            {
                string cedulaLimpiaItem = item.Cedula.Replace("-", "").Replace(" ", "");
                if (cedulaLimpiaItem.Equals(m.Cedula, StringComparison.OrdinalIgnoreCase) && item.ID_Medico != m.ID_Medico)
                {
                    throw new InvalidOperationException("Ya existe otro médico registrado con la misma cédula.");
                }
            }

            // Guardar
            if (m.ID_Medico == 0)
            {
                _dal.Insertar(m);
            }
            else
            {
                _dal.Actualizar(m);
            }
        }

        /// <summary>
        /// Elimina un médico por su ID.
        /// </summary>
        /// <param name="id">El ID del médico a eliminar.</param>
        public void Eliminar(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("ID no válido para eliminar.");
            }
            _dal.Eliminar(id);
        }
    }
}
