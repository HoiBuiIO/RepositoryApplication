using Contracts;
using Entities.Models;
using Moq;
using System;
using Xunit;

namespace RepositoryApplicationTests
{
	public class OwnerRepositoryTest
	{
		[Fact]
		public void Create_Owner_Calls_OwnerRepositoryCreateOwner()
		{
			var owner = new Owner
			{
				OwnerId = Guid.NewGuid(),
				DateOfBirth = DateTime.UtcNow,
				Name = "Hoi",
				Address = "Quang Tri"
			};

			var mockownerRepository = new Mock<IOwnerRepository>();
			mockownerRepository.Setup(o => o.CreateOwner(owner)); //no return as it's a void method
			mockownerRepository.Object.CreateOwner(owner);
			mockownerRepository.Verify(o => o.CreateOwner(owner), Times.Once()); //Assert that the Add method was called once

		}

		[Fact]
		public void Delete_Owner_Calls_OwnerRepositoryDelete()
		{
			var owner = new Owner
			{
				OwnerId = Guid.NewGuid(),
				DateOfBirth = DateTime.UtcNow,
				Name = "Hoi",
				Address = "Quang Tri"
			};

			var mockownerRepository = new Mock<IOwnerRepository>();
			mockownerRepository.Setup(o => o.DeleteOwner(owner)); //no return as it's a void method
			mockownerRepository.Object.DeleteOwner(owner);

			mockownerRepository.Setup(x => x.GetOwnerById(owner.OwnerId));
			var ownerAfterDelete = mockownerRepository.Object.GetOwnerById(owner.OwnerId); //Assert expected value to be null
			Assert.Null(ownerAfterDelete);

			mockownerRepository.Verify(o => o.DeleteOwner(owner), Times.Once()); //Assert that the Add method was called once
		}


		[Fact]
		public void Get_Owner_By_Id()
		{
			var owner = new Owner
			{
				OwnerId = Guid.NewGuid(),
				DateOfBirth = DateTime.UtcNow,
				Name = "Hoi",
				Address = "Quang Tri"
			};

			var mockpersonRepository = new Mock<IOwnerRepository>();

			mockpersonRepository.Setup(x => x.GetOwnerById(owner.OwnerId))
			.Returns(owner); //return Person
			var ownFound = mockpersonRepository.Object.GetOwnerById(owner.OwnerId); //Assert expected value equal to actual value

			Assert.NotNull(ownFound);
			mockpersonRepository.Verify(x => x.GetOwnerById(owner.OwnerId), Times.Once()); //Assert that the Get method was called once

		}
	}
}
