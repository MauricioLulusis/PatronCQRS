using MediatR;

namespace CQRS.Practico.Infraestructure.Command
{
    public record DeleteTaskCommand(int Id) : IRequest<bool>;
    
    
}
