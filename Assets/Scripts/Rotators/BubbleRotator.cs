using Infrastructure.Services.AngleSwitcher;
using Infrastructure.Services.Input;
using Zenject;

namespace Rotators
{
	public class BubbleRotator : Rotator
	{
		private IInputService _inputService;

		[Inject]
		public void Constructor(IAngleSwitcherService angleSwitcherService, IInputService inputService)
		{
			AngleSwitcherService = angleSwitcherService;
			_inputService = inputService;
		}

		protected override void OnStart(){ }

		protected override void Update()
		{
			base.Update();

			_inputService.Tap();
		}
	}
}