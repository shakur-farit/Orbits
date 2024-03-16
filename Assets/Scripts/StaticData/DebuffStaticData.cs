using UnityEngine;

namespace StaticData
{
	[CreateAssetMenu(fileName = "Debuff Static Data", menuName = "Static Data/Debuff")]
	public class DebuffStaticData : ScriptableObject
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