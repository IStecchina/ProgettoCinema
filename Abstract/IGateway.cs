using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProgettoCinema.Abstract
{
    public interface IGateway<T>
    {
        Task<List<T>> GetAll();
        Task<T?> GetById(int id);
        Task Create(T t);
        Task Update(T t);
        Task Delete(int id);
    }
}
