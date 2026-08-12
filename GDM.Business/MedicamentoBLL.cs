using System;
using System.Collections.Generic;
using System.Linq;
using GDM.Data;
using GDM.Data.Modelos;

namespace GDM.Business
{
    /// <summary>
    /// Gestiona la lógica de negocio para los medicamentos.
    /// </summary>
    public class MedicamentoBLL
    {
        private readonly MedicamentoDAL _dal = new MedicamentoDAL();

        /// <summary>
        /// Obtiene todos los medicamentos del inventario.
        /// </summary>
        /// <returns>Lista de Medicamento.</returns>
        public List<Medicamento> ObtenerTodos()
        {
            return _dal.ObtenerTodos();
        }

        /// <summary>
        /// Guarda un medicamento tras aplicar validaciones de negocio, integridad referencial y duplicidad.
        /// </summary>
        /// <param name="m">La entidad Medicamento a guardar.</param>
        public void Guardar(Medicamento m)
        {
            if (m == null) throw new ArgumentNullException(nameof(m));

            // 1. Validaciones de campos obligatorios
            if (string.IsNullOrWhiteSpace(m.Descripcion))
                throw new ArgumentException("La descripción del medicamento es obligatoria.");

            if (string.IsNullOrWhiteSpace(m.Dosis))
                throw new ArgumentException("La dosis estándar es obligatoria.");

            if (m.FK_Tipo_Farmaco <= 0)
                throw new ArgumentException("Debe seleccionar un tipo de fármaco válido.");

            if (m.FK_Marca <= 0)
                throw new ArgumentException("Debe seleccionar una marca válida.");

            if (m.FK_Ubicacion <= 0)
                throw new ArgumentException("Debe seleccionar una ubicación válida.");

            if (m.Estado != "Activo" && m.Estado != "Inactivo")
                throw new ArgumentException("El estado debe ser 'Activo' o 'Inactivo'.");

            // 2. Validación de Integridad Referencial: Relaciones activas
            var tipoBLL = new TipoFarmacoBLL();
            var tipos = tipoBLL.ObtenerTodos();
            var tipo = tipos.FirstOrDefault(t => t.ID_Tipo_Farmaco == m.FK_Tipo_Farmaco);
            if (tipo == null)
                throw new InvalidOperationException("El tipo de fármaco asociado no existe en la base de datos.");
            if (tipo.Estado != "Activo" && m.Estado == "Activo")
                throw new InvalidOperationException("No se puede registrar un medicamento activo asociado a un Tipo de Fármaco Inactivo.");

            var marcaBLL = new MarcaBLL();
            var marcas = marcaBLL.ObtenerTodos();
            var marca = marcas.FirstOrDefault(b => b.ID_Marca == m.FK_Marca);
            if (marca == null)
                throw new InvalidOperationException("La marca asociada no existe en la base de datos.");
            if (marca.Estado != "Activo" && m.Estado == "Activo")
                throw new InvalidOperationException("No se puede registrar un medicamento activo asociado a una Marca Inactiva.");

            var ubiBLL = new UbicacionBLL();
            var ubis = ubiBLL.ObtenerTodos();
            var ubi = ubis.FirstOrDefault(u => u.ID_Ubicacion == m.FK_Ubicacion);
            if (ubi == null)
                throw new InvalidOperationException("La ubicación asociada no existe en la base de datos.");
            if (ubi.Estado != "Activo" && m.Estado == "Activo")
                throw new InvalidOperationException("No se puede registrar un medicamento activo asociado a una Ubicación Inactiva.");

            // Normalización
            m.Descripcion = m.Descripcion.Trim();
            m.Dosis = m.Dosis.Trim();

            // 3. Validación de Duplicados
            var todos = _dal.ObtenerTodos();
            foreach (var item in todos)
            {
                if (item.Descripcion.Equals(m.Descripcion, StringComparison.OrdinalIgnoreCase) 
                    && item.FK_Tipo_Farmaco == m.FK_Tipo_Farmaco 
                    && item.FK_Marca == m.FK_Marca 
                    && item.ID_Medicamento != m.ID_Medicamento)
                {
                    throw new InvalidOperationException("Ya existe otro medicamento registrado con el mismo nombre comercial, tipo y marca.");
                }
            }

            // Guardar
            if (m.ID_Medicamento == 0)
            {
                _dal.Insertar(m);
            }
            else
            {
                _dal.Actualizar(m);
            }
        }

        /// <summary>
        /// Elimina un medicamento por su ID.
        /// </summary>
        /// <param name="id">El ID del medicamento a eliminar.</param>
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
