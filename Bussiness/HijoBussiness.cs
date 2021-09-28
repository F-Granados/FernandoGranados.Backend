using System;
using System.Collections.Generic;
using System.Text;
using Entity;
using Data;

namespace Bussiness
{
    public class HijoBussiness
    {

        public List<HijoEntity> Listar()
        {
            return Hijo.Listar();
        }

        public List<HijoEntity> Filtrar(HijoEntity entidad)
        {
            return Hijo.Filtrar(entidad);
        }

        public string Registrar(HijoEntity entidad)
        {
            return Hijo.Registrar(entidad);
        }

        public string Modificar(HijoEntity entidad)
        {

            return Hijo.Modificar(entidad);
        }


        public string Eliminar(HijoEntity entidad)
        {
            return Hijo.Eliminar(entidad);
        }



        public long registrar(Hijo hijo)
        {
            Hijo personaData = new Hijo();
            return 1;
        }

        //public HijoEntity ListarPorId(int id)
        //{
        //    return Hijo.ListarPorId(id);
        //}
    }
}
