using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example.Application.ExampleService.Service
{
    public interface IGenericService<T> where T : class
    {

        Task<T> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task<T> CreateAsync(T request);
        Task<T> UpdateAsync(int id, T request);
        Task<T> DeleteAsync(int id);
    }
}
