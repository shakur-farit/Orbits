using StaticEvents;

namespace Rotators
{
	public class HeroRotator : Rotator
	{
		private void Start() => 
			StaticEventsHandler.OnSpeedUpperPickedUp += IncreaseRotateSpeed;

		private void OnDestroy() => 
			StaticEventsHandler.OnSpeedUpperPickedUp -= IncreaseRotateSpeed;

		protected override void SetupAngleAndSpeed()
		{
			RotateAngle = StaticDataService.ForAsteroids.RotateAngle;
			RotateSpeed = StaticDataService.ForHero.HeroRotateSpeed;
		}

		private void IncreaseRotateSpeed() => 
			RotateSpeed += StaticDataService.ForSpeedUpper.IncreaseRotateSpeedValue;
	}
}