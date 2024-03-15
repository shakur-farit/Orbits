namespace Rotators
{
	public class HeroRotator : Rotator
	{
		protected override void SetupAngleAndSpeed()
		{
			RotateAngle = StaticDataService.ForAsteroids.RotateAngle;
			RotateSpeed = StaticDataService.ForHero.HeroRotateSpeed;
		}
	}
}