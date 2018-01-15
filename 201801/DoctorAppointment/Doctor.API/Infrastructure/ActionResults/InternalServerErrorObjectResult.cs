using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Doctor.API.Infrastructure.ActionResults
{
	public class InternalServerErrorObjectResult : ObjectResult
	{
		public InternalServerErrorObjectResult(object value) : base(value)
		{
			StatusCode = StatusCodes.Status500InternalServerError;
		}
	}
}
