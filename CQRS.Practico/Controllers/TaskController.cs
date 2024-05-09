using CQRS.Practico.Aplication.DTOs;
using CQRS.Practico.Infraestructure.Command;
using CQRS.Practico.Infraestructure.Queris;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CQRS.Practico.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TaskController (IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IEnumerable<TaskItemDTO>> GetAll()
        {
            //Tengo el getAll tengo que devolver una colección de TaskItemDTO
            //utilizo mediator utilizando su método Send, le digo cual es su request (cual es el comando o la query que tengo que usar) 
            return await _mediator.Send(new GetAllTaskQuery());
        }

        [HttpGet("{id}")]
        public async Task <ActionResult<TaskItemDTO>>GetById(int id)
        {
            //Creo un nuevo objeto GetTaskByIdQuery (es un record es inmutable), le envío el id
            var query = new GetTaskByIdQuery(id);
            //tengo el mediator haciendo send
            var taskItem=await _mediator.Send(query);
            //si el task item esta en nulo, devolveme un not found
            if (taskItem == null) 
            {
                return NotFound();
            }
            return taskItem;
        }
        [HttpPost]
        //es un create CreateTaskCommand porque estoy creando 
        public async Task <ActionResult<TaskItemDTO>>Create (CreateTaskCommand command)
        {
            //mediator hace el envio al handler que corresponda
            var taskItem= await _mediator.Send(command);
            //y luego devuelve un    
            return CreatedAtAction(nameof(GetById),new { id = taskItem.Id }, taskItem);
        }

        [HttpPut("{id}")]
        //recib un id y un updatetask
        
        public async Task<ActionResult<TaskItemDTO>> Update(int id, UpdateTaskCommand command)
        {
            //verifica que el id que me esta enviando por parametro es el mismo que está en el cuerpo
            if(id !=command.Id)
            {
                return BadRequest();  //armar esto es buena práctica
            }

            //usamos el mediator para buscar el handler
            var taskItem = await _mediator.Send(command);

            //si es null devuelve not found 
            if (taskItem==null)
            {
                return NotFound();
            }

            // o sino un NoContent
            return NoContent();
        }

        [HttpDelete("{id}")]
        //recibe un id
        public async Task<ActionResult>Delete(int id)
        {
            //utiliza mediator para encontrar el handler, PROBANDO PARA TRABAJO DE INGENIERIA EN  SOFTWARE
            var result=await _mediator.Send(new DeleteTaskCommand(id));
            // y segun el resultad va a devolver un NotFound
            if (!result)
            {
                return NotFound();
            }
            // o un no content
            return NoContent() ;
        }
    }
}
