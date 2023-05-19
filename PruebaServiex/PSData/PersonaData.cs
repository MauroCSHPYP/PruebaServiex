using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PSModel;

namespace PSData
{
    public class PersonaData : Database.Conexion
    {
        /// <summary>
        /// Permite almacenar una Persona.
        /// </summary>
        /// <param name="Persona">Modelo de la Persona</param>
        /// <returns>Id de la persona</returns>
        public int InsertarPersona(PSModel.Entidades.Persona persona)
        {
            int id_persona = 0;

            try
            {
                Abrir();

                _cmd = new System.Data.SqlClient.SqlCommand();
                _cmd.Connection = _cn;
                _cmd.CommandType = System.Data.CommandType.StoredProcedure;
                _cmd.CommandText = "SP_CRUD_PERSONA";

                _cmd.Parameters.Add("@PROC_TYPE", System.Data.SqlDbType.Int, 50).Value = 1;

                _cmd.Parameters.Add("@NOMBRE"
                    , System.Data.SqlDbType.NVarChar
                    , 100).Value = persona.Nombre;

                _cmd.Parameters.Add("@FECHA_NACIMIENTO"
                    , System.Data.SqlDbType.DateTime).Value = persona.FechaNacimiento;

                _cmd.Parameters.Add("@SEXO"
                    , System.Data.SqlDbType.NVarChar
                    , 1).Value = persona.Sexo;

                id_persona = (Int32)_cmd.ExecuteScalar();

                Cerrar();
            }
            catch (Exception ex)
            {
                id_persona = -1;
            }
            finally
            {
                if (EstadoConexion == System.Data.ConnectionState.Open)
                {
                    Cerrar();
                }
            }

            return id_persona;
        }

        /// <summary>
        /// Permite editar una Persona.
        /// </summary>
        /// <param name="Persona">Modelo de la Persona</param>
        /// <returns>Boolean</returns>
        public bool EditarPersona(PSModel.Entidades.Persona persona)
        {
            bool eliminado = false;

            try
            {
                Abrir();

                _cmd = new System.Data.SqlClient.SqlCommand();
                _cmd.Connection = _cn;
                _cmd.CommandType = System.Data.CommandType.StoredProcedure;
                _cmd.CommandText = "SP_CRUD_PERSONA";

                _cmd.Parameters.Add("@PROC_TYPE", System.Data.SqlDbType.Int, 50).Value = 2;

                _cmd.Parameters.Add("@ID",
                    System.Data.SqlDbType.Int).Value = persona.Id;

                _cmd.Parameters.Add("@NOMBRE"
                    , System.Data.SqlDbType.NVarChar
                    , 100).Value = persona.Nombre;

                _cmd.Parameters.Add("@FECHA_NACIMIENTO"
                    , System.Data.SqlDbType.DateTime).Value = persona.FechaNacimiento;

                _cmd.Parameters.Add("@SEXO"
                    , System.Data.SqlDbType.NVarChar
                    , 1).Value = persona.Sexo;
                _cmd.ExecuteNonQuery();

                Cerrar();

                eliminado = true;
            }
            catch (Exception ex)
            {
                string msg = ex.ToString();
            }
            finally
            {
                if (EstadoConexion == System.Data.ConnectionState.Open)
                {
                    Cerrar();
                }
            }

            return eliminado;
        }

        /// <summary>
        /// Permite eliminar una persona seleccionada.
        /// </summary>
        /// <param name="id_persona">Id de la persona.</param>
        /// <param name="Nombre_Persona">Modelo de la Persona</param>
        /// <returns>Mensaje de error (si hay alguno).</returns>
        public string EliminarPersona(int id_persona)
        {
            string deleted = "";

            try
            {
                Abrir();

                _cmd = new System.Data.SqlClient.SqlCommand();
                _cmd.Connection = _cn;
                _cmd.CommandType = System.Data.CommandType.StoredProcedure;
                _cmd.CommandText = "SP_CRUD_PERSONA";

                _cmd.Parameters.Add("@PROC_TYPE", System.Data.SqlDbType.Int, 50).Value = 4;
                _cmd.Parameters.Add("@ID", System.Data.SqlDbType.Int).Value = id_persona;

                _cmd.ExecuteNonQuery();

                Cerrar();
            }
            catch (Exception ex)
            {
                deleted = ex.ToString();
            }
            finally
            {
                if (EstadoConexion == System.Data.ConnectionState.Open)
                {
                    Cerrar();
                }
            }

            return deleted;
        }

        /// <summary>
        /// Permite obtener una lista de las personas.
        /// </summary>
        /// <param name="id_persona">Id de la persona = opcional.</param>
        /// <returns>Listado de personas</returns>
        public IList<PSModel.Entidades.Persona> ObtenerPersonas(int? id_persona)
        {
            // se crea una nueva colección
            IList<PSModel.Entidades.Persona> _Personas =
                new List<PSModel.Entidades.Persona>();

            try
            {
                Abrir();
                // se configura el commandtype storedprocedure para soportar procedimientos almacenados
                _cmd = new System.Data.SqlClient.SqlCommand();
                _cmd.Connection = _cn;
                _cmd.CommandType = System.Data.CommandType.StoredProcedure;
                _cmd.CommandText = "SP_CRUD_PERSONA";

                _cmd.Parameters.Add("@PROC_TYPE", System.Data.SqlDbType.Int, 50).Value = 3;

                if (id_persona.HasValue)
                {
                    _cmd.Parameters.Add("@ID"
                        , System.Data.SqlDbType.Int).Value = id_persona.Value;
                }
                else
                {
                    _cmd.Parameters.Add("@ID"
                    , System.Data.SqlDbType.Int).Value = DBNull.Value;
                }

                // se obtiene la información de la consulta
                _dr = _cmd.ExecuteReader();

                // se realiza la lectura de los datos 
                while (_dr.Read())
                {

                    //se crea una nueva referencia de la Persona
                    PSModel.Entidades.Persona _Persona
                        = new PSModel.Entidades.Persona();
                    // se realiza la asignación de campos
                    _Persona.Id = _dr.GetInt32(0);
                    _Persona.Nombre = _dr.GetString(1);
                    _Persona.FechaNacimiento = _dr.GetDateTime(2);
                    _Persona.Sexo = _dr.GetString(3);
                    // se almacena el género en la colección
                    _Personas.Add(_Persona);

                }
                //se cierra el data reader
                _dr.Close();
                //se destruye el data reader
                _dr = null;

                // se cierra la conexion
                Cerrar();
            }
            catch (Exception ex)
            {
                string msg = ex.ToString();
            }
            finally
            {
                if (EstadoConexion == System.Data.ConnectionState.Open)
                {
                    Cerrar();
                }
            }
            // se devuleve la lista de las personas 
            return _Personas;
        }
    }
}
