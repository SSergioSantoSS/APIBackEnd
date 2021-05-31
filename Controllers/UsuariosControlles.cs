using ApiTarefa.Models;
using ApiTarefa.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiTarefa.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {

        private readonly UsuarioService _usuarioService;

        public UsuariosController(UsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        // GET: api/<UsuariosController>        
        [HttpGet]
        public ActionResult<List<Usuario>> Get() =>
            _usuarioService.Get();


        [HttpGet("{id:length(24)}", Name = "GetUsuario")]
        public ActionResult<Usuario> Get(string id)
        {
            var Usuario = _usuarioService.Get(id);

            if (Usuario == null)
            {
                return NotFound();
            }

            return Usuario;
        }

        [HttpPost]
        public ActionResult<Usuario> Create(Usuario Usuario)
        {
            _usuarioService.Create(Usuario);

            return CreatedAtRoute("GetUsuario", new { id = Usuario.Id.ToString() }, Usuario);
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, Usuario UsuarioIn)
        {
            var Usuario = _usuarioService.Get(id);

            if (Usuario == null)
            {
                return NotFound();
            }

            _usuarioService.Update(id, UsuarioIn);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var Usuario = _usuarioService.Get(id);

            if (Usuario == null)
            {
                return NotFound();
            }

            _usuarioService.Remove(Usuario.Id);

            return NoContent();
        }
    }
}