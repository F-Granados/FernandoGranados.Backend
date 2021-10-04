using System;
using System.Collections.Generic;
using System.Text;
using Entity;
using Data;

namespace Bussiness
{
    public class HijoBussiness
    {

        public List<HijoEntity> Listar(int id)
        {
            return Hijo.FiltrarHijo(id);
        }

        public List<HijoEntity> Listarhijo(int id)
        {
            return Hijo.FiltrarHijosId(id);
        }

        public string Registrar(HijoEntity entidad)
        {
            return Hijo.Registrar(entidad);
        }

        public string Modificar(HijoEntity entidad)
        {

            return Hijo.Modificar(entidad);
        }


        public string Eliminar(int id)
        {
            return Hijo.Eliminar(id);
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
