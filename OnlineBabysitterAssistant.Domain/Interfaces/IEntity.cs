using System;
namespace OnlineBabysitterAssistant.Domain.Interfaces
{
	public interface IEntity
	{
        int Id { get; set; }
        DateTime CreatedDate { get; set; }
    }
}

