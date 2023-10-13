using Moq;
using Task.Application.Services;
using Task.DataInfrastructure.Base;
using Task.DataInfrastructure.Context;
using Task.DataInfrastructure.Repository;
using Task.Domain.Entities;
using Task.Domain.Ports;

namespace Task.UnitTest.Presentation
{
    public class UnitTaskTestController
    {
        private readonly Mock<ITaskRepository> taskService;
        public UnitTaskTestController()
        {
            taskService = new Mock<ITaskRepository>();
            
        }

        private readonly TaskService _taskService;

        [Fact]
        public void GetTask()
        {
            //Arrange
            var taskData = GetTasks();
            taskService.Setup(x => x.Get())
                .Returns(taskData);

            //act
            var service = createService();
            var taskResult = service.Get();
            //assert
            Assert.NotNull(taskResult);
            Assert.NotEqual(GetTasks().Count(), taskResult.Count());
            Assert.Equal(GetTasks().ToString(), taskResult.ToString());
        }

        [Fact]
        public void SaveTaskTest()
        {
            //arrange
            var tasks = GetTasks();
            taskService.Setup(x => x.Add(tasks[2])).Returns(tasks[2]);

            //act
            var service = createService();
            var task = service.Add(tasks[2]);

            //assert
            Assert.NotNull(task);
            Assert.Equal(tasks[2].Title, task.Title);
            Assert.True(tasks[2].Title == task.Title);
        }

        [Fact]
        public void EditTaskTest()
        {
            //arrange
            var tasks = GetTasks();
            taskService.Setup(x => x.Edit(tasks[2])).Returns(tasks[2]);

            //act
            var service = createService();

            TASK tASKtask = service.Edit(tasks[2]);

            tASKtask.Description = "Modificado";

            var task = service.Edit(tASKtask);

            //assert
            Assert.NotNull(task);
            Assert.Equal(tasks[2].Title, task.Title);
            Assert.True(tasks[2].Title == task.Title);
        }

        [Fact]
        public void DeleteTaskTest()
        {
            //arrange
            var tasks = GetTasks();
            taskService.Setup(x => x.Delete(tasks[2].Id)).Returns(1);

            //act
            var service = createService();
            var taskId = service.Delete(tasks[2].Id);

            //assert
            Assert.NotNull(taskId);
            Assert.Equal(1, taskId);
            Assert.True(1== taskId);
        }


        [Theory]
        [InlineData("03E03C79-EF6B-4B6F-AC1A-58D2D6A415E5")]
         public void CheckIfTaskExist(Guid idTask)
        {
            ////arrange
            var tasks = GetTasks();
            taskService.Setup(x => x.GeTaskById(tasks[2].Id)).Returns(tasks[2]);

            //act
            var service = createService();
            var taskExpected = service.GeTaskById(tasks[2].Id);

            //act

            //assert
            Assert.NotNull(taskExpected);
            Assert.Equal(idTask, taskExpected.Id);
        }

        private List<TASK> GetTasks()
        {
            List<TASK> task = new List<TASK>
        {
            new TASK
            {
                Id = Guid.Parse("9C46B7AB-473B-408E-A620-35C9B126297A"),
                Title = "a",
                Description = "a",
                Developer = "a",
                Status = "Pendiente"
            },
             new TASK
            {
               Id = Guid.Parse("E7A87556-A7FC-4351-9A0C-865DA2297D31"),
                Title = "a",
                Description = "a",
                Developer = "n",
                Status = "Pendiente"
            },
             new TASK
            {
               Id = Guid.Parse("03E03C79-EF6B-4B6F-AC1A-58D2D6A415E5"),
                Title  = "a",
                Description = "a",
                Developer = "a",
                Status = "Pendiente"
            }
        };
            return task;
        }
    }
}

