using StaticData;
using UnityEngine;

namespace Infrastructure.Services.StaticData
{
	public class StaticDataService : IStaticDataService
	{
		private const string RotatorStaticDataPath = "StaticData/Rotator Static Data";
		private const string DebuffStaticDataPath = "StaticData/Debuff Static Data";
		private const string BuffStaticDataPath = "StaticData/Buff Static Data";

		public RotatorStaticData ForRotator { get; private set; }

		public DebuffStaticData ForDebuff { get; private set; }

		public BuffStaticData ForBuff { get; private set; }

		public void Load()
		{
			ForRotator = Resources.Load<RotatorStaticData>(RotatorStaticDataPath);
			ForDebuff = Resources.Load<DebuffStaticData>(DebuffStaticDataPath);
			ForBuff = Resources.Load<BuffStaticData>(BuffStaticDataPath);
		}
	}
}