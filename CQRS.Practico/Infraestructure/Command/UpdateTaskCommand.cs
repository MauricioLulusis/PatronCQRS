using CQRS.Practico.Aplication.DTOs;
using MediatR;

namespace CQRS.Practico.Infraestructure.Command
{
    public record UpdateTaskCommand(string Title, int Id, bool IsCompleted, string Description) 
        : IRequest<TaskItemDTO>;
    
    
}
