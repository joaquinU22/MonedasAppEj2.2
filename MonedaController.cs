using Microsoft.AspNetCore.Mvc;
using MonedasApp.Models;

namespace MonedasApp
{
    [Route("api/[controller]")]
    [ApiController]
    public class MonedaController : Controller
    {
        private static readonly  List<Moneda> lstMoneda = new List<Moneda>();

        //este metodo maneja las solicitudes GET a api/moneda, si la lista esta vacia devuelve 404, y si hay monedas devuelve 200
        [HttpGet]
        public IActionResult GetMonedas()
        {
            if (lstMoneda.Count == 0)
            {
                return NotFound("No se encontraron resultados.");
                //devolver 404
            }
            return Ok(lstMoneda);//listado de monedas
        }

        //maneja las solicidudes get a api/moneda/{name}.Busca una moneda por su nombre y devuelve 404, si no devolvio devuelve 200
        [HttpGet("{name}")]
        public IActionResult GetMonedaName(string name)
        {
            //lstMoneda contiene todas las monedas que se agregaron en el post.Find es como si fuera list que busca un elemento en la lista que cumple con la condiciuon especifica.
            //y lo ultimo es una exprecion de lambada: moneda es el parametro que representa cada elemento de la lista, y lo demas es la condicion que se verifica para cada elemento en la lista 
            //la condicion compara la propiedad Nombre del objeto moneda con el valor del parametro name 
            var moneda = lstMoneda
                .Find(moneda => moneda.Nombre == name);//busca un elemento especifico en una lista 

            if (moneda == null)
            {
                return NotFound("No se encontraron resultados.");
                //devolver 404
            }
            return Ok(moneda);
        }

        //este metodo maneja las solicitudes POST a api/moneda. Agega una nueva moneda a la lista. si la moneda es valida, se agrega a la lista y se devuelve un 200(ok). si ocurre una excepcion se devuelve un 500
        [HttpPost]
        public IActionResult postMoneda(Moneda moneda)
        {
            try
            {
                if(moneda != null)
                {
                    lstMoneda.Add(moneda);
                    return Ok();
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                //internal Server
                return StatusCode(500,ex.Message);
                throw;
            }
        }
    }
}
