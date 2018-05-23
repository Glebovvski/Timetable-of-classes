using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schedule_CodeFirstModel.Repositories
{
    interface IRepository<T>
    {
        void Create(T data);
        List<T> Read();
        T Read(int id);
        void Update(T data);
        void Delete(int id);
    }
}
