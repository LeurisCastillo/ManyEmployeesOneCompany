using System.Collections.Generic;

namespace WebApiDemo.Services.Interfaces
{
    public interface ICrud<T> where T : class, new()
    {
        List<T> GetAll();
        T Get(int id);
        void Create(T entity);
        void Delete(int id);
        T Update(T entity);
    }
}
