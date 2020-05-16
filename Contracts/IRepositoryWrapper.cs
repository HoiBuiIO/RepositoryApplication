using System;
using System.Collections.Generic;
using System.Text;

namespace Contracts
{
	public interface IRepositoryWrapper
	{
		IAccountRepository Account { get; }
		IOwnerRepository Owner { get; }

		void Save();
	}
}
