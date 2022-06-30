using System;
using Microsoft.AspNetCore.Mvc;
using OnlineBabysitterAssistant.Domain.Entities;

namespace OnlineBabysitterAssistant.Web.Controllers
{
	public abstract class AbstractController : ControllerBase
	{
		protected UserRecord CurrentUser => ((Task<UserRecord>)HttpContext.Items["User"]).Result;
	}
}

