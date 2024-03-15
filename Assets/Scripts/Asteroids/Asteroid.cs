using Infrastructure.Services.StaticData;
using UnityEngine;
using Zenject;

namespace Asteroids
{
	public abstract class Asteroid : MonoBehaviour
	{
		protected IStaticDataService StaticData;

		[Inject]
		public void Constructor(IStaticDataService staticData) => 
			StaticData = staticData;

		private void Start() => 
			SetOrbit();

		protected abstract void SetOrbit();
	}
}
