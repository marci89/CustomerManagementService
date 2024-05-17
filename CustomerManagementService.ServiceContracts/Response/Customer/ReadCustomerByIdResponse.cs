

using CustomerManagementService.ServiceContracts.DTO;

namespace CustomerManagementService.ServiceContracts
{
	/// <summary>
	/// Read by id customer response
	/// </summary>
	public class ReadCustomerByIdResponse : ResponseBase
	{
		public Customer Result { get; set; }
	}
}
