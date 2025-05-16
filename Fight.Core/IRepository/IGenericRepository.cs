using Fight.Core.Entities;
using Flight.Core.ISpecifIcation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flight.Core.IRepository
{
	public interface IGenericRepository<T> where T : BaseEntity
	{
		#region WithOut Specification
		Task<IEnumerable<T>> GetAllAsync();
		Task<T> GetByIdAsync(int id);
		#endregion

		#region With Specification
		Task<IEnumerable<T>> GetAllWithSpecificationAsync(ISpecifications<T> spec);
		Task<T> GetByIdWithSpecificationAsync(ISpecifications<T> spec);
		Task<int> GetCountWithSpecAsync(ISpecifications<T> spec);

		#endregion
	}
}
