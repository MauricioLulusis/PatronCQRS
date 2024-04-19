using CQRS.Practico.Aplication.DTOs;
using CQRS.Practico.Domain;
using CQRS.Practico.Infraestructure;
using CQRS.Practico.Infraestructure.Command;
using MediatR;

namespace CQRS.Practico.Application.Handlers
{
    public class UpdateTaskHandler : IRequestHandler<UpdateTaskCommand, TaskItemDTO>
    {
        private readonly ApplicationDbContext _dbContext;

        public UpdateTaskHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<TaskItemDTO> Handle(UpdateTaskCommand request, CancellationToken cancellationToken)
        {
            var taskItem = await _dbContext.TaskItems.FindAsync(new object[] { request.Id }, cancellationToken);
            
            if(taskItem == null)
            {
                return null;
            }
            taskItem.Title = request.Title;
            taskItem.Description = request.Description;
            taskItem.IsCompleted = request.IsCompleted;
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
