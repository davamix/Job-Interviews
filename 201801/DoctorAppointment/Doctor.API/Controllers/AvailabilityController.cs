using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Doctor.API.Models;
using Doctor.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace Doctor.API.Controllers
{
	[Produces("application/json")]
	[Route("api/availability")]
	public class AvailabilityController : Controller
	{
		private readonly IAvailabilityViewModelService _service;

		public AvailabilityController(IAvailabilityViewModelService service)
		{
			_service = service;
		}

		[HttpGet]
		public IActionResult Get()
		{
			return Ok();
		}

		[HttpGet("GetAvailability/{date:datetime}")]
		public async Task<IActionResult> Get(DateTime date)
		{
			var response = await _service.GetAvailability(date);
			return Ok(response);

		}

		// POST: api/Availbility
		[HttpPost("TakeSlot")]
		public IActionResult Post([FromBody] SlotRequest request)
		{
			_service.TakeSlot(request);
			return NoContent();
		}
	}
}
