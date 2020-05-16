﻿using Contracts;
using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace Repository
{
	public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
	{
		protected RepositoryBase(RepositoryContext repositoryContext)
		{
			RepositoryContext = repositoryContext;
		}

		protected RepositoryContext RepositoryContext { get; set; }
		public void Create(T entity)
		{
			this.RepositoryContext.Set<T>().Add(entity);
		}

		public void Delete(T entity)
		{
			this.RepositoryContext.Set<T>().Remove(entity);
		}

		public IQueryable<T> FindAll()
		{
			return this.RepositoryContext.Set<T>().AsNoTracking();
		}

		public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
		{
			return this.RepositoryContext.Set<T>().Where(expression).AsNoTracking();
		}

		public void Update(T entity)
		{
			this.RepositoryContext.Set<T>().Update(entity);
		}
	}
}
