using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task.DataInfrastructure.Interfaces
{
    public interface IListE<T, Tid>
    {
        List<T> Get();

        //T GeTaskById(int TId); Ciro
        T GeTaskById(Guid TId);
    }
}
