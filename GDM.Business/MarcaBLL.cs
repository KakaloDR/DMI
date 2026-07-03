using System;
using System.Collections.Generic;
using GDM.Data;
using GDM.Data.Modelos;

namespace GDM.Business
{
    /// <summary>
    /// Gestiona la lógica de negocio para las marcas o laboratorios.
    /// </summary>
    public class MarcaBLL
    {
        private readonly MarcaDAL _dal = new MarcaDAL();

        /// <summary>
        /// Obtiene la lista completa de marcas.
        /// </summary>
        /// <returns>Lista de Marca.</returns>
        public List<Marca> ObtenerTodos()
        {
            return _dal.ObtenerTodos();
        }

        /// <summary>
        /// Guarda una marca (Inserta si ID es 0, de lo contrario actualiza), aplicando validaciones.
        /// </summary>
        /// <param name="marca">La entidad a guardar.</param>
        public void Guardar(Marca marca)
        {
            if (string.IsNullOrWhiteSpace(marca.Descripcion))
            {
                throw new ArgumentException("La descripción es obligatoria.");
            }

            if (marca.Estado != "Activo" && marca.Estado != "Inactivo")
            {
                throw new ArgumentException("El estado debe ser 'Activo' o 'Inactivo'.");
            }

            // Validación de Duplicidad
            var todos = _dal.ObtenerTodos();
            foreach (var item in todos)
            {
                if (item.Descripcion.Equals(marca.Descripcion.Trim(), StringComparison.OrdinalIgnoreCase) 
                    && item.ID_Marca != marca.ID_Marca)
                {
                    throw new InvalidOperationException("Ya existe una marca con esta descripción.");
                }
            }

            marca.Descripcion = marca.Descripcion.Trim();

            if (marca.ID_Marca == 0)
            {
                _dal.Insertar(marca);
            }
            else
            {
                _dal.Actualizar(marca);
            }
        }

        /// <summary>
        /// Elimina una marca de la base de datos.
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
