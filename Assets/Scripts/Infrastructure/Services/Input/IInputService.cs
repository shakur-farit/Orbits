using System;

namespace Infrastructure.Services.Input
{
	public interface IInputService
	{
		event Action IsTaped;

		void Tap();
	}
}