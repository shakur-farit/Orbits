namespace Rotators
{
	public class MiddleAsteroidRotator : AsteroidRotator
	{
		protected override void SetupAngleAndSpeed()
		{
			RotateAngle = _staticDataService.ForRotator.RotateAngle;
			RotateSpeed = _staticDataService.ForRotator.MiddleAsteroidRotateSpeed;
		}
	}
}