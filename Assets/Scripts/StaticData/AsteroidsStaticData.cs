using UnityEngine;


namespace StaticData
{
	[CreateAssetMenu(fileName = "Asteroids Static Data", menuName = "Static Data/Asteroids")]
	public class AsteroidsStaticData : ScriptableObject
	{
		public float RotateAngle = 1f;
		public float BigAsteroidRotateSpeed = 1f;
		public float MiddleAsteroidRotateSpeed = 0.5f;
		public float SmallAsteroidRotateSpeed = 0.2f;
	}
}
