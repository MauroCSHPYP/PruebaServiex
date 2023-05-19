using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PSModel.Entidades
{
    /// <summary>
    /// Modelo de la Persona.
    /// </summary>
    public class Persona
    {
        /// <summary>
        /// Id de la persona.
        /// </summary>
        private int id;

        /// <summary>
        /// Nombre de la persona.
        /// </summary>
        private string nombre;

        /// <summary>
        /// Fecha de nacimiento de la persona.
        /// </summary>
        private DateTime fechaNacimiento;

        /// <summary>
        /// Sexo de la persona. Valores aceptables: M || F.
        /// </summary>
        private string sexo;

        /// <summary>
        /// Id de la persona.
        /// </summary>
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        /// <summary>
        /// Nombre de la persona.
        /// </summary>
        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        /// <summary>
        /// Fecha de nacimiento de la persona.
        /// </summary>
        public DateTime FechaNacimiento
        {
            get { return fechaNacimiento; }
            set { fechaNacimiento = value; }
        }

        /// <summary>
        /// Sexo de la persona. Valores aceptables: M || F.
        /// </summary>
        public string Sexo
        {
            get { return sexo; }
            set { sexo = value; }
        }
    }
}