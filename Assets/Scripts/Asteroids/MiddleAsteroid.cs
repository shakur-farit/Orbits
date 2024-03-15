using UnityEngine;

namespace Asteroids
{
	public class MiddleAsteroid : Asteroid
	{
		protected override void SetOrbit()
		{
			float orbitRadius = StaticData.ForOrbits.MiddleOrbitRadius;
			transform.position = new Vector3(-orbitRadius, 0f, 0f);
		}
	}
}