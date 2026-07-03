using System;
using System.Collections.Generic;
using GDM.Data;
using GDM.Data.Modelos;

namespace GDM.Business
{
    /// <summary>
    /// Gestiona la lógica de negocio para los pacientes.
    /// </summary>
    public class PacienteBLL
    {
        private readonly PacienteDAL _dal = new PacienteDAL();

        /// <summary>
        /// Obtiene todos los pacientes registrados.
        /// </summary>
        /// <returns>Lista de Paciente.</returns>
        public List<Paciente> ObtenerTodos()
        {
            return _dal.ObtenerTodos();
        }

        /// <summary>
        /// Guarda un paciente tras aplicar validaciones de datos requeridos, cédula dominicana y duplicidades.
        /// </summary>
        /// <param name="p">La entidad Paciente a guardar.</param>
        public void Guardar(Paciente p)
        {
            if (p == null) throw new ArgumentNullException(nameof(p));

            // 1. Validar campos obligatorios no vacíos
            if (string.IsNullOrWhiteSpace(p.Nombre))
                throw new ArgumentException("El nombre completo es obligatorio.");

            if (string.IsNullOrWhiteSpace(p.Cedula))
                throw new ArgumentException("La cédula es obligatoria.");

            if (string.IsNullOrWhiteSpace(p.No_Carnet))
                throw new ArgumentException("El número de carnet es obligatorio.");

            // 2. Validar validez matemática de la Cédula (Luhn Mod 10)
            if (!ValidadorDocumentos.ValidarCedula(p.Cedula))
                throw new ArgumentException("La cédula ingresada no es válida según el formato oficial dominicano.");

            // 3. Validar Tipo de Paciente restringido
            string[] tiposValidos = { "Estudiante", "Empleado", "Profesor", "Otros" };
            bool tipoEsValido = false;
            foreach (var t in tiposValidos)
            {
                if (t.Equals(p.Tipo_Paciente, StringComparison.OrdinalIgnoreCase))
                {
                    tipoEsValido = true;
                    p.Tipo_Paciente = t; // Normalizar casing
                    break;
                }
            }
            if (!tipoEsValido)
                throw new ArgumentException("El tipo de paciente debe ser: Estudiante, Empleado, Profesor u Otros.");

            // 4. Validar Estado
            if (p.Estado != "Activo" && p.Estado != "Inactivo")
                throw new ArgumentException("El estado debe ser 'Activo' o 'Inactivo'.");

            // Normalización
            p.Nombre = p.Nombre.Trim();
            p.Cedula = p.Cedula.Replace("-", "").Replace(" ", "").Trim();
            p.No_Carnet = p.No_Carnet.Trim();

            // 5. Validar Duplicidad de Cédula y Carnet
            var todos = _dal.ObtenerTodos();
            foreach (var item in todos)
            {
                string cedulaLimpiaItem = item.Cedula.Replace("-", "").Replace(" ", "");
                if (cedulaLimpiaItem.Equals(p.Cedula, StringComparison.OrdinalIgnoreCase) && item.ID_Paciente != p.ID_Paciente)
                {
                    throw new InvalidOperationException("Ya existe otro paciente registrado con la misma cédula.");
                }

                if (item.No_Carnet.Equals(p.No_Carnet, StringComparison.OrdinalIgnoreCase) && item.ID_Paciente != p.ID_Paciente)
                {
                    throw new InvalidOperationException("Ya existe otro paciente registrado con el mismo número de carnet.");
                }
            }

            // Guardar
            if (p.ID_Paciente == 0)
            {
                _dal.Insertar(p);
            }
            else
            {
                _dal.Actualizar(p);
            }
        }

        /// <summary>
        /// Elimina un paciente por su ID.
        /// </summary>
        /// <param name="id">El ID del paciente a eliminar.</param>
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
