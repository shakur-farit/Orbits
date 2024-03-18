using Infrastructure.Services.AngleSwitcher;
using StaticEvents;
using Zenject;

namespace Rotators
{
	public class HeroRotator : Rotator
	{
		private IAngleSwitcherService _angleSwitcher;

		[Inject]
		public void Constructor(IAngleSwitcherService angleSwitcher) => 
			_angleSwitcher = angleSwitcher;

		private void Start()
		{
			StaticEventsHandler.OnSpeedUpperPickedUp += IncreaseRotateSpeed;
			StaticEventsHandler.OnAngleSwitcherPickedUp += SwitchAngle;
		}

		private void OnDestroy()
		{
			StaticEventsHandler.OnSpeedUpperPickedUp -= IncreaseRotateSpeed;
			StaticEventsHandler.OnAngleSwitcherPickedUp -= SwitchAngle;
		}

		protected override void SetupAngleAndSpeed()
		{
			RotateAngle = StaticDataService.ForAsteroids.RotateAngle;
			RotateSpeed = StaticDataService.ForHero.HeroRotateSpeed;
		}

		private void IncreaseRotateSpeed() => 
			RotateSpeed += StaticDataService.ForSpeedUpper.IncreaseRotateSpeedValue;

		private void SwitchAngle() => 
			RotateAngle = _angleSwitcher.SwitchAngle(RotateAngle);
	}
}