using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entity;
using Bussiness;

namespace PersonasAPI.Controllers
{

    //[Route("api/[controller]")]
    [Route("[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class HijoController : Controller
    {
        [HttpGet("{id:int}")]
        public List<HijoEntity> Listar(int id)
        {
            HijoBussiness oHijo = new HijoBussiness();
            return oHijo.Listar(id);
        }


        [HttpGet("Filtrar/{id:int}")]
        public List<HijoEntity> Filtrarhijo(int id)
        {

            HijoBussiness oHijo = new HijoBussiness();
            return oHijo.Listarhijo(id);
        }


        [HttpPost]
        public string Registrar([FromBody] HijoEntity entidad)
        {

            HijoBussiness oHijo = new HijoBussiness();
            return oHijo.Registrar(entidad);
            //HijoBussiness oPersona = new HijoBussiness();
            //var resultado = oPersona.Registrar(entidad);
            //string json = "{'resultado':" + resultado + "}";
            //var jsonObject = new JsonResult(json);
            //return jsonObject;

        }



        [HttpPut("Modificar")]
        public string Modificar([FromBody] HijoEntity entidad)
        {
            HijoBussiness oPersona = new HijoBussiness();
            return oPersona.Modificar(entidad);
        }


        [HttpDelete("{id:int}")]
        public string Eliminar(int id)
        {

            HijoBussiness oPersona = new HijoBussiness();
            return oPersona.Eliminar(id);
        }
    }
}
