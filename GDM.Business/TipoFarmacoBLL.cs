using System;
using System.Collections.Generic;
using GDM.Data;
using GDM.Data.Modelos;

namespace GDM.Business
{
    /// <summary>
    /// Gestiona la lógica de negocio para los tipos de fármacos.
    /// </summary>
    public class TipoFarmacoBLL
    {
        private readonly TipoFarmacoDAL _dal = new TipoFarmacoDAL();

        /// <summary>
        /// Obtiene la lista completa de tipos de fármacos.
        /// </summary>
        /// <returns>Lista de TipoFarmaco.</returns>
        public List<TipoFarmaco> ObtenerTodos()
        {
            return _dal.ObtenerTodos();
        }

        /// <summary>
        /// Guarda un tipo de fármaco (Inserta si ID es 0, de lo contrario actualiza), aplicando validaciones.
        /// </summary>
        /// <param name="tipo">La entidad a guardar.</param>
        public void Guardar(TipoFarmaco tipo)
        {
            if (string.IsNullOrWhiteSpace(tipo.Descripcion))
            {
                throw new ArgumentException("La descripción es obligatoria.");
            }

            if (tipo.Estado != "Activo" && tipo.Estado != "Inactivo")
            {
                throw new ArgumentException("El estado debe ser 'Activo' o 'Inactivo'.");
            }

            // Validación de Duplicidad
            var todos = _dal.ObtenerTodos();
            foreach (var item in todos)
            {
                if (item.Descripcion.Equals(tipo.Descripcion.Trim(), StringComparison.OrdinalIgnoreCase) 
                    && item.ID_Tipo_Farmaco != tipo.ID_Tipo_Farmaco)
                {
                    throw new InvalidOperationException("Ya existe un tipo de fármaco con esta descripción.");
                }
            }

            tipo.Descripcion = tipo.Descripcion.Trim();

            if (tipo.ID_Tipo_Farmaco == 0)
            {
                _dal.Insertar(tipo);
            }
            else
            {
                _dal.Actualizar(tipo);
            }
        }

        /// <summary>
        /// Elimina un tipo de fármaco de la base de datos.
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
