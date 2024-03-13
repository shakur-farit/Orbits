using Infrastructure.Services.AngleSwitcher;
using Infrastructure.Services.Randomizer;
using StaticEvents;
using Zenject;

namespace Rotators
{
	public class NeedleRotator : Rotator
	{
		private IRandomService _randomService;

		[Inject]
		protected void Constructor(IRandomService randomService, 
			IAngleSwitcherService angleSwitcherService)
		{
			_randomService = randomService;
			AngleSwitcherService = angleSwitcherService;
		}

		protected override void OnStart()
		{
			StaticEventsHandler.OnPlayerDied += StopRotate;
		}

		public override void OnOnDestroy()
		{
			base.OnOnDestroy();

			StaticEventsHandler.OnPlayerDied -= StopRotate;
		}
	}
}