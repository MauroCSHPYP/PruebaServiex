using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using PSModel;

namespace WcfPruebaServiex
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class Service1 : IService1
    {
        PSData.PersonaData ms = new PSData.PersonaData();

        public IList<PSModel.Entidades.Persona> ObtenerPersonas(int? id_persona)
        {
            return ms.ObtenerPersonas(id_persona);
        }

        public int InsertarPersona(PSModel.Entidades.Persona persona)
        {
            return ms.InsertarPersona(persona);
        }

        public bool EditarPersona(PSModel.Entidades.Persona persona)
        {
            return ms.EditarPersona(persona);
        }

        public string EliminarPersona(int id_persona)
        {
            return ms.EliminarPersona(id_persona);
        }

        // --- 

        public IList<Persona> ObtenerPersonasPD(int? id_persona)
        {
            PSData.PersonaData ms = new PSData.PersonaData();
            IList<PSModel.Entidades.Persona> pps = new List<PSModel.Entidades.Persona>();
            pps = ms.ObtenerPersonas(id_persona);
            List<Persona> personas = new List<Persona>();
            foreach (PSModel.Entidades.Persona p in pps)
            {
                personas.Add(new Persona()
                {
                    Id = p.Id,
                    Nombre = p.Nombre,
                    FechaNacimiento = p.FechaNacimiento,
                    Sexo = p.Sexo
                });
            }
            return personas;
        }

        public int InsertarPersonaPD(Persona persona)
        {
            PSModel.Entidades.Persona p = new PSModel.Entidades.Persona();
            p.Id = persona.Id;
            p.Nombre = persona.Nombre;
            p.FechaNacimiento = persona.FechaNacimiento;
            p.Sexo = persona.Sexo;
            return ms.InsertarPersona(p);
        }

        public bool EditarPersonaPD(Persona persona)
        {
            PSModel.Entidades.Persona p = new PSModel.Entidades.Persona();
            p.Id = persona.Id;
            p.Nombre = persona.Nombre;
            p.FechaNacimiento = persona.FechaNacimiento;
            p.Sexo = persona.Sexo;
            return ms.EditarPersona(p);
        }

        public string EliminarPersonaPD(int id_persona)
        {
            return ms.EliminarPersona(id_persona);
        } 
    }
}
