

using CustomerManagementService.ServiceContracts.DTO;

namespace CustomerManagementService.ServiceContracts
{
	/// <summary>
	/// Update customer response
	/// </summary>
	public class UpdateCustomerResponse : ResponseBase
	{
		public Customer Result { get; set; }
	}
}
