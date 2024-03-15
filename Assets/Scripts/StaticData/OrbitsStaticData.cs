using UnityEngine;

namespace StaticData
{
	[CreateAssetMenu(fileName = "Orbits Static Data", menuName = "Static Data/Orbits")]
	public class OrbitsStaticData : ScriptableObject
	{
		public float SmallOrbitRadius = 0.4f;
		public float MiddleOrbitRadius = 1f;
		public float BigOrbitRadius = 1.7f;
	}
}