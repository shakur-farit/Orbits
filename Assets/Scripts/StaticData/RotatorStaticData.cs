using System;
using UnityEngine;

namespace StaticData
{
	[CreateAssetMenu(fileName = "Rotator Static Data", menuName = "Static Data/Rotator")]
	public class RotatorStaticData : ScriptableObject
	{
		public float RotateAngle = 1f;
		public float RotateSpeed = 0.5f;
		public float SpeedChangeCooldown = 30f;
		public float SpeedChangeValue = 0.2f;
	}
}
