

namespace CustomerManagementService.ServiceContracts.DTO
{
	public class Customer
	{
		/// <summary>
		/// Id
		/// </summary>
		public long Id { get;  set; }

		/// <summary>
		/// It could be Identity card number or Tax number
		/// </summary>
		public string Identifier { get;  set; }

		/// <summary>
		/// Category type
		/// </summary>
		public CustomerCategory Category { get; set; }

		/// <summary>
		/// Last name
		/// </summary>
		public string LastName { get; set; }

		/// <summary>
		/// First name
		/// </summary>
		public string FirstName { get; set; }

		/// <summary>
		/// Contact name
		/// </summary>
		public string ContactName { get; set; }

		/// <summary>
		/// Phone number
		/// </summary>
		public string PhoneNumber { get; set; }

		/// <summary>
		/// Addres
		/// </summary>
		public string Address { get; set; }
	}
}
