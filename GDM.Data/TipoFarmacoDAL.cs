using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using GDM.Data.Modelos;

namespace GDM.Data
{
    /// <summary>
    /// Administra las operaciones de acceso a datos para la entidad TipoFarmaco.
    /// </summary>
    public class TipoFarmacoDAL
    {
        /// <summary>
        /// Obtiene todos los registros de tipos de fármacos desde la base de datos.
        /// </summary>
        /// <returns>Una lista de TipoFarmaco.</returns>
        public List<TipoFarmaco> ObtenerTodos()
        {
            var lista = new List<TipoFarmaco>();
            string query = "SELECT ID_Tipo_Farmaco, Descripcion, Estado FROM dbo.Tipos_Farmacos ORDER BY ID_Tipo_Farmaco DESC";

            using (SqlConnection conn = ConexionBD.ObtenerConexion())
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new TipoFarmaco
                            {
                                ID_Tipo_Farmaco = reader.GetInt32(0),
                                Descripcion = reader.GetString(1),
                                Estado = reader.GetString(2)
                            });
                        }
                    }
                }
            }
            return lista;
        }

        /// <summary>
        /// Inserta un nuevo tipo de fármaco en la base de datos.
        /// </summary>
        /// <param name="tipo">La entidad TipoFarmaco a insertar.</param>
        public void Insertar(TipoFarmaco tipo)
        {
            string query = "INSERT INTO dbo.Tipos_Farmacos (Descripcion, Estado) VALUES (@Descripcion, @Estado)";

            using (SqlConnection conn = ConexionBD.ObtenerConexion())
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Descripcion", tipo.Descripcion);
                    cmd.Parameters.AddWithValue("@Estado", tipo.Estado);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Actualiza un tipo de fármaco existente.
        /// </summary>
        /// <param name="tipo">La entidad TipoFarmaco con los datos actualizados.</param>
        public void Actualizar(TipoFarmaco tipo)
        {
            string query = "UPDATE dbo.Tipos_Farmacos SET Descripcion = @Descripcion, Estado = @Estado WHERE ID_Tipo_Farmaco = @ID";

            using (SqlConnection conn = ConexionBD.ObtenerConexion())
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Descripcion", tipo.Descripcion);
                    cmd.Parameters.AddWithValue("@Estado", tipo.Estado);
                    cmd.Parameters.AddWithValue("@ID", tipo.ID_Tipo_Farmaco);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Elimina físicamente un tipo de fármaco por su ID.
        /// </summary>
        /// <param name="id">El ID del tipo de fármaco a eliminar.</param>
        public void Eliminar(int id)
        {
            string query = "DELETE FROM dbo.Tipos_Farmacos WHERE ID_Tipo_Farmaco = @ID";

            using (SqlConnection conn = ConexionBD.ObtenerConexion())
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@ID", id);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
