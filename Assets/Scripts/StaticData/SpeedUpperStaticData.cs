using UnityEngine;

namespace StaticData
{
	[CreateAssetMenu(fileName = "SpeedUpper Static Data", menuName = "Static Data/SpeedUpper")]
	public class SpeedUpperStaticData : ScriptableObject
	{
		[Range(0, 30)] public int MinSpawnCooldown;
		[Range(0, 30)] public int MaxSpawnCooldown;

		public int TimeToDestroy;

		public float IncreaseRotateSpeedValue;

		private void OnValidate()
		{
			if (MaxSpawnCooldown < MinSpawnCooldown)
				MaxSpawnCooldown = MinSpawnCooldown;
		}
	}
}