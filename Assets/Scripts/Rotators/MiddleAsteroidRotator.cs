namespace Rotators
{
	public class MiddleAsteroidRotator : Rotator
	{
		protected override void SetupAngleAndSpeed()
		{
			RotateAngle = StaticDataService.ForAsteroids.RotateAngle;
			RotateSpeed = StaticDataService.ForAsteroids.MiddleAsteroidRotateSpeed;
		}
	}
}