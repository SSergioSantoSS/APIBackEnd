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
    public class TarefasController : ControllerBase
    {

        private readonly TarefaService _tarefaService;

        public TarefasController(TarefaService tarefaService)
        {
            _tarefaService = tarefaService;
        }

        // GET: api/<TarefasController>        
        [HttpGet]
        public ActionResult<List<Tarefa>> Get() =>
            _tarefaService.Get();


        [HttpGet("{id:length(24)}", Name = "GetTarefa")]
        public ActionResult<Tarefa> Get(string id)
        {
            var Tarefa = _tarefaService.Get(id);

            if (Tarefa == null)
            {
                return NotFound();
            }

            return Tarefa;
        }

        [HttpPost]
        public ActionResult<Tarefa> Create(Tarefa Tarefa)
        {
            _tarefaService.Create(Tarefa);

            return CreatedAtRoute("GetTarefa", new { id = Tarefa.Id.ToString() }, Tarefa);
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, Tarefa TarefaIn)
        {
            var Tarefa = _tarefaService.Get(id);

            if (Tarefa == null)
            {
                return NotFound();
            }

            _tarefaService.Update(id, TarefaIn);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var Tarefa = _tarefaService.Get(id);

            if (Tarefa == null)
            {
                return NotFound();
            }

            _tarefaService.Remove(Tarefa.Id);

            return NoContent();
        }
    }
}