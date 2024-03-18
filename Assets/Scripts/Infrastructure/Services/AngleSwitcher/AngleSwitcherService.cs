using Infrastructure.Services.Randomizer;

namespace Infrastructure.Services.AngleSwitcher
{
	public class AngleSwitcherService : IAngleSwitcherService
	{
		public float SwitchAngle(float angle) => 
			-angle;
	}
}