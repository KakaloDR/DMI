using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using GDM.Data.Modelos;

namespace GDM.Data
{
    /// <summary>
    /// Administra las operaciones de acceso a datos para la entidad Medico.
    /// </summary>
    public class MedicoDAL
    {
        /// <summary>
        /// Obtiene todos los registros de médicos desde la base de datos.
        /// </summary>
        /// <returns>Una lista de Medico.</returns>
        public List<Medico> ObtenerTodos()
        {
            var lista = new List<Medico>();
            string query = "SELECT ID_Medico, Nombre, Cedula, Tanda_Labor, Especialidad, Estado FROM dbo.Medicos ORDER BY ID_Medico DESC";

            using (SqlConnection conn = ConexionBD.ObtenerConexion())
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new Medico
                            {
                                ID_Medico = reader.GetInt32(0),
                                Nombre = reader.GetString(1),
                                Cedula = reader.GetString(2),
                                Tanda_Labor = reader.GetString(3),
                                Especialidad = reader.GetString(4),
                                Estado = reader.GetString(5)
                            });
                        }
                    }
                }
            }
            return lista;
        }

        /// <summary>
        /// Inserta un nuevo médico en la base de datos.
        /// </summary>
        /// <param name="m">La entidad Medico a insertar.</param>
        public void Insertar(Medico m)
        {
            string query = "INSERT INTO dbo.Medicos (Nombre, Cedula, Tanda_Labor, Especialidad, Estado) VALUES (@Nombre, @Cedula, @Tanda_Labor, @Especialidad, @Estado)";

            using (SqlConnection conn = ConexionBD.ObtenerConexion())
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Nombre", m.Nombre);
                    cmd.Parameters.AddWithValue("@Cedula", m.Cedula);
                    cmd.Parameters.AddWithValue("@Tanda_Labor", m.Tanda_Labor);
                    cmd.Parameters.AddWithValue("@Especialidad", m.Especialidad);
                    cmd.Parameters.AddWithValue("@Estado", m.Estado);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Actualiza un médico existente en la base de datos.
        /// </summary>
        /// <param name="m">La entidad Medico con los datos actualizados.</param>
        public void Actualizar(Medico m)
        {
            string query = "UPDATE dbo.Medicos SET Nombre = @Nombre, Cedula = @Cedula, Tanda_Labor = @Tanda_Labor, Especialidad = @Especialidad, Estado = @Estado WHERE ID_Medico = @ID";

            using (SqlConnection conn = ConexionBD.ObtenerConexion())
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Nombre", m.Nombre);
                    cmd.Parameters.AddWithValue("@Cedula", m.Cedula);
                    cmd.Parameters.AddWithValue("@Tanda_Labor", m.Tanda_Labor);
                    cmd.Parameters.AddWithValue("@Especialidad", m.Especialidad);
                    cmd.Parameters.AddWithValue("@Estado", m.Estado);
                    cmd.Parameters.AddWithValue("@ID", m.ID_Medico);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Elimina físicamente un médico por su ID.
        /// </summary>
        /// <param name="id">El ID del médico a eliminar.</param>
        public void Eliminar(int id)
        {
            string query = "DELETE FROM dbo.Medicos WHERE ID_Medico = @ID";

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
