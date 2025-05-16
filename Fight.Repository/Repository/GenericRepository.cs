using Fight.Core.Entities;
using Flight.Core.IRepository;
using Flight.Core.ISpecifIcation;
using Flight.Repository.MyFlightDbContext;
using Flight.Repository.Specification;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flight.Repository.Repository
{
	public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
	{
		private readonly FlightDbContext _dbContext;

		public GenericRepository(FlightDbContext dbContext)
		{
			_dbContext = dbContext;
		}
		#region WithOut Specification

		public async Task<IEnumerable<T>> GetAllAsync()
		{
			return await _dbContext.Set<T>().ToListAsync();
		}

		public async Task<T> GetByIdAsync(int id)
		{
			return await _dbContext.Set<T>().FirstOrDefaultAsync(x => x.Id == id);
		}
		#endregion


		#region With Specification
		public async Task<IEnumerable<T>> GetAllWithSpecificationAsync(ISpecifications<T> spec)
		{
			return await ApplySpecification(spec).ToListAsync();
		}

		public async Task<T> GetByIdWithSpecificationAsync(ISpecifications<T> spec)
		{
			return await ApplySpecification(spec).FirstOrDefaultAsync();
		}

		private IQueryable<T> ApplySpecification(ISpecifications<T> spec)
		{
			return SpecificationEvalutor<T>.GetQuery(_dbContext.Set<T>(), spec);
		}

		public async Task<int> GetCountWithSpecAsync(ISpecifications<T> spec)
		{
			return await ApplySpecification(spec).CountAsync();
		}
		#endregion
	}



}
