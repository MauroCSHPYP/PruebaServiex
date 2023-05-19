using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace PSData.Database
{
    /// <summary>
    /// Clase que contiene el código para conectarse a la base de datos.
    /// </summary>
    public class Conexion
    {
        #region Atributos privados

        protected SqlConnection _cn = null;
        protected SqlCommand _cmd = null;
        protected SqlDataReader _dr = null;

        #endregion

        public Conexion()
        {
            _cn = new SqlConnection(CadenaConexion);
        }

        /// <summary>
        /// Retornar la cadena de conexión.
        /// </summary>
        public string CadenaConexion
        {
            get
            {
                return System.Configuration.ConfigurationManager.
                    ConnectionStrings["cadenaconexion"].ConnectionString;
            }
        }

        /// <summary>
        /// Abrir la conexión a base de datos.
        /// </summary>
        public void Abrir()
        {
            try
            {
                _cn.Open();
            }
            catch (SqlException es)
            {
                throw new Exception(es.Message);
            }
        }

        /// <summary>
        /// Cerrar la conexión a base de datos.
        /// </summary>
        public void Cerrar()
        {
            if (_cn != null)
            {
                if (_cn.State != ConnectionState.Closed)
                    _cn.Close();
            }
        }

        /// <summary>
        /// Estado de la conexión a la base de datos.
        /// </summary>
        public ConnectionState EstadoConexion { get { return _cn.State; } }
    }
}