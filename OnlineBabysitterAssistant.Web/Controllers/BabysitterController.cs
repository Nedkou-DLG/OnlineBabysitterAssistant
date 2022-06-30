using System;
using Microsoft.AspNetCore.Mvc;
using OnlineBabysitterAssistant.Domain.Entities;
using OnlineBabysitterAssistant.Domain.Models.Child;
using OnlineBabysitterAssistant.Domain.Models.User;
using OnlineBabysitterAssistant.Web.Application.Interfaces;
using OnlineBabysitterAssistant.Web.Appplication.Configurations.Helpers;

namespace OnlineBabysitterAssistant.Web.Controllers
{
	[ApiController]
	[Route("api/babysitter")]
	
	public class BabysitterController : AbstractController
	{
		private readonly IBabysitterService babysitterService;

		public BabysitterController(IBabysitterService babysitterService)
		{
			this.babysitterService = babysitterService;
		}

		[HttpPost("add-child-activity")]
		[Authorize(UserType.BABYSITTER)]
		[ProducesResponseType(typeof(ChildModel), StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		public async Task<IActionResult> AddChild([FromBody] CreateChildActivityModel model)
		{
			try
			{
				var response = await babysitterService.AddActivityToChild(model);

				return Ok(response);
			}
			catch (Exception ex)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
			}
		}

		[HttpGet("get-my-children")]
		[Authorize(UserType.BABYSITTER)]
		[ProducesResponseType(typeof(IEnumerable<ChildModel>), StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		public async Task<IActionResult> GetMyChildren()
		{
			try
			{
				var response = await babysitterService.GetMyChildren(CurrentUser.Id);

				return Ok(response);
			}
			catch (Exception ex)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
			}
		}

		[HttpGet("get-my-parents")]
		[Authorize(UserType.BABYSITTER)]
		[ProducesResponseType(typeof(IEnumerable<UserModel>), StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		public async Task<IActionResult> GetMyParents()
		{
			try
			{
				var response = await babysitterService.GetConnectedParents(CurrentUser.Id);

				return Ok(response);
			}
			catch (Exception ex)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
			}
		}

		[HttpGet("child-activities/{id}")]
		[Authorize(UserType.BABYSITTER, UserType.PARENT)]
		[ProducesResponseType(typeof(IEnumerable<ActivityModel>), StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		public async Task<IActionResult> ChildActivties(int id)
		{
			try
			{
				var response = await babysitterService.GetChildActivities(id);

				return Ok(response);
			}
			catch (Exception ex)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
			}
		}

		[HttpGet("get-all")]
		[Authorize(UserType.PARENT, UserType.BABYSITTER)]
		[ProducesResponseType(typeof(ChildModel), StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		public async Task<IActionResult> GetAllBabysitters()
		{
			try
			{
				var response = await babysitterService.GetAll(CurrentUser.Id);

				return Ok(response);
			}
			catch (Exception ex)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
			}
		}

		
	}
}

