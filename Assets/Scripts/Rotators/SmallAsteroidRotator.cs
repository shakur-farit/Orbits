namespace Rotators
{
	public class SmallAsteroidRotator : AsteroidRotator
	{
		protected override void SetupAngleAndSpeed()
		{
			RotateAngle = _staticDataService.ForRotator.RotateAngle;
			RotateSpeed = _staticDataService.ForRotator.SmallAsteroidRotateSpeed;
		}
	}
}