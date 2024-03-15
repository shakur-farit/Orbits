using UnityEngine;

namespace Asteroids
{
	public class SmallAsteroid : Asteroid
	{
		protected override void SetOrbit()
		{
			float orbitRadius = StaticData.ForOrbits.SmallOrbitRadius;
			transform.position = new Vector3(-orbitRadius, 0f, 0f);
		}
	}
}