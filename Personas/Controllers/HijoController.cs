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

    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class HijoController : Controller
    {
        [HttpGet("Listar")]
        public List<HijoEntity> Listar()
        {
            HijoBussiness oHijo = new HijoBussiness();
            return oHijo.Listar();
        }
        //ListarPorId

        //[HttpGet("ListarId/{id}")]
        //public HijoEntity ListarId(int id)
        //{

        //    HijoEntity oPersona = new HijoEntity();
        //    return oPersona.ListarPorId(id);
        //}


        [HttpPost("Filtrar")]
        public List<HijoEntity> Filtrar([FromBody] HijoEntity entidad)
        {

            HijoBussiness oHijo = new HijoBussiness();
            return oHijo.Filtrar(entidad);
        }


        [HttpPost("Registrar")]
        public JsonResult Registrar([FromBody] HijoEntity entidad)
        {

            HijoBussiness oPersona = new HijoBussiness();
            var resultado = oPersona.Registrar(entidad);
            string json = "{'resultado':" + resultado + "}";
            var jsonObject = new JsonResult(json);


            return jsonObject;

        }



        [HttpPut("Modificar")]
        public string Modificar([FromBody] HijoEntity entidad)
        {
            HijoBussiness oPersona = new HijoBussiness();
            return oPersona.Modificar(entidad);
        }


        [HttpDelete("Eliminar")]
        public string Eliminar([FromBody] HijoEntity entidad)
        {

            HijoBussiness oPersona = new HijoBussiness();
            return oPersona.Eliminar(entidad);
        }
    }
}
