using Infrastructure.Services.Input;
using Infrastructure.Services.OrbitSwitcher;
using Infrastructure.Services.PersistentProgress;
using Infrastructure.Services.StaticData;
using UnityEngine;
using Zenject;

namespace Hero
{
	public class Hero : MonoBehaviour
	{
		private StaticDataService _staticData;
		private InputService _inputService;
		private PersistentProgressService _progressService;
		private OrbitSwitcherService _orbitSwitcher;

		[Inject]
		public void Constructor(StaticDataService staticData, InputService inputService,
			PersistentProgressService progressService, OrbitSwitcherService orbitSwitcher)
		{
			_staticData = staticData;
			_inputService = inputService;
			_progressService = progressService;
			_orbitSwitcher = orbitSwitcher;
		}

		private void OnEnable() => 
			_inputService.IsTaped += SwitchOrbit;

		private void OnDisable() => 
			_inputService.IsTaped -= SwitchOrbit;

		private void Start() => 
			SetOrbit();

		private void Update() => 
			_inputService.Tap();

		private void SetOrbit()
		{
			float orbitRadius = _staticData.ForOrbits.SmallOrbitRadius;
			_progressService.Progress.OrbitData.CurrentOrbitRadius = orbitRadius;
			transform.position = new Vector2(orbitRadius, 0f);
		}

		private void SwitchOrbit() => 
			transform.localPosition = _orbitSwitcher.SwitchOrbit();
	}
}