using Infrastructure.Services.StaticData;
using UnityEngine;
using Zenject;

namespace Asteroids
{
	public abstract class Asteroid : MonoBehaviour
	{
		protected StaticDataService StaticData;

		[Inject]
		public void Constructor(StaticDataService staticData) => 
			StaticData = staticData;

		private void Start() => 
			SetOrbit();

		protected abstract void SetOrbit();
	}
}
