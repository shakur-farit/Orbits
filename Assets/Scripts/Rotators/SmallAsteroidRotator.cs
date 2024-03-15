namespace Rotators
{
	public class SmallAsteroidRotator : Rotator
	{
		protected override void SetupAngleAndSpeed()
		{
			RotateAngle = StaticDataService.ForAsteroids.RotateAngle;
			RotateSpeed = StaticDataService.ForAsteroids.SmallAsteroidRotateSpeed;
		}
	}
}