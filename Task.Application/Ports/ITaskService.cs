using Task.Domain.Entities;

namespace Task.Application.Ports
{
    internal interface ITaskService
    {
        TASK Add(TASK entity);
        TASK Edit(TASK entity);
        List<TASK> Get();
        int Delete(Guid id);
        TASK GeTaskById(Guid TId);
    }
}
