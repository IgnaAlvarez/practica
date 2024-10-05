using db_practica.Data.Models;
using db_practica.Repositories;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace db_practica.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnviosController : ControllerBase
    {
        private IEnviosRepository _enviosRepository;
        public EnviosController(IEnviosRepository repository)
        {
            _enviosRepository = repository;
        }

        // GET: api/<EnviosController>
        
        [HttpGet]
        public IActionResult Get([FromQuery] DateTime f1, [FromQuery] DateTime f2)
        {
            try
            {
                var ListaExiste = _enviosRepository.GetAll(f1, f2);
                if (ListaExiste != null)
                {
                    return Ok(ListaExiste);
                }
                else return BadRequest("La lista esta vacia");
            }
            catch (Exception)
            {

                return StatusCode(500, "Hubo un error de conexion");
            }
            
        }

  

        // POST api/<EnviosController>
        [HttpPost]
        public IActionResult Post([FromBody] TEnvio envio)
        {
            try
            {
                if (IsValid(envio))
                {
                    _enviosRepository.Create(envio);
                    return Ok("Envio Creado con exito");
                }
                else return BadRequest("Envido no creado");

            }
            catch (Exception)
            {

                return StatusCode(500, "Hubo un error.");
            }
        }

        // PUT api/<EnviosController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id)
        {
            try
            {

                _enviosRepository.Update(id);
                return Ok("Se actualizo");
            }
            catch (Exception)
            {

                return StatusCode(500, "Hubo un error.");
            }
        }

        // DELETE api/<EnviosController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        private bool IsValid(TEnvio envio) 
        {
            return !string.IsNullOrWhiteSpace(envio.Direccion) && !string.IsNullOrWhiteSpace(envio.Estado) && !string.IsNullOrWhiteSpace(envio.DniCliente) && envio.IdEmpresa > 0;
        }
    }
}
