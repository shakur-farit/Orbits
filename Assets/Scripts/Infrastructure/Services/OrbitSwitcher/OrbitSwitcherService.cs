using Infrastructure.Services.PersistentProgress;
using Infrastructure.Services.StaticData;
using UnityEngine;

namespace Infrastructure.Services.OrbitSwitcher
{
	public class OrbitSwitcherService
	{
		private readonly PersistentProgressService _progressService;

		private readonly float _smallOrbitRadius;
		private readonly float _middleOrbitRadius;
		private readonly float _bigOrbitRadius;

		public OrbitSwitcherService(PersistentProgressService progressService, StaticDataService staticData)
		{
			_progressService = progressService;

			_smallOrbitRadius = staticData.ForOrbits.SmallOrbitRadius;
			_middleOrbitRadius = staticData.ForOrbits.MiddleOrbitRadius;
			_bigOrbitRadius = staticData.ForOrbits.BigOrbitRadius;
		}

		public Vector2 SwitchOrbit()
		{
			float previousOrbitRadius = _progressService.Progress.OrbitData.PreviousOrbitRadius;
			float currentOrbitRadius = _progressService.Progress.OrbitData.CurrentOrbitRadius;
			Vector2 orbitRadiusToSwitch = Vector2.zero;

			if (currentOrbitRadius == _smallOrbitRadius)
			{
				_progressService.Progress.OrbitData.PreviousOrbitRadius = currentOrbitRadius;
				_progressService.Progress.OrbitData.CurrentOrbitRadius = _middleOrbitRadius;
				orbitRadiusToSwitch = new Vector2(_middleOrbitRadius, 0f);
			}
			else if (currentOrbitRadius == _middleOrbitRadius && previousOrbitRadius == _smallOrbitRadius)
			{
				_progressService.Progress.OrbitData.PreviousOrbitRadius = currentOrbitRadius;
				_progressService.Progress.OrbitData.CurrentOrbitRadius = _bigOrbitRadius;
				orbitRadiusToSwitch = new Vector2(_bigOrbitRadius, 0f);
			}
			else if (currentOrbitRadius == _middleOrbitRadius && previousOrbitRadius == _bigOrbitRadius)
			{
				_progressService.Progress.OrbitData.PreviousOrbitRadius = currentOrbitRadius;
				_progressService.Progress.OrbitData.CurrentOrbitRadius = _smallOrbitRadius;
				orbitRadiusToSwitch = new Vector2(_smallOrbitRadius, 0);
			}
			else if (currentOrbitRadius == _bigOrbitRadius)
			{
				_progressService.Progress.OrbitData.PreviousOrbitRadius = currentOrbitRadius;
				_progressService.Progress.OrbitData.CurrentOrbitRadius = _middleOrbitRadius;
				orbitRadiusToSwitch = new Vector2(_middleOrbitRadius, 0f);
			}

			return orbitRadiusToSwitch;
		}
	}
}