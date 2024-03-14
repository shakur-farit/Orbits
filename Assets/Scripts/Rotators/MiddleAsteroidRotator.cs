namespace Rotators
{
	public class MiddleAsteroidRotator : AsteroidRotator
	{
		protected override void SetupAngleAndSpeed()
		{
			RotateAngle = StaticDataService.ForRotator.RotateAngle;
			RotateSpeed = StaticDataService.ForRotator.MiddleAsteroidRotateSpeed;
		}
	}
}