using CQRS.Practico.Aplication.DTOs;
using MediatR;

namespace CQRS.Practico.Infraestructure.Queris
{
    public record GetAllTaskQuery : IRequest<IEnumerable<TaskItemDTO>>;
    
    
}
