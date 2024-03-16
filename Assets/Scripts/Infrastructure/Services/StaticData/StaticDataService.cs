using StaticData;
using UnityEngine;

namespace Infrastructure.Services.StaticData
{
	public class StaticDataService : IStaticDataService
	{
		private const string AsteroidsStaticDataPath = "StaticData/Asteroids Static Data";
		private const string StarStaticDataPath = "StaticData/Star Static Data";
		private const string HeroStaticData = "StaticData/Hero Static Data";
		private const string OrbitsStaticData = "StaticData/Orbits Static Data";
		private const string DebuffStaticData = "StaticData/Debuff Static Data";

		public HeroStaticData ForHero { get; private set; }

		public AsteroidsStaticData ForAsteroids { get; private set; }

		public OrbitsStaticData ForOrbits { get; private set; }

		public StarStaticData ForStar { get; private set; }

		public DebuffStaticData ForDebuff { get; private set; }

		public void Load()
		{
			ForHero = Resources.Load<HeroStaticData>(HeroStaticData);
			ForAsteroids = Resources.Load<AsteroidsStaticData>(AsteroidsStaticDataPath);
			ForOrbits = Resources.Load<OrbitsStaticData>(OrbitsStaticData);
			ForStar = Resources.Load<StarStaticData>(StarStaticDataPath);
			ForDebuff = Resources.Load<DebuffStaticData>(DebuffStaticData);
		}
	}
}