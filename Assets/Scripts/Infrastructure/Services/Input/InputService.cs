using System;
using UnityEngine;

namespace Infrastructure.Services.Input
{
	public class InputService : IInputService
	{
		public event Action IsTaped;

		public void Tap()
		{
			if (UnityEngine.Input.touchCount > 0)
			{
				Touch touch = UnityEngine.Input.GetTouch(0);

				if(touch.phase == TouchPhase.Began)
					IsTaped?.Invoke();
			}
		}
	}
}