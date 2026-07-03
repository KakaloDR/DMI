using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using GDM.Data.Modelos;

namespace GDM.Data
{
    /// <summary>
    /// Administra las operaciones de acceso a datos para la entidad Ubicacion.
    /// </summary>
    public class UbicacionDAL
    {
        /// <summary>
        /// Obtiene todos los registros de ubicaciones desde la base de datos.
        /// </summary>
        /// <returns>Una lista de Ubicacion.</returns>
        public List<Ubicacion> ObtenerTodos()
        {
            var lista = new List<Ubicacion>();
            string query = "SELECT ID_Ubicacion, Descripcion, Estante, Tramo, Celda, Estado FROM dbo.Ubicaciones ORDER BY ID_Ubicacion DESC";

            using (SqlConnection conn = ConexionBD.ObtenerConexion())
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new Ubicacion
                            {
                                ID_Ubicacion = reader.GetInt32(0),
                                Descripcion = reader.GetString(1),
                                Estante = reader.GetString(2),
                                Tramo = reader.GetString(3),
                                Celda = reader.GetString(4),
                                Estado = reader.GetString(5)
                            });
                        }
                    }
                }
            }
            return lista;
        }

        /// <summary>
        /// Inserta una nueva ubicación en la base de datos.
        /// </summary>
        /// <param name="ubicacion">La entidad Ubicacion a insertar.</param>
        public void Insertar(Ubicacion ubicacion)
        {
            string query = "INSERT INTO dbo.Ubicaciones (Descripcion, Estante, Tramo, Celda, Estado) VALUES (@Descripcion, @Estante, @Tramo, @Celda, @Estado)";

            using (SqlConnection conn = ConexionBD.ObtenerConexion())
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Descripcion", ubicacion.Descripcion);
                    cmd.Parameters.AddWithValue("@Estante", ubicacion.Estante);
                    cmd.Parameters.AddWithValue("@Tramo", ubicacion.Tramo);
                    cmd.Parameters.AddWithValue("@Celda", ubicacion.Celda);
                    cmd.Parameters.AddWithValue("@Estado", ubicacion.Estado);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Actualiza una ubicación existente.
        /// </summary>
        /// <param name="ubicacion">La entidad Ubicacion con los datos actualizados.</param>
        public void Actualizar(Ubicacion ubicacion)
        {
            string query = "UPDATE dbo.Ubicaciones SET Descripcion = @Descripcion, Estante = @Estante, Tramo = @Tramo, Celda = @Celda, Estado = @Estado WHERE ID_Ubicacion = @ID";

            using (SqlConnection conn = ConexionBD.ObtenerConexion())
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Descripcion", ubicacion.Descripcion);
                    cmd.Parameters.AddWithValue("@Estante", ubicacion.Estante);
                    cmd.Parameters.AddWithValue("@Tramo", ubicacion.Tramo);
                    cmd.Parameters.AddWithValue("@Celda", ubicacion.Celda);
                    cmd.Parameters.AddWithValue("@Estado", ubicacion.Estado);
                    cmd.Parameters.AddWithValue("@ID", ubicacion.ID_Ubicacion);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Elimina físicamente una ubicación por su ID.
        /// </summary>
        /// <param name="id">El ID de la ubicación a eliminar.</param>
        public void Eliminar(int id)
        {
            string query = "DELETE FROM dbo.Ubicaciones WHERE ID_Ubicacion = @ID";

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
