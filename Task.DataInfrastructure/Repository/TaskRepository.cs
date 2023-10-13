using Task.DataInfrastructure.Base;
using Task.DataInfrastructure.Context;
using Task.Domain.Entities;
using Task.Domain.Ports;

namespace Task.DataInfrastructure.Repository
{
    public class TaskRepository : IBaseRepository<TASK, int>,ITaskRepository
    {
        private TaskDbContext _db;

        public TaskRepository(TaskDbContext db)
        {
            this._db = db;
        }

        public TASK Add(TASK entity)
        {
            _db.Add(entity);
            saveChanges();
            return entity;
        }
        public int Delete(Guid id)
        {
            var register = _db.TASK.Where(w => w.Id.Equals(id)).FirstOrDefault();

            if (register != null)
            { 
                _db.TASK.Remove(register);
                saveChanges();
                return 1;
            }
            else return 0;
            

        }

        public TASK Edit(TASK entity)
        {
            var register = _db.TASK.Where(w => w.Id.Equals(entity.Id)).FirstOrDefault();
            if (register != null)
            {
                register.Title = entity.Title;
                register.Description = entity.Description;
                register.Status = entity.Status;
                register.Date_Updated = DateTime.Now;

                _db.Entry(register).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                saveChanges();
            }
            return register;

        }

        public List<TASK> Get()
        {
            return _db.TASK.ToList();
        }

        public TASK GeTaskById(Guid TId)
        {
            return _db.TASK.Where(x => x.Id.Equals(TId)).FirstOrDefault();
        }

        public void saveChanges()
        {
            _db.SaveChanges();
        }
    }
}
