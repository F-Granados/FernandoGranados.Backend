using Data;
using Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bussiness
{
   public class PersonasBussiness
    {

        public List<PersonaEntity> Listar()
        {
            return Persona.Listar();
        }

        public List<PersonaEntity> Filtrar(PersonaEntity entidad)
        {
            return Persona.Filtrar(entidad);
        }

        public string Registrar(PersonaEntity entidad)
        {
            return Persona.Registrar(entidad);
        }

        public string Modificar(PersonaEntity entidad)
        {

            return Persona.Modificar(entidad);
        }


        public string Eliminar(PersonaEntity entidad)
        {
            return Persona.Eliminar(entidad);
        }







        public long registrar (Persona persona)
        {
            Persona personaData = new Persona();
            return 1;
        }

        public PersonaEntity ListarPorId(int id)
        {
            return Persona.ListarPorId(id);
        }

        //public List<PersonaEntity> listar()
        //{
        //    Persona personaData = new Persona();
        //    return personaData.listar();
        //}

    }
}
