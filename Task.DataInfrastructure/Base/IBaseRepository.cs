using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task.DataInfrastructure.Interfaces;

namespace Task.DataInfrastructure.Base
{
    public interface IBaseRepository<T, TId> : IAdd<T>, IEdit<T>, IDelete<Guid>, IListE<T, TId>, ITransaction
    {

    }
}
