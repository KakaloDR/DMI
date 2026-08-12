using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using GDM.Data.Modelos;

namespace GDM.Data
{
    /// <summary>
    /// Administra las operaciones de acceso a datos para la entidad Registro de Visitas.
    /// </summary>
    public class VisitaDAL
    {
        /// <summary>
        /// Obtiene todas las visitas de la base de datos realizando JOINs para traer descripciones legibles.
        /// </summary>
        /// <returns>Una lista de Visita.</returns>
        public List<Visita> ObtenerTodos()
        {
            var lista = new List<Visita>();
            string query = @"
                SELECT 
                    v.ID_Visita, 
                    v.FK_Medico, 
                    v.FK_Paciente, 
                    v.Fecha_Visita, 
                    v.Hora_Visita, 
                    v.Sintomas, 
                    v.FK_Medicamento, 
                    v.Recomendaciones, 
                    v.Estado,
                    m.Nombre AS MedicoNombre,
                    p.Nombre AS PacienteNombre,
                    med.Descripcion AS MedicamentoDesc
                FROM dbo.Registro_Visitas v
                INNER JOIN dbo.Medicos m ON v.FK_Medico = m.ID_Medico
                INNER JOIN dbo.Pacientes p ON v.FK_Paciente = p.ID_Paciente
                INNER JOIN dbo.Medicamentos med ON v.FK_Medicamento = med.ID_Medicamento
                ORDER BY v.ID_Visita DESC";

            using (SqlConnection conn = ConexionBD.ObtenerConexion())
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new Visita
                            {
                                ID_Visita = reader.GetInt32(0),
                                FK_Medico = reader.GetInt32(1),
                                FK_Paciente = reader.GetInt32(2),
                                Fecha_Visita = reader.GetDateTime(3),
                                Hora_Visita = reader.GetTimeSpan(4),
                                Sintomas = reader.GetString(5),
                                FK_Medicamento = reader.GetInt32(6),
                                Recomendaciones = reader.GetString(7),
                                Estado = reader.GetString(8),
                                MedicoNombre = reader.GetString(9),
                                PacienteNombre = reader.GetString(10),
                                MedicamentoDescripcion = reader.GetString(11)
                            });
                        }
                    }
                }
            }
            return lista;
        }

        /// <summary>
        /// Inserta un nuevo registro de visita en la base de datos de manera parametrizada.
        /// </summary>
        /// <param name="v">La entidad Visita a insertar.</param>
        public void Insertar(Visita v)
        {
            string query = @"
                INSERT INTO dbo.Registro_Visitas 
                    (FK_Medico, FK_Paciente, Fecha_Visita, Hora_Visita, Sintomas, FK_Medicamento, Recomendaciones, Estado) 
                VALUES 
                    (@FK_Medico, @FK_Paciente, @Fecha_Visita, @Hora_Visita, @Sintomas, @FK_Medicamento, @Recomendaciones, @Estado)";

            using (SqlConnection conn = ConexionBD.ObtenerConexion())
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@FK_Medico", v.FK_Medico);
                    cmd.Parameters.AddWithValue("@FK_Paciente", v.FK_Paciente);
                    cmd.Parameters.AddWithValue("@Fecha_Visita", v.Fecha_Visita.Date);
                    cmd.Parameters.AddWithValue("@Hora_Visita", v.Hora_Visita);
                    cmd.Parameters.AddWithValue("@Sintomas", v.Sintomas);
                    cmd.Parameters.AddWithValue("@FK_Medicamento", v.FK_Medicamento);
                    cmd.Parameters.AddWithValue("@Recomendaciones", v.Recomendaciones);
                    cmd.Parameters.AddWithValue("@Estado", v.Estado);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Actualiza un registro de visita existente en la base de datos de manera parametrizada.
        /// </summary>
        /// <param name="v">La entidad Visita con los datos modificados.</param>
        public void Actualizar(Visita v)
        {
            string query = @"
                UPDATE dbo.Registro_Visitas 
                SET FK_Medico = @FK_Medico, 
                    FK_Paciente = @FK_Paciente, 
                    Fecha_Visita = @Fecha_Visita, 
                    Hora_Visita = @Hora_Visita, 
                    Sintomas = @Sintomas, 
                    FK_Medicamento = @FK_Medicamento, 
                    Recomendaciones = @Recomendaciones, 
                    Estado = @Estado 
                WHERE ID_Visita = @ID";

            using (SqlConnection conn = ConexionBD.ObtenerConexion())
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@FK_Medico", v.FK_Medico);
                    cmd.Parameters.AddWithValue("@FK_Paciente", v.FK_Paciente);
                    cmd.Parameters.AddWithValue("@Fecha_Visita", v.Fecha_Visita.Date);
                    cmd.Parameters.AddWithValue("@Hora_Visita", v.Hora_Visita);
                    cmd.Parameters.AddWithValue("@Sintomas", v.Sintomas);
                    cmd.Parameters.AddWithValue("@FK_Medicamento", v.FK_Medicamento);
                    cmd.Parameters.AddWithValue("@Recomendaciones", v.Recomendaciones);
                    cmd.Parameters.AddWithValue("@Estado", v.Estado);
                    cmd.Parameters.AddWithValue("@ID", v.ID_Visita);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Elimina físicamente un registro de visita de la base de datos.
        /// </summary>
        /// <param name="id">El ID del registro de visita a eliminar.</param>
        public void Eliminar(int id)
        {
            string query = "DELETE FROM dbo.Registro_Visitas WHERE ID_Visita = @ID";

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
        /// <summary>
        /// Obtiene visitas filtradas por criterios dinámicos de forma parametrizada y segura.
        /// </summary>
        public List<Visita> ObtenerPorCriterios(int? idMedico, int? idPaciente, DateTime? desde, DateTime? hasta)
        {
            var lista = new List<Visita>();
            var query = new System.Text.StringBuilder(@"
                SELECT 
                    v.ID_Visita, 
                    v.FK_Medico, 
                    v.FK_Paciente, 
                    v.Fecha_Visita, 
                    v.Hora_Visita, 
                    v.Sintomas, 
                    v.FK_Medicamento, 
                    v.Recomendaciones, 
                    v.Estado,
                    m.Nombre AS MedicoNombre,
                    p.Nombre AS PacienteNombre,
                    med.Descripcion AS MedicamentoDesc
                FROM dbo.Registro_Visitas v
                INNER JOIN dbo.Medicos m ON v.FK_Medico = m.ID_Medico
                INNER JOIN dbo.Pacientes p ON v.FK_Paciente = p.ID_Paciente
                INNER JOIN dbo.Medicamentos med ON v.FK_Medicamento = med.ID_Medicamento
                WHERE 1=1");

            if (idMedico.HasValue) query.Append(" AND v.FK_Medico = @FK_Medico");
            if (idPaciente.HasValue) query.Append(" AND v.FK_Paciente = @FK_Paciente");
            if (desde.HasValue) query.Append(" AND v.Fecha_Visita >= @FechaDesde");
            if (hasta.HasValue) query.Append(" AND v.Fecha_Visita <= @FechaHasta");

            query.Append(" ORDER BY v.ID_Visita DESC");

            using (SqlConnection conn = ConexionBD.ObtenerConexion())
            {
                using (SqlCommand cmd = new SqlCommand(query.ToString(), conn))
                {
                    if (idMedico.HasValue) cmd.Parameters.AddWithValue("@FK_Medico", idMedico.Value);
                    if (idPaciente.HasValue) cmd.Parameters.AddWithValue("@FK_Paciente", idPaciente.Value);
                    if (desde.HasValue) cmd.Parameters.AddWithValue("@FechaDesde", desde.Value.Date);
                    if (hasta.HasValue) cmd.Parameters.AddWithValue("@FechaHasta", hasta.Value.Date);

                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new Visita
                            {
                                ID_Visita = reader.GetInt32(0),
                                FK_Medico = reader.GetInt32(1),
                                FK_Paciente = reader.GetInt32(2),
                                Fecha_Visita = reader.GetDateTime(3),
                                Hora_Visita = reader.GetTimeSpan(4),
                                Sintomas = reader.GetString(5),
                                FK_Medicamento = reader.GetInt32(6),
                                Recomendaciones = reader.GetString(7),
                                Estado = reader.GetString(8),
                                MedicoNombre = reader.GetString(9),
                                PacienteNombre = reader.GetString(10),
                                MedicamentoDescripcion = reader.GetString(11)
                            });
                        }
                    }
                }
            }
            return lista;
        }
    }
}
