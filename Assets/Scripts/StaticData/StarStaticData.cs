using UnityEngine;

namespace StaticData
{
	[CreateAssetMenu(fileName = "Star Static Data", menuName = "Static Data/Star")]
	public class StarStaticData : ScriptableObject
	{
		[Range(0, 30)] public int MinSpawnCooldown;
		[Range(0, 30)] public int MaxSpawnCooldown;

		public int TimeToDestroy;

		public int ScoreValue;

		private void OnValidate()
		{
			if (MaxSpawnCooldown < MinSpawnCooldown)
				MaxSpawnCooldown = MinSpawnCooldown;
		}
	}
}