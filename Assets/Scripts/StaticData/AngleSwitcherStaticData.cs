using UnityEngine;

namespace StaticData
{
	[CreateAssetMenu(fileName = "AngleSwitcher Static Data", menuName = "Static Data/AngleSwitcher")]
	public class AngleSwitcherStaticData : ScriptableObject
	{
		[Range(0, 30)] public int MinSpawnCooldown;
		[Range(0, 30)] public int MaxSpawnCooldown;

		public int TimeToDestroy;

		private void OnValidate()
		{
			if (MaxSpawnCooldown < MinSpawnCooldown)
				MaxSpawnCooldown = MinSpawnCooldown;
		}
	}
}