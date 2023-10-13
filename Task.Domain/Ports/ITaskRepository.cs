using Task.Domain.Entities;

namespace Task.Domain.Ports
{
    public interface ITaskRepository
    {
        TASK Add(TASK entity);
        int Delete(Guid id);
        TASK Edit(TASK entity);
        List<TASK> Get();
        TASK GeTaskById(Guid TId);
    }
}
