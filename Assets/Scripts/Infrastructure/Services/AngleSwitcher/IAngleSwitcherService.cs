using Infrastructure.Services.Randomizer;

namespace Infrastructure.Services.AngleSwitcher
{
	public interface IAngleSwitcherService
	{
		float SwitchAngle(float angle,IRandomService randomService);

		float SwitchAngle(float angle);
	}
}