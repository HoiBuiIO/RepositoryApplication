using Contracts;
using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.RepositoryWrapper
{
	public class RepositoryWrapper : IRepositoryWrapper
	{
		private IOwnerRepository ownerRepository;
		private IAccountRepository accountRepository;
		private RepositoryContext repositoryContext;

		public RepositoryWrapper(RepositoryContext repositoryContext)
		{
			this.repositoryContext = repositoryContext;
		}

		public IAccountRepository Account
		{
			get
			{
				if (accountRepository == null)
				{
					accountRepository = new AccountRepository(repositoryContext);
				}

				return accountRepository;
			}
		}

		public IOwnerRepository Owner
		{
			get
			{

				if (ownerRepository == null)
				{
					ownerRepository = new OwnerRepository(repositoryContext);
				}
				return ownerRepository;
			}
		}

		public void Save()
		{
			repositoryContext.SaveChanges();
		}
	}
}
