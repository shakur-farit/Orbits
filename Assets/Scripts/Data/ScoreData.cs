using System;

namespace Data
{
	[Serializable]
	public class ScoreData
	{
		public int CurrentScore;

		public int BestScore;

		public int GetBestScore()
		{
			if (CurrentScore > BestScore)
				BestScore = CurrentScore;

			return BestScore;
		}
	}
}