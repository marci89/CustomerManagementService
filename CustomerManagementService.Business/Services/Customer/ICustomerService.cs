using CustomerManagementService.ServiceContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagementService.Business
{
	public interface ICustomerService
	{
		Task<ReadCustomerByIdResponse> ReadById(long id);
		Task<ListCustomerResponse> List();
		Task<CreateCustomerResponse> Create(CreateCustomerRequest request);
		Task<UpdateCustomerResponse> Update(UpdateCustomerRequest request);
		Task<ResponseBase> Delete(long id);
	}
}
