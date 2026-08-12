using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using GDM.Data.Modelos;

namespace GDM.Data
{
    /// <summary>
    /// Administra las operaciones de acceso a datos para la entidad Medicamento.
    /// </summary>
    public class MedicamentoDAL
    {
        /// <summary>
        /// Obtiene la lista completa de medicamentos registrando las descripciones relacionales mediante JOINs.
        /// </summary>
        /// <returns>Lista de Medicamento.</returns>
        public List<Medicamento> ObtenerTodos()
        {
            var lista = new List<Medicamento>();
            string query = @"
                SELECT 
                    m.ID_Medicamento, 
                    m.Descripcion, 
                    m.FK_Tipo_Farmaco, 
                    m.FK_Marca, 
                    m.FK_Ubicacion, 
                    m.Dosis, 
                    m.Estado,
                    t.Descripcion AS TipoFarmacoDesc,
                    b.Descripcion AS MarcaDesc,
                    u.Descripcion + ' (' + u.Estante + '/' + u.Tramo + '/' + u.Celda + ')' AS UbicacionDesc
                FROM dbo.Medicamentos m
                INNER JOIN dbo.Tipos_Farmacos t ON m.FK_Tipo_Farmaco = t.ID_Tipo_Farmaco
                INNER JOIN dbo.Marcas b ON m.FK_Marca = b.ID_Marca
                INNER JOIN dbo.Ubicaciones u ON m.FK_Ubicacion = u.ID_Ubicacion
                ORDER BY m.ID_Medicamento DESC";

            using (SqlConnection conn = ConexionBD.ObtenerConexion())
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new Medicamento
                            {
                                ID_Medicamento = reader.GetInt32(0),
                                Descripcion = reader.GetString(1),
                                FK_Tipo_Farmaco = reader.GetInt32(2),
                                FK_Marca = reader.GetInt32(3),
                                FK_Ubicacion = reader.GetInt32(4),
                                Dosis = reader.GetString(5),
                                Estado = reader.GetString(6),
                                TipoFarmacoDescripcion = reader.GetString(7),
                                MarcaDescripcion = reader.GetString(8),
                                UbicacionDescripcion = reader.GetString(9)
                            });
                        }
                    }
                }
            }
            return lista;
        }

        /// <summary>
        /// Inserta un nuevo medicamento en la base de datos.
        /// </summary>
        /// <param name="m">La entidad Medicamento a insertar.</param>
        public void Insertar(Medicamento m)
        {
            string query = @"
                INSERT INTO dbo.Medicamentos (Descripcion, FK_Tipo_Farmaco, FK_Marca, FK_Ubicacion, Dosis, Estado) 
                VALUES (@Descripcion, @FK_Tipo_Farmaco, @FK_Marca, @FK_Ubicacion, @Dosis, @Estado)";

            using (SqlConnection conn = ConexionBD.ObtenerConexion())
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Descripcion", m.Descripcion);
                    cmd.Parameters.AddWithValue("@FK_Tipo_Farmaco", m.FK_Tipo_Farmaco);
                    cmd.Parameters.AddWithValue("@FK_Marca", m.FK_Marca);
                    cmd.Parameters.AddWithValue("@FK_Ubicacion", m.FK_Ubicacion);
                    cmd.Parameters.AddWithValue("@Dosis", m.Dosis);
                    cmd.Parameters.AddWithValue("@Estado", m.Estado);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Actualiza un medicamento existente en la base de datos.
        /// </summary>
        /// <param name="m">La entidad Medicamento con los datos actualizados.</param>
        public void Actualizar(Medicamento m)
        {
            string query = @"
                UPDATE dbo.Medicamentos 
                SET Descripcion = @Descripcion, 
                    FK_Tipo_Farmaco = @FK_Tipo_Farmaco, 
                    FK_Marca = @FK_Marca, 
                    FK_Ubicacion = @FK_Ubicacion, 
                    Dosis = @Dosis, 
                    Estado = @Estado 
                WHERE ID_Medicamento = @ID";

            using (SqlConnection conn = ConexionBD.ObtenerConexion())
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Descripcion", m.Descripcion);
                    cmd.Parameters.AddWithValue("@FK_Tipo_Farmaco", m.FK_Tipo_Farmaco);
                    cmd.Parameters.AddWithValue("@FK_Marca", m.FK_Marca);
                    cmd.Parameters.AddWithValue("@FK_Ubicacion", m.FK_Ubicacion);
                    cmd.Parameters.AddWithValue("@Dosis", m.Dosis);
                    cmd.Parameters.AddWithValue("@Estado", m.Estado);
                    cmd.Parameters.AddWithValue("@ID", m.ID_Medicamento);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Elimina físicamente un medicamento por su ID.
        /// </summary>
        /// <param name="id">El ID del medicamento a eliminar.</param>
        public void Eliminar(int id)
        {
            string query = "DELETE FROM dbo.Medicamentos WHERE ID_Medicamento = @ID";

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
