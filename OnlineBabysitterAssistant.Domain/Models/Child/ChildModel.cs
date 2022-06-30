using System;
using OnlineBabysitterAssistant.Domain.Models.User;

namespace OnlineBabysitterAssistant.Domain.Models.Child
{
	public class ChildModel
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Gender { get; set; }
		public UserModel Parent { get; set; }
		public UserModel Babysitter { get; set; }
		
	}
}

