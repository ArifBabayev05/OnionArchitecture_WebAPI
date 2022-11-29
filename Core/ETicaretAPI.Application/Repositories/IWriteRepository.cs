using System;
using ETicaretAPI.Domain.Entities.Common;

namespace ETicaretAPI.Application.Repositories
{
	public interface IWriteRepository<T> : IRepository<T>
		where T : BaseEntity
    {

		//Bool döndürmə məcburi deyil, bitdikdən sonra geriyə True yada false qaytarması üçün yazıldı.
		Task<bool> AddAsync(T model);

		Task<bool> AddRangeAsync(List<T> datas);

        bool Remove(T model);

        Task<bool> RemoveAsync(string id);

        bool RemoveRange(List<T> datas);


        bool Update(T model);

        Task<int> SaveAsync();

    }
}

