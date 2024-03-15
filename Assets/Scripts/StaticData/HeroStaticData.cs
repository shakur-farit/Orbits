using UnityEngine;

namespace StaticData
{
	[CreateAssetMenu(fileName = "Hero Static Data", menuName = "Static Data/Hero")]
	public class HeroStaticData : ScriptableObject
	{
		public float HeroRotateSpeed = 0.5f;
	}
}