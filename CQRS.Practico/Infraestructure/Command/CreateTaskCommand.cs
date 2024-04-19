using CQRS.Practico.Aplication.DTOs;
using MediatR;

namespace CQRS.Practico.Infraestructure.Command
{
    public record CreateTaskCommand(string Title, string Description) 
        : IRequest<TaskItemDTO>;
   
    
}
