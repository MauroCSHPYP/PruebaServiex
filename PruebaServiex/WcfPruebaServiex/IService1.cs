using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using PSModel;

namespace WcfPruebaServiex
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {
        /// <summary>
        /// Obtener todas las personas - o solo la indicada (según su ID).
        /// </summary>
        /// <param name="id_persona">Id de la persona - opcional.</param>
        /// <returns>Persona(s).</returns>
        [OperationContract]
        IList<PSModel.Entidades.Persona> ObtenerPersonas(int? id_persona);

        [OperationContract]
        int InsertarPersona(PSModel.Entidades.Persona p);

        [OperationContract]
        bool EditarPersona(PSModel.Entidades.Persona p);

        [OperationContract]
        string EliminarPersona(int id_persona);

        // ----

        [OperationContract]
        IList<Persona> ObtenerPersonasPD(int? id_persona);

        [OperationContract]
        int InsertarPersonaPD(Persona p);

        [OperationContract]
        bool EditarPersonaPD(Persona p);

        [OperationContract]
        string EliminarPersonaPD(int id_persona);
    }

    // Use a data contract as illustrated in the sample below to add composite types to service operations.

    /// <summary>
    /// Persona - contrato.
    /// </summary>
    [DataContract]
    public class Persona
    {
        int id;

        [DataMember]
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        string nombre;
        [DataMember]
        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        DateTime fechaNacimiento;
        [DataMember]
        public DateTime FechaNacimiento
        {
            get { return fechaNacimiento; }
            set { fechaNacimiento = value; }
        }

        string sexo;
        [DataMember]
        public string Sexo
        {
            get { return sexo; }
            set { sexo = value; }
        }
    }
}