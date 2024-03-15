namespace Rotators
{
	public class BigAsteroidRotator : Rotator
	{
		protected override void SetupAngleAndSpeed()
		{
			RotateAngle = StaticDataService.ForAsteroids.RotateAngle;
			RotateSpeed = StaticDataService.ForAsteroids.BigAsteroidRotateSpeed;
		}
	}
}