using StaticEvents;
using UnityEngine;

namespace Rotators
{
	public class HeroRotator : Rotator
	{
		private void Start()
		{

			StaticEventsHandler.OnPickedUpDebuff += IncreaseRotateSpeed;
		}

		private void OnDestroy() => 
			StaticEventsHandler.OnPickedUpDebuff -= IncreaseRotateSpeed;

		protected override void SetupAngleAndSpeed()
		{
			RotateAngle = StaticDataService.ForAsteroids.RotateAngle;
			RotateSpeed = StaticDataService.ForHero.HeroRotateSpeed;
		}

		private void IncreaseRotateSpeed()
		{
			RotateSpeed += StaticDataService.ForDebuff.IncreaseRotateSpeedValue;
			Debug.Log(RotateSpeed);
		}
	}
}