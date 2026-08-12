using System;
using System.Collections.Generic;
using GDM.Data;
using GDM.Data.Modelos;

namespace GDM.Business
{
    /// <summary>
    /// Gestiona la lógica de negocio y las validaciones para el Registro de Visitas.
    /// </summary>
    public class VisitaBLL
    {
        private readonly VisitaDAL _dal = new VisitaDAL();

        /// <summary>
        /// Obtiene todas las visitas registradas.
        /// </summary>
        /// <returns>Lista de Visita.</returns>
        public List<Visita> ObtenerTodos()
        {
            return _dal.ObtenerTodos();
        }

        /// <summary>
        /// Guarda un registro de visita tras aplicar validaciones transaccionales y de estado.
        /// </summary>
        /// <param name="v">La entidad Visita a guardar.</param>
        public void Guardar(Visita v)
        {
            if (v == null) throw new ArgumentNullException(nameof(v));

            // 1. Validar campos requeridos
            if (string.IsNullOrWhiteSpace(v.Sintomas))
                throw new ArgumentException("Debe ingresar la descripción de los síntomas.");

            if (string.IsNullOrWhiteSpace(v.Recomendaciones))
                throw new ArgumentException("Debe ingresar las recomendaciones médicas.");

            if (v.FK_Medico <= 0)
                throw new ArgumentException("Debe seleccionar un médico.");

            if (v.FK_Paciente <= 0)
                throw new ArgumentException("Debe seleccionar un paciente.");

            if (v.FK_Medicamento <= 0)
                throw new ArgumentException("Debe seleccionar un medicamento.");

            // 2. Validar que los maestros relacionados estén activos (Regla transaccional)
            var medico = new MedicoDAL().ObtenerTodos().Find(x => x.ID_Medico == v.FK_Medico);
            if (medico == null)
                throw new InvalidOperationException("El médico seleccionado no existe.");
            if (!medico.Estado.Equals("Activo", StringComparison.OrdinalIgnoreCase))
                throw new InvalidOperationException($"No se puede registrar la visita porque el médico '{medico.Nombre}' está Inactivo.");

            var paciente = new PacienteDAL().ObtenerTodos().Find(x => x.ID_Paciente == v.FK_Paciente);
            if (paciente == null)
                throw new InvalidOperationException("El paciente seleccionado no existe.");
            if (!paciente.Estado.Equals("Activo", StringComparison.OrdinalIgnoreCase))
                throw new InvalidOperationException($"No se puede registrar la visita porque el paciente '{paciente.Nombre}' está Inactivo.");

            var medicamento = new MedicamentoDAL().ObtenerTodos().Find(x => x.ID_Medicamento == v.FK_Medicamento);
            if (medicamento == null)
                throw new InvalidOperationException("El medicamento seleccionado no existe.");
            if (!medicamento.Estado.Equals("Activo", StringComparison.OrdinalIgnoreCase))
                throw new InvalidOperationException($"No se puede registrar la visita porque el medicamento '{medicamento.Descripcion}' está Inactivo.");

            // Normalización
            v.Sintomas = v.Sintomas.Trim();
            v.Recomendaciones = v.Recomendaciones.Trim();

            // 3. Ejecutar inserción o actualización
            if (v.ID_Visita == 0)
            {
                _dal.Insertar(v);
            }
            else
            {
                _dal.Actualizar(v);
            }
        }

        /// <summary>
        /// Elimina un registro de visita física por su identificador.
        /// </summary>
        /// <param name="id">El ID de la visita a eliminar.</param>
        public void Eliminar(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("ID de visita no válido para eliminar.");
            }
            _dal.Eliminar(id);
        }
        /// <summary>
        /// Obtiene visitas filtradas por criterios analíticos dinámicos.
        /// </summary>
        public List<Visita> ObtenerPorCriterios(int? idMedico, int? idPaciente, DateTime? desde, DateTime? hasta)
        {
            return _dal.ObtenerPorCriterios(idMedico, idPaciente, desde, hasta);
        }
    }
}
