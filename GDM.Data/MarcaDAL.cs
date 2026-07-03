using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using GDM.Data.Modelos;

namespace GDM.Data
{
    /// <summary>
    /// Administra las operaciones de acceso a datos para la entidad Marca.
    /// </summary>
    public class MarcaDAL
    {
        /// <summary>
        /// Obtiene todos los registros de marcas desde la base de datos.
        /// </summary>
        /// <returns>Una lista de Marca.</returns>
        public List<Marca> ObtenerTodos()
        {
            var lista = new List<Marca>();
            string query = "SELECT ID_Marca, Descripcion, Estado FROM dbo.Marcas ORDER BY ID_Marca DESC";

            using (SqlConnection conn = ConexionBD.ObtenerConexion())
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new Marca
                            {
                                ID_Marca = reader.GetInt32(0),
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
        /// Inserta una nueva marca en la base de datos.
        /// </summary>
        /// <param name="marca">La entidad Marca a insertar.</param>
        public void Insertar(Marca marca)
        {
            string query = "INSERT INTO dbo.Marcas (Descripcion, Estado) VALUES (@Descripcion, @Estado)";

            using (SqlConnection conn = ConexionBD.ObtenerConexion())
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Descripcion", marca.Descripcion);
                    cmd.Parameters.AddWithValue("@Estado", marca.Estado);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Actualiza una marca existente.
        /// </summary>
        /// <param name="marca">La entidad Marca con los datos actualizados.</param>
        public void Actualizar(Marca marca)
        {
            string query = "UPDATE dbo.Marcas SET Descripcion = @Descripcion, Estado = @Estado WHERE ID_Marca = @ID";

            using (SqlConnection conn = ConexionBD.ObtenerConexion())
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Descripcion", marca.Descripcion);
                    cmd.Parameters.AddWithValue("@Estado", marca.Estado);
                    cmd.Parameters.AddWithValue("@ID", marca.ID_Marca);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Elimina físicamente una marca por su ID.
        /// </summary>
        /// <param name="id">El ID de la marca a eliminar.</param>
        public void Eliminar(int id)
        {
            string query = "DELETE FROM dbo.Marcas WHERE ID_Marca = @ID";

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
