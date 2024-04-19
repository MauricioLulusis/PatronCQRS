using CQRS.Practico.Aplication.DTOs;
using CQRS.Practico.Infraestructure;
using CQRS.Practico.Infraestructure.Queris;
using MediatR;

namespace CQRS.Practico.Application.Handlers
{
    public class GetTaskByIdHandler : IRequestHandler<GetTaskByIdQuery, TaskItemDTO>
    {
        private readonly ApplicationDbContext _dbContext;

        public GetTaskByIdHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<TaskItemDTO> Handle(GetTaskByIdQuery request, CancellationToken cancellationToken)
        {
            var taskItem = await _dbContext.TaskItems.FindAsync(new object[] { request.Id }, cancellationToken);

            if (taskItem == null)
            {
                return null;
            }

            return new TaskItemDTO
            {
                Id = taskItem.Id,
                Title = taskItem.Title,
                Description = taskItem.Description,
                IsCompleted = taskItem.IsCompleted,
            };
        }
    }
}
