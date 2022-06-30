using System;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OnlineBabysitterAssistant.Domain.Entities;
using OnlineBabysitterAssistant.Domain.Models.Child;
using OnlineBabysitterAssistant.Domain.Models.User;
using OnlineBabysitterAssistant.Web.Application.Interfaces;
using OnlineBabysitterAssistant.Web.Appplication.Configurations.Helpers;

namespace OnlineBabysitterAssistant.Web.Controllers
{
	[ApiController]
	[Route("api/parent")]
	
	public class ParentController : AbstractController
	{
		private readonly IParentService _parentService;
		private readonly IMapper _mapper;

		public ParentController(IParentService parentService, IMapper mapper)
		{
			_parentService = parentService;
			_mapper = mapper;
		}

		[HttpPost("add-child")]
		[Authorize(UserType.PARENT)]
		[ProducesResponseType(typeof(ChildModel), StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		public async Task<IActionResult> AddChild(CreateChildModel model)
		{
			try
			{
				var response = await _parentService.AddChild(CurrentUser.Id, model);

				return Ok(response);
			}
			catch(Exception ex)
            {
				return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
		}

		[HttpGet("children")]
		[Authorize(UserType.PARENT)]
		[ProducesResponseType(typeof(IEnumerable<ChildModel>), StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		public async Task<IActionResult> GetChildren()
        {
            try
            {
				var response = await _parentService.GetChildren(CurrentUser.Id);

				return Ok(response);
            }
			catch (Exception ex)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
			}
		}

		[HttpGet("children/{id}")]
		[Authorize(UserType.PARENT)]
		[ProducesResponseType(typeof(ChildModel), StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		public async Task<IActionResult> GetChild(int childId)
		{
			try
			{
				var response = await _parentService.GetChild(CurrentUser.Id, childId);

				if (response == null)
                {
					return StatusCode(StatusCodes.Status400BadRequest, "The child is not yours or it's not existing!");
                }

				return Ok(response);
			}
			catch (Exception ex)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
			}
		}

		[HttpGet("babysitters")]
		[Authorize(UserType.PARENT)]
		[ProducesResponseType(typeof(ChildModel), StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		public async Task<IActionResult> GetBabysitters()
		{
			try
			{
				var response = await _parentService.GetBabysitters(CurrentUser.Id);

				return Ok(response);
			}
			catch (Exception ex)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
			}
		}

		[HttpGet("get-all")]
		[Authorize(UserType.PARENT, UserType.BABYSITTER)]
		[ProducesResponseType(typeof(IEnumerable<UserModel>), StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		public async Task<IActionResult> GetAllParents()
		{
			try
			{
				var response = await _parentService.GetAll();

				return Ok(response);
			}
			catch (Exception ex)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
			}
		}

		[HttpPost("connect-babysitter")]
		[Authorize(UserType.PARENT)]
		[ProducesResponseType(typeof(IEnumerable<UserModel>), StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		public async Task<IActionResult> ConnectToBabysitter([FromBody]int id)
        {
            try
            {
				var response = await _parentService.ConnectBabysitter(CurrentUser.Id, id);

				return Ok(response);
			}
			catch(Exception ex)
            {
				return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
			}
			
        }

		[HttpGet("all-babysitters")]
		[Authorize(UserType.PARENT)]
		[ProducesResponseType(typeof(IEnumerable<BabysitterModel>), StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		public async Task<IActionResult> GetAllBabysitters()
		{
			try
			{
				var response = await _parentService.GetAllBabysitters(CurrentUser.Id);

				return Ok(response);
			}
			catch (Exception ex)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
			}

		}

		[HttpDelete("disconnect-babysitter")]
		[Authorize(UserType.PARENT)]
		[ProducesResponseType(typeof(ChildModel), StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		public async Task<IActionResult> DisconnectBabysitters([FromBody] int id)
		{
			try
			{
				var response = await _parentService.DisconnectBabysitter(CurrentUser.Id, id);

				return Ok(response);
			}
			catch (Exception ex)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
			}
		}


		[HttpPost("assign-babysitter-to-child")]
		[Authorize(UserType.PARENT)]
		[ProducesResponseType(typeof(ChildModel), StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		public async Task<IActionResult> AssignBabysitterToChild([FromBody] AssignBabysitterToChildModel model)
		{
			try
			{
				var response = await _parentService.AssignBabysitterToChild(model);

				return Ok(response);
			}
			catch (Exception ex)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
			}
		}


		[HttpPost("unassign-babysitter-from-child")]
		[Authorize(UserType.PARENT)]
		[ProducesResponseType(typeof(ChildModel), StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		public async Task<IActionResult> AssignBabysitterToChild([FromBody] int childId)
		{
			try
			{
				var response = await _parentService.UnassignBabysitterFromChild(childId);

				return Ok(response);
			}
			catch (Exception ex)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
			}
		}

	}
}

