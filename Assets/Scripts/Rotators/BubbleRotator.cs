using Infrastructure.Services.Input;
using Infrastructure.Services.StaticData;
using Zenject;

namespace Rotators
{
	public class BubbleRotator : Rotator
	{
		private IInputService _inputService;

		[Inject]
		public void Constructor(IInputService inputService,
			IStaticDataService staticData)
		{
			StaticDataService = staticData;
			_inputService = inputService;
		}

		protected override void Update()
		{
			base.Update();

			_inputService.Tap();
		}

		protected override void StartRotate() => 
			SetupAngleAndSpeed();

		private void SetupAngleAndSpeed()
		{
			RotateAngle = StaticDataService.ForRotator.RotateAngle;
			RotateSpeed = StaticDataService.ForRotator.HeroRotateSpeed;
		}
	}
}