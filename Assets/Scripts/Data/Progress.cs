using System;

namespace Data
{
	[Serializable]
	public class Progress
	{
		public ScoreData ScoreData = new();
		public OrbitData OrbitData = new();
	}
}