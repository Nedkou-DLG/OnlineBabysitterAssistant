using System;
namespace OnlineBabysitterAssistant.Domain.Models.Child
{
	public class AssignBabysitterToChildModel
	{
        public int ChildId { get; set; }
        public int BabysitterId { get; set; }
    }
}

