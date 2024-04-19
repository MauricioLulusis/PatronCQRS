using CQRS.Practico.Aplication.DTOs;
using CQRS.Practico.Infraestructure;
using CQRS.Practico.Infraestructure.Queris;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CQRS.Practico.Application.Handlers
{
    public class GetAllTaskHandler : IRequestHandler<GetAllTaskQuery, IEnumerable<TaskItemDTO>>
    {
        private readonly ApplicationDbContext _dbContext;

        public GetAllTaskHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IEnumerable<TaskItemDTO>> Handle(GetAllTaskQuery request, CancellationToken cancellationToken)
        {
            var task = await _dbContext.TaskItems.ToListAsync(cancellationToken);

            return task.Select(task => new TaskItemDTO
            {
                Id = task.Id,
                Title = task.Title,
                Description = task.Description,
                IsCompleted = task.IsCompleted,
            });
        }
    }
}
