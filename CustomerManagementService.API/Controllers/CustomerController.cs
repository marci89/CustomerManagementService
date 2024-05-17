using CustomerManagementService.Business;
using CustomerManagementService.ServiceContracts;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;

namespace CustomerManagementService.API.Controllers
{
	[Description("Customer management")]
	public class CustomerController : Controller
	{
		private readonly ICustomerService _service;

		public CustomerController(ICustomerService service)
		{
			_service = service;
		}

		/// <summary>
		/// Get customer by id
		/// </summary>
		[HttpGet("{id}")]
		public async Task<IActionResult> GetById(long id)
		{
			var response = await _service.ReadById(id);
			if (response.HasError)
			{
				return NotFound(response.ErrorMessage);
			}

			return Ok(response.Result);
		}

		/// <summary>
		/// list customers
		/// </summary>
		[HttpGet("List")]
		public async Task<IActionResult> List()
		{
			var response = await _service.List();
			return Ok(response.Result);
		}

		/// <summary>
		/// Create customer
		/// </summary>
		[HttpPost("Create")]
		public async Task<IActionResult> Create([FromBody] CreateCustomerRequest request)
		{

			var response = await _service.Create(request);
			if (response.HasError)
			{
				return BadRequest(response);
			}
			return CreatedAtAction("Create", new { id = response.Result.Id }, response);
		}

		/// <summary>
		/// Update customer
		/// </summary>
		[HttpPut("Update")]
		public async Task<IActionResult> Update([FromBody] UpdateCustomerRequest request)
		{

			var response = await _service.Update(request);
			if (response.HasError)
			{
				return BadRequest(response);
			}
			return Ok(response);
		}



		/// <summary>
		/// Delete customer
		/// </summary>
		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete(long id)
		{
			var response = await _service.Delete(id);
			if (response.HasError)
			{
				return BadRequest(response);
			}
			return NoContent();
		}

	}
}