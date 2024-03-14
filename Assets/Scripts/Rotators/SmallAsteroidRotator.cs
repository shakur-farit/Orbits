namespace Rotators
{
	public class SmallAsteroidRotator : AsteroidRotator
	{
		protected override void SetupAngleAndSpeed()
		{
			RotateAngle = StaticDataService.ForRotator.RotateAngle;
			RotateSpeed = StaticDataService.ForRotator.SmallAsteroidRotateSpeed;
		}
	}
}