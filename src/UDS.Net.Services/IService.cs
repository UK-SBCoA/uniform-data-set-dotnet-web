using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace UDS.Net.Services
{
    public interface IService<T>
    {
        Task<T> GetById(string username, int id);
        Task<T> Add(string username, T entity);
        Task Remove(string username, T entity);
        Task<T> Update(string username, T entity);
        Task<T> Patch(string username, T entity);
        Task<int> Count(string username);
        Task<IEnumerable<T>> List(string username, int pageSize = 10, int pageIndex = 1);
    }
}

