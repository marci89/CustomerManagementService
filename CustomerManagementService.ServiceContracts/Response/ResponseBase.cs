

namespace CustomerManagementService.ServiceContracts
{
	/// <summary>
	/// Response base class that helps send the correct objectto the client
	/// and send correct error messages if that has any
	/// </summary>
	public class ResponseBase
	{


		private string _errorMessage;

		/// <summary>
		/// Returning error message
		/// </summary>
		public virtual string ErrorMessage
		{
			get
			{
				return _errorMessage;
			}
			set
			{
				_errorMessage = value;
			}
		}

		/// <summary>
		/// Has error check
		/// </summary>
		public virtual bool HasError => !string.IsNullOrEmpty(ErrorMessage);
	}
}

