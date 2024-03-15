using System;
using Infrastructure.Services.Input;
using Infrastructure.Services.PersistentProgress;
using Infrastructure.Services.StaticData;
using UnityEngine;
using Zenject;

namespace Hero
{
	public class Hero : MonoBehaviour
	{
		private IStaticDataService _staticData;
		private IInputService _inputService;
		private IPersistentProgressService _progressService;

		[Inject]
		public void Constructor(IStaticDataService staticData, IInputService inputService,
			IPersistentProgressService progressService)
		{
			_staticData = staticData;
			_inputService = inputService;
			_progressService = progressService;
		}

		private void Start()
		{
			_inputService.IsTaped += SwitchOrbit;

			SetOrbit();
		}

		private void OnDestroy() => 
			_inputService.IsTaped -= SwitchOrbit;

		private void Update() => 
			_inputService.Tap();

		private void SetOrbit()
		{
			float orbitRadius = _staticData.ForOrbits.SmallOrbitRadius;
			_progressService.Progress.OrbitData.OrbitRadius = orbitRadius;
			transform.position = new Vector3(orbitRadius, 0f, 0f);
		}

		private void SwitchOrbit()
		{
			float previousOrbitRadius;
			float currentOrbitRadius = _progressService.Progress.OrbitData.OrbitRadius;

			if (currentOrbitRadius == _staticData.ForOrbits.SmallOrbitRadius)
			{
				currentOrbitRadius = _staticData.ForOrbits.MiddleOrbitRadius;
				transform.position = new Vector3(currentOrbitRadius, 0f, 0f);
			}
		}
	}
}