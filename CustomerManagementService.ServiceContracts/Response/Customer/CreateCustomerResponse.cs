
using CustomerManagementService.ServiceContracts.DTO;

namespace CustomerManagementService.ServiceContracts
{

	/// <summary>
	/// Create customer response
	/// </summary>
	public class CreateCustomerResponse : ResponseBase
	{
		public Customer Result { get; set; }
	}
}