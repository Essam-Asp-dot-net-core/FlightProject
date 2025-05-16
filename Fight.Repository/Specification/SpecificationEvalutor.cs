using Fight.Core.Entities;
using Flight.Core.ISpecifIcation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flight.Repository.Specification
{
	public static class SpecificationEvalutor<T> where T : BaseEntity
	{
		public static IQueryable<T> GetQuery(IQueryable<T> inputQuery, ISpecifications<T> spec)
		{
			var Query = inputQuery;

			if (spec.Criteria is not null)
			{
				Query = Query.Where(spec.Criteria);
			}
			
			if(spec.OrderBy is not null)
			{
				Query = Query.OrderBy(spec.OrderBy);
			}
			if(spec.OrderByDescending is not null)
			{
				Query = Query.OrderByDescending(spec.OrderByDescending);
			}
			if(spec.IsPaginationEnabled)
			{
				Query = Query.Skip(spec.Skip).Take(spec.Take);
			}

			Query = spec.InCludes.Aggregate(Query, (CurrentQuery, IncludeExpression) => CurrentQuery.Include(IncludeExpression));
			return Query;
		}
	}
}
