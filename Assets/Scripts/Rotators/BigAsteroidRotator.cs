namespace Rotators
{
	public class BigAsteroidRotator : AsteroidRotator
	{
		protected override void SetupAngleAndSpeed()
		{
			RotateAngle = StaticDataService.ForRotator.RotateAngle;
			RotateSpeed = StaticDataService.ForRotator.BigAsteroidRotateSpeed;
		}
	}
}