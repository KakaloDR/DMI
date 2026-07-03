using System;
using System.Collections.Generic;
using GDM.Data;
using GDM.Data.Modelos;

namespace GDM.Business
{
    /// <summary>
    /// Gestiona la lógica de negocio para las ubicaciones físicas del dispensario.
    /// </summary>
    public class UbicacionBLL
    {
        private readonly UbicacionDAL _dal = new UbicacionDAL();

        /// <summary>
        /// Obtiene la lista completa de ubicaciones.
        /// </summary>
        /// <returns>Lista de Ubicacion.</returns>
        public List<Ubicacion> ObtenerTodos()
        {
            return _dal.ObtenerTodos();
        }

        /// <summary>
        /// Guarda una ubicación aplicando validaciones de campos obligatorios y de duplicidad tridimensional.
        /// </summary>
        /// <param name="ubicacion">La ubicación a guardar.</param>
        public void Guardar(Ubicacion ubicacion)
        {
            if (string.IsNullOrWhiteSpace(ubicacion.Descripcion))
            {
                throw new ArgumentException("La descripción es obligatoria.");
            }

            if (string.IsNullOrWhiteSpace(ubicacion.Estante))
            {
                throw new ArgumentException("El estante es obligatorio.");
            }

            if (string.IsNullOrWhiteSpace(ubicacion.Tramo))
            {
                throw new ArgumentException("El tramo es obligatorio.");
            }

            if (string.IsNullOrWhiteSpace(ubicacion.Celda))
            {
                throw new ArgumentException("La celda es obligatoria.");
            }

            if (ubicacion.Estado != "Activo" && ubicacion.Estado != "Inactivo")
            {
                throw new ArgumentException("El estado debe ser 'Activo' o 'Inactivo'.");
            }

            // Validación de Duplicidad tridimensional (Estante, Tramo, Celda)
            var todos = _dal.ObtenerTodos();
            foreach (var item in todos)
            {
                if (item.Estante.Equals(ubicacion.Estante.Trim(), StringComparison.OrdinalIgnoreCase)
                    && item.Tramo.Equals(ubicacion.Tramo.Trim(), StringComparison.OrdinalIgnoreCase)
                    && item.Celda.Equals(ubicacion.Celda.Trim(), StringComparison.OrdinalIgnoreCase)
                    && item.ID_Ubicacion != ubicacion.ID_Ubicacion)
                {
                    throw new InvalidOperationException("Ya existe una ubicación registrada en ese Estante, Tramo y Celda exactos.");
                }
            }

            ubicacion.Descripcion = ubicacion.Descripcion.Trim();
            ubicacion.Estante = ubicacion.Estante.Trim();
            ubicacion.Tramo = ubicacion.Tramo.Trim();
            ubicacion.Celda = ubicacion.Celda.Trim();

            if (ubicacion.ID_Ubicacion == 0)
            {
                _dal.Insertar(ubicacion);
            }
            else
            {
                _dal.Actualizar(ubicacion);
            }
        }

        /// <summary>
        /// Elimina una ubicación de la base de datos.
        /// </summary>
        /// <param name="id">El ID a eliminar.</param>
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
