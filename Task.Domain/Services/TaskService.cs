using Task.Domain.Entities;
using Task.Domain.Ports;

namespace Task.Application.Services
{
    public class TaskService : ITaskRepository
    {
        private readonly ITaskRepository _taskRepository;

        public TaskService(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public TASK Add(TASK entity)
        {
            var result = _taskRepository.Add(entity);
            return result;
        }

        public TASK Edit(TASK entity)
        {
            var result = _taskRepository.Edit(entity);
            return result;
        }

        public List<TASK> Get()
        {
            return _taskRepository.Get();
        }

        public int Delete(Guid id)
        {
            var result = _taskRepository.Delete(id);
            return result;
        }

        public TASK GeTaskById(Guid TId)
        {
            return _taskRepository.GeTaskById(TId);
        }
    }
}
