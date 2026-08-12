using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using GDM.Data.Modelos;

namespace GDM.Data
{
    /// <summary>
    /// Administra las operaciones de acceso a datos para la entidad Paciente.
    /// </summary>
    public class PacienteDAL
    {
        /// <summary>
        /// Obtiene todos los registros de pacientes desde la base de datos.
        /// </summary>
        /// <returns>Una lista de Paciente.</returns>
        public List<Paciente> ObtenerTodos()
        {
            var lista = new List<Paciente>();
            string query = "SELECT ID_Paciente, Nombre, Cedula, No_Carnet, Tipo_Paciente, Estado FROM dbo.Pacientes ORDER BY ID_Paciente DESC";

            using (SqlConnection conn = ConexionBD.ObtenerConexion())
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new Paciente
                            {
                                ID_Paciente = reader.GetInt32(0),
                                Nombre = reader.GetString(1),
                                Cedula = reader.GetString(2),
                                No_Carnet = reader.GetString(3),
                                Tipo_Paciente = reader.GetString(4),
                                Estado = reader.GetString(5)
                            });
                        }
                    }
                }
            }
            return lista;
        }

        /// <summary>
        /// Inserta un nuevo paciente en la base de datos.
        /// </summary>
        /// <param name="p">La entidad Paciente a insertar.</param>
        public void Insertar(Paciente p)
        {
            string query = "INSERT INTO dbo.Pacientes (Nombre, Cedula, No_Carnet, Tipo_Paciente, Estado) VALUES (@Nombre, @Cedula, @No_Carnet, @Tipo_Paciente, @Estado)";

            using (SqlConnection conn = ConexionBD.ObtenerConexion())
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Nombre", p.Nombre);
                    cmd.Parameters.AddWithValue("@Cedula", p.Cedula);
                    cmd.Parameters.AddWithValue("@No_Carnet", p.No_Carnet);
                    cmd.Parameters.AddWithValue("@Tipo_Paciente", p.Tipo_Paciente);
                    cmd.Parameters.AddWithValue("@Estado", p.Estado);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Actualiza un paciente existente en la base de datos.
        /// </summary>
        /// <param name="p">La entidad Paciente con los datos actualizados.</param>
        public void Actualizar(Paciente p)
        {
            string query = "UPDATE dbo.Pacientes SET Nombre = @Nombre, Cedula = @Cedula, No_Carnet = @No_Carnet, Tipo_Paciente = @Tipo_Paciente, Estado = @Estado WHERE ID_Paciente = @ID";

            using (SqlConnection conn = ConexionBD.ObtenerConexion())
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Nombre", p.Nombre);
                    cmd.Parameters.AddWithValue("@Cedula", p.Cedula);
                    cmd.Parameters.AddWithValue("@No_Carnet", p.No_Carnet);
                    cmd.Parameters.AddWithValue("@Tipo_Paciente", p.Tipo_Paciente);
                    cmd.Parameters.AddWithValue("@Estado", p.Estado);
                    cmd.Parameters.AddWithValue("@ID", p.ID_Paciente);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Elimina físicamente un paciente por su ID.
        /// </summary>
        /// <param name="id">El ID del paciente a eliminar.</param>
        public void Eliminar(int id)
        {
            string query = "DELETE FROM dbo.Pacientes WHERE ID_Paciente = @ID";

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
