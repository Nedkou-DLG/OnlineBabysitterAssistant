using System;
namespace OnlineBabysitterAssistant.Domain.Models.Child
{
	public class CreateChildActivityModel
	{
		public int ChildId { get; set; }
		public DateTime? Time { get; set; }
		public string Description { get; set; }
	}
}

