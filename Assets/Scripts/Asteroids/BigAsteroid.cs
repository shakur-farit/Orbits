using UnityEngine;

namespace Asteroids
{
	public class BigAsteroid : Asteroid
	{
		protected override void SetOrbit()
		{
			float orbitRadius = StaticData.ForOrbits.BigOrbitRadius;
			transform.position = new Vector3(orbitRadius, 0f, 0f);
		}
	}
}