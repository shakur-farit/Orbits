namespace Rotators
{
	public class BigAsteroidRotator : AsteroidRotator
	{
		protected override void SetupAngleAndSpeed()
		{
			RotateAngle = _staticDataService.ForRotator.RotateAngle;
			RotateSpeed = _staticDataService.ForRotator.BigAsteroidRotateSpeed;
		}
	}
}