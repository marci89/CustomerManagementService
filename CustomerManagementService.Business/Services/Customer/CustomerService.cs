using CustomerManagementService.Business.Factories;
using CustomerManagementService.Persistence;
using CustomerManagementService.ServiceContracts;
using CustomerManagementService.ServiceContracts.DTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagementService.Business
{
	/// <summary>
	/// Customer service
	/// </summary>
	public class CustomerService : ICustomerService
	{
		private readonly DataContext _dbContext;
		private readonly CustomerFactory _factory;

		public CustomerService(DataContext dbContext, CustomerFactory factory)
		{
			_dbContext = dbContext;
			_factory = factory;
		}

		/// <summary>
		/// Read by ID
		/// </summary>
		/// <param name="id"></param>
		public async Task<ReadCustomerByIdResponse> ReadById(long id)
		{
			var entity = await _dbContext.Customers.FindAsync(id);
			var result = _factory.Create(entity);

			if (result is null)
			{
				return await Task.FromResult(new ReadCustomerByIdResponse
				{
					ErrorMessage = "Customer not found"
				});
			}

			return await Task.FromResult(new ReadCustomerByIdResponse
			{
				Result = result
			});
		}

		/// <summary>
		/// List customers
		/// </summary>
		public async Task<ListCustomerResponse> List()
		{
			var result = await _dbContext.Customers.Select(x => _factory.Create(x)).ToListAsync();

			return await Task.FromResult(new ListCustomerResponse
			{
				Result = result
			});
		}

		/// <summary>
		/// Create customer
		/// </summary>
		public async Task<CreateCustomerResponse> Create(CreateCustomerRequest request)
		{
			try
			{

                if (_dbContext.Customers.Count(x => x.Identifier == request.Identifier) > 0)
				{
					return await Task.FromResult(new CreateCustomerResponse
					{
						ErrorMessage = "Identifier has already exists",
						Result = new Customer()


					});
                }

                    var entity = _factory.Create(request);

				_dbContext.Customers.Add(entity);
				await _dbContext.SaveChangesAsync();

				return await Task.FromResult(new CreateCustomerResponse
				{
					Result = _factory.Create(entity)
				});
			}
			catch (Exception ex)
			{
				return await Task.FromResult(new CreateCustomerResponse
				{
					ErrorMessage = ex.Message,
                    Result = new Customer()
                });
			}
		}

		/// <summary>
		/// Update customer
		/// </summary>
		public async Task<UpdateCustomerResponse> Update(UpdateCustomerRequest request)
		{

			try
			{
				var entity = await _dbContext.Customers.FindAsync(request.Id);
				if (entity is null)
				{
					return await Task.FromResult(new UpdateCustomerResponse
					{
						ErrorMessage = "Customer not found"
					});
				}

                if (_dbContext.Customers.Count(x => x.Identifier == request.Identifier && x.Id != request.Id) > 0)
                {
                    return await Task.FromResult(new UpdateCustomerResponse
                    {
                        ErrorMessage = "Identifier has already exists"
                    });
                }


                entity.Identifier = request.Identifier;
				entity.Category = _factory.Create(request.Category);
				entity.FirstName = request.FirstName;
				entity.LastName = request.LastName;
				entity.ContactName = request.ContactName;
				entity.PhoneNumber = request.PhoneNumber;
				entity.Address = request.Address;

				await _dbContext.SaveChangesAsync();

				return await Task.FromResult(new UpdateCustomerResponse
				{
					Result = _factory.Create(entity)
				}); ;

			}
			catch (Exception ex)
			{
				return await Task.FromResult(new UpdateCustomerResponse
				{
					ErrorMessage = ex.Message
				});
			}

		}

		/// <summary>
		/// Delete customer
		/// </summary>
		public async Task<ResponseBase> Delete(long id)
		{
			var entity = await _dbContext.Customers.FindAsync(id);
			if (entity == null)
			{
				return await Task.FromResult(new ResponseBase
				{
					ErrorMessage = "Customer not found"
				});
			}

			try
			{
				_dbContext.Customers.Remove(entity);
				await _dbContext.SaveChangesAsync();

				return await Task.FromResult(new ResponseBase{});
			}
			catch (Exception ex)
			{
				return await Task.FromResult(new ResponseBase
				{
					ErrorMessage = ex.Message
				});
			}
		}
	}
}