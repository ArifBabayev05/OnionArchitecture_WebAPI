using System;
using System.Linq.Expressions;
using ETicaretAPI.Domain.Entities.Common;

namespace ETicaretAPI.Application.Repositories
{
	public interface IReadRepository<T> : IRepository<T>
		where T : BaseEntity
    {

        //Tracking nedir?
        //Tracking nedir? --> Database üzerinde yapılan işlemlerin EF tarafından haberdar olması için Tracking sistemi
        // vardır. Lakin biz Get Methodu ile datalarda bi değişiklik yapmayıp, onları sadece sunuma hazırladığımızda
        // tracking'e ihtiyacımız kalmaz. Ekstra maliyet oluşmaması için AsNoTracking kullanılır.

        IQueryable<T> GetAll(bool tracking = true);

		IQueryable<T> GetWhere(Expression<Func<T, bool>> method, bool tracking = true);

		Task<T> GetSingleAsync(Expression<Func<T, bool>> method, bool tracking = true);

        Task<T> GetByIdAsync(string id, bool tracking = true);
	}
}

