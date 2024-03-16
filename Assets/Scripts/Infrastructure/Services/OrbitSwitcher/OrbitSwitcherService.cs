using Infrastructure.Services.PersistentProgress;
using Infrastructure.Services.StaticData;
using UnityEngine;

namespace Infrastructure.Services.OrbitSwitcher
{
	public class OrbitSwitcherService : IOrbitSwitcherService
	{
		private readonly IPersistentProgressService _progressService;
		private readonly IStaticDataService _staticData;

		private readonly float SmallOrbitRadius;
		private readonly float MiddleOrbitRadius;
		private readonly float BigOrbitRadius;

		public OrbitSwitcherService(IPersistentProgressService progressService, IStaticDataService staticData)
		{
			_progressService = progressService;
			_staticData = staticData;

			SmallOrbitRadius = _staticData.ForOrbits.SmallOrbitRadius;
			MiddleOrbitRadius = _staticData.ForOrbits.MiddleOrbitRadius;
			BigOrbitRadius = _staticData.ForOrbits.BigOrbitRadius;
		}

		public Vector2 SwitchOrbit()
		{
			float previousOrbitRadius = _progressService.Progress.OrbitData.PreviousOrbitRadius;
			float currentOrbitRadius = _progressService.Progress.OrbitData.CurrentOrbitRadius;
			Vector2 orbitRadiusToSwitch = Vector2.zero;

			if (currentOrbitRadius == SmallOrbitRadius)
			{
				_progressService.Progress.OrbitData.PreviousOrbitRadius = currentOrbitRadius;
				_progressService.Progress.OrbitData.CurrentOrbitRadius = MiddleOrbitRadius;
				orbitRadiusToSwitch = new Vector2(MiddleOrbitRadius, 0f);
			}
			else if (currentOrbitRadius == MiddleOrbitRadius && previousOrbitRadius == SmallOrbitRadius)
			{
				_progressService.Progress.OrbitData.PreviousOrbitRadius = currentOrbitRadius;
				_progressService.Progress.OrbitData.CurrentOrbitRadius = BigOrbitRadius;
				orbitRadiusToSwitch = new Vector2(BigOrbitRadius, 0f);
			}
			else if (currentOrbitRadius == MiddleOrbitRadius && previousOrbitRadius == BigOrbitRadius)
			{
				_progressService.Progress.OrbitData.PreviousOrbitRadius = currentOrbitRadius;
				_progressService.Progress.OrbitData.CurrentOrbitRadius = SmallOrbitRadius;
				orbitRadiusToSwitch = new Vector2(SmallOrbitRadius, 0);
			}
			else if (currentOrbitRadius == BigOrbitRadius)
			{
				_progressService.Progress.OrbitData.PreviousOrbitRadius = currentOrbitRadius;
				_progressService.Progress.OrbitData.CurrentOrbitRadius = MiddleOrbitRadius;
				orbitRadiusToSwitch = new Vector2(MiddleOrbitRadius, 0f);
			}

			return orbitRadiusToSwitch;
		}
	}
}