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
		private IStaticDataService _staticData;
		private IInputService _inputService;
		private IPersistentProgressService _progressService;
		private IOrbitSwitcherService _orbitSwitcher;

		[Inject]
		public void Constructor(IStaticDataService staticData, IInputService inputService,
			IPersistentProgressService progressService, IOrbitSwitcherService orbitSwitcher)
		{
			_staticData = staticData;
			_inputService = inputService;
			_progressService = progressService;
			_orbitSwitcher = orbitSwitcher;
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
			float orbitRadius = _staticData.ForOrbits.MiddleOrbitRadius;
			_progressService.Progress.OrbitData.CurrentOrbitRadius = orbitRadius;
			transform.position = new Vector2(orbitRadius, 0f);
		}

		private void SwitchOrbit()
		{
			Debug.Log(_orbitSwitcher.SwitchOrbit());
			transform.localPosition = _orbitSwitcher.SwitchOrbit();
		}
	}
}