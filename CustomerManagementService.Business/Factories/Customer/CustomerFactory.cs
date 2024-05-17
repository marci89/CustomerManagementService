using CustomerManagementService.ServiceContracts;
using CustomerManagementService.ServiceContracts.DTO;
using Entity = CustomerManagementService.Persistence.Entities;

namespace CustomerManagementService.Business.Factories
{
	/// <summary>
	/// Customer object mapping
	/// </summary>
	public class CustomerFactory
	{
		/// <summary>
		/// Map client Customer from domain Customer
		/// </summary>
		public Customer Create(Entity.Customer request)
		{
			if (request is null)
				return null;

			return new Customer
			{
				Id = request.Id,
				Identifier = request.Identifier,
				Category = Create(request.Category),
				FirstName = request.FirstName,
				LastName = request.LastName,
				ContactName = request.ContactName,
				PhoneNumber = request.PhoneNumber,
				Address = request.Address,
			};
		}

		/// <summary>
		/// Map domain Customer from client Customer (Create)
		/// </summary>
		public Entity.Customer Create(CreateCustomerRequest request)
		{
			if (request is null)
				return null;

			return new Entity.Customer
			{
				Id = request.Id,
				Identifier = request.Identifier,
				Category = Create(request.Category),
				FirstName = request.FirstName,
				LastName = request.LastName,
				ContactName = request.ContactName,
				PhoneNumber = request.PhoneNumber,
				Address = request.Address,
			};
		}

		/// <summary>
		/// Map domain Customer from client Customer (Update)
		/// </summary>
		public Entity.Customer Create(UpdateCustomerRequest request)
		{
			if (request is null)
				return null;

			return new Entity.Customer
			{
				Id = request.Id,
				Identifier = request.Identifier,
				Category = Create(request.Category),
				FirstName = request.FirstName,
				LastName = request.LastName,
				ContactName = request.ContactName,
				PhoneNumber = request.PhoneNumber,
				Address = request.Address,
			};
		}

		/// <summary>
		/// Map domain category from client category
		/// </summary>
		public Entity.CustomerCategory Create(CustomerCategory type)
		{
			switch (type)
			{
				case CustomerCategory.Residential:
					return Entity.CustomerCategory.Residential;
				case CustomerCategory.Corporate:
					return Entity.CustomerCategory.Corporate;
				default:
					throw new ArgumentException("Invalid Type.");
			}
		}

		/// <summary>
		/// Map client category from domain category
		/// </summary>
		public CustomerCategory Create(Entity.CustomerCategory type)
		{
			switch (type)
			{
				case Entity.CustomerCategory.Residential:
					return CustomerCategory.Residential;
				case Entity.CustomerCategory.Corporate:
					return CustomerCategory.Corporate;
				default:
					throw new ArgumentException("Invalid Type.");
			}
		}
	}
}
