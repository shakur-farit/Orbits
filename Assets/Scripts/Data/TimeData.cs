using System;

namespace Data
{
	[Serializable]
	public class TimeData
	{
		public int CurrentTime;

		public int BestTime;

		public int GetBestTime()
		{
			if (CurrentTime > BestTime)
				BestTime = CurrentTime;

			return BestTime;
		}
	}
}