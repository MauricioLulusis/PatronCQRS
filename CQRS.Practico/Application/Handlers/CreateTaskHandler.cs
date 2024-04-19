using CQRS.Practico.Aplication.DTOs;
using CQRS.Practico.Domain;
using CQRS.Practico.Infraestructure;
using CQRS.Practico.Infraestructure.Command;
using MediatR;

namespace CQRS.Practico.Application.Handlers
{
    public class CreateTaskHandler : IRequestHandler<CreateTaskCommand, TaskItemDTO>
    {
        private readonly ApplicationDbContext _dbContext;

        public CreateTaskHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<TaskItemDTO> Handle(CreateTaskCommand request, CancellationToken cancellationToken)
        {
            var taskItem = new TaskItem
            {
                Title = request.Title,
                Description = request.Description,
            };

            _dbContext.TaskItems.Add(taskItem);
            await _dbContext.SaveChangesAsync();

            return new TaskItemDTO
            {
                Id = taskItem.Id,
                Title = taskItem.Title,
                Description = taskItem.Description,
                IsCompleted = taskItem.IsCompleted

            };

        }
    }
}
