using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entity;
using Bussiness;
using Microsoft.AspNetCore.Authorization;
using System.Text.Json;

namespace PersonasAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class PersonaController : ControllerBase
    {

        [HttpGet("Listar")]
        public List<PersonaEntity> Listar()
        {
            PersonasBussiness oPersona = new PersonasBussiness();
            return oPersona.Listar();
        }
        //ListarPorId

        [HttpGet("{id:int}")]
        public List<PersonaEntity> ListarPorId(int id) { 
        
            PersonasBussiness oPersona = new PersonasBussiness();
            return oPersona.ListarPorId(id);
        }


        //[HttpPost("Filtrar")]
        //public List<PersonaEntity> Filtrar([FromBody] PersonaEntity entidad)
        //{

        //    PersonasBussiness oPersona = new PersonasBussiness();
        //    return oPersona.Filtrar(entidad);
        //}


        //[HttpPost("Registrar")]
        //public JsonResult Registrar([FromBody] PersonaEntity entidad)
        //{

        //    PersonasBussiness oPersona = new PersonasBussiness();
        //   var resultado =  oPersona.Registrar(entidad);
        //    string json =  "{'resultado':"+ resultado + "}";
        //    var jsonObject = new JsonResult(json);


        //    return jsonObject;

        //}

        [HttpPost]
        public string Registrar([FromBody] PersonaEntity entidad)
        {
            PersonasBussiness oPersona = new PersonasBussiness();
            return oPersona.Registrar(entidad);
        }


        [HttpPut("Modificar")]
        public string Modificar([FromBody] PersonaEntity entidad)
        {
            PersonasBussiness oPersona = new PersonasBussiness();
            return oPersona.Modificar(entidad);
        }


        [HttpDelete("{id:int}")]
        public string Eliminar(int id)
        {
            var Opersona = new PersonasBussiness();
            return Opersona.Eliminar(id);

            //PersonasBussiness oPersona = new PersonasBussiness();
            //return oPersona.Eliminar(entidad);
        }




        //[HttpGet]
        //public IEnumerable<PersonaEntity> Get()
        //{
        //    PersonasBussiness pb = new PersonasBussiness();

        //    return (IEnumerable<PersonaEntity>)pb.listar();
        //}
    }
}
