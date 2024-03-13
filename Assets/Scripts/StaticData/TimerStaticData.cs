using UnityEngine;

namespace StaticData
{
	[CreateAssetMenu(fileName = "Timer Static Data", menuName = "Static Data/Timer")]
	public class TimerStaticData : ScriptableObject
	{
		[Range(1, 5)] public int Min;
		[Range(1, 5)] public int Max;

		private void OnValidate()
		{
			if(Max < Min) 
				Max = Min;
		}
	}
}