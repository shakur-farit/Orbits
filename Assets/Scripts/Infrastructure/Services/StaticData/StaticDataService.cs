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
		private const string SpeedUpperStaticData = "StaticData/SpeedUpper Static Data";
		private const string AngleChangerStaticData = "StaticData/AngleSwitcher Static Data";

		public HeroStaticData ForHero { get; private set; }
		public AsteroidsStaticData ForAsteroids { get; private set; }
		public OrbitsStaticData ForOrbits { get; private set; }
		public StarStaticData ForStar { get; private set; }
		public SpeedUpperStaticData ForSpeedUpper { get; private set; }
		public AngleSwitcherStaticData ForAngleSwitcher { get; private set; }

		public void Load()
		{
			ForHero = Resources.Load<HeroStaticData>(HeroStaticData);
			ForAsteroids = Resources.Load<AsteroidsStaticData>(AsteroidsStaticDataPath);
			ForOrbits = Resources.Load<OrbitsStaticData>(OrbitsStaticData);
			ForStar = Resources.Load<StarStaticData>(StarStaticDataPath);
			ForSpeedUpper = Resources.Load<SpeedUpperStaticData>(SpeedUpperStaticData);
			ForAngleSwitcher = Resources.Load<AngleSwitcherStaticData>(AngleChangerStaticData);
		}
	}
}