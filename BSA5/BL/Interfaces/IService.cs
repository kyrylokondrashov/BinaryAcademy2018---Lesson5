using System;
using System.Collections.Generic;
namespace BL.Interfaces
{
    public interface IService<T> where T: class
    {
        void Create(T item);
        T GetById(int id);
        List<T> GetAll();
        void Update(int id, T item);
        void Delete(int id);
        void DeleteAll();
    }
}
