using CustomerManagementService.ServiceContracts.DTO;


namespace CustomerManagementService.ServiceContracts
{

	/// <summary>
	/// List customers response 
	/// </summary>
	public class ListCustomerResponse : ResponseBase
	{
		public List<Customer> Result { get; set; }
	}
}