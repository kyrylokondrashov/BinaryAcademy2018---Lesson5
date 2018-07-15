using System;
using System.Collections.Generic;
namespace DAL_EF.Interfaces
{
    public interface IRepository<T> where T : class
    {
        List<T> GetAll();

        T GetById(int id);

        void Create(T item);

        void Update(int id, T item);

        void Delete(int id);

        void DeleteAll();
    }
}
