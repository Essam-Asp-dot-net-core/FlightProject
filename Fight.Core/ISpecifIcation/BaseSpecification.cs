﻿using Fight.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Flight.Core.ISpecifIcation
{
	public class BaseSpecification<T> : ISpecifications<T> where T : BaseEntity
	{
		public Expression<Func<T, bool>> Criteria { get; set; }
		public List<Expression<Func<T, object>>> InCludes { get; set; } = new List<Expression<Func<T, object>>>();

		public Expression<Func<T, object>> OrderBy { get; set; }
		public Expression<Func<T, object>> OrderByDescending { get; set; }
		public int Take { get ; set ; }
		public int Skip { get ; set ; }
		public bool IsPaginationEnabled { get; set; }

		public BaseSpecification()
		{
			
		}
		public BaseSpecification(Expression<Func<T, bool>> criteriaExprssion)
		{
			Criteria = criteriaExprssion;
		}

		public void AddOrderBy(Expression<Func<T, object>> orderByExpression)
		{
			OrderBy = orderByExpression;
		}

		public void AddOrderByDescending(Expression<Func<T, object>> orderByDescExpression)
		{
			OrderByDescending = orderByDescExpression;
		}

		public void ApplyPagination(int skip, int take)
		{
			IsPaginationEnabled = true;
			Take = take;
			Skip = skip;
		}

	}
	
}
