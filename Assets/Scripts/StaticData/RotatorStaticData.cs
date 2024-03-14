using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace StaticData
{
	[CreateAssetMenu(fileName = "Rotator Static Data", menuName = "Static Data/Rotator")]
	public class RotatorStaticData : ScriptableObject
	{
		public float RotateAngle = 1f;
		public float HeroRotateSpeed = 0.5f;
		public float BigAsteroidRotateSpeed = 1f;
		public float MiddleAsteroidRotateSpeed = 0.5f;
		public float SmallAsteroidRotateSpeed = 0.2f;
	}
}
