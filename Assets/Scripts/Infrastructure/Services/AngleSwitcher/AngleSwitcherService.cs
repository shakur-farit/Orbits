using Infrastructure.Services.Randomizer;

namespace Infrastructure.Services.AngleSwitcher
{
	public class AngleSwitcherService
	{
		public float SwitchAngle(float angle, RandomService randomService)
		{
			return -angle;
		}

		public float SwitchAngle(float angle) => 
			-angle;
	}
}