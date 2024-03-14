using StaticData;
using UnityEngine;

namespace Infrastructure.Services.StaticData
{
	public class StaticDataService : IStaticDataService
	{
		private const string RotatorStaticDataPath = "StaticData/Rotator Static Data";
		private const string StarStaticDataPath = "StaticData/Star Static Data";

		public RotatorStaticData ForRotator { get; private set; }

		public StarStaticData ForStar { get; private set; }

		public void Load()
		{
			ForRotator = Resources.Load<RotatorStaticData>(RotatorStaticDataPath);
			ForStar = Resources.Load<StarStaticData>(StarStaticDataPath);
		}
	}
}