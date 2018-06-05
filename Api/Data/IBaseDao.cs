using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Data
{
    public interface IBaseDao<T> where T: class 
    {
        List<T> GetAll();

        T GetById(int id);

        void Update(T entity);

        void Insert(T entity);

        void Delete(int id);

    }
}
