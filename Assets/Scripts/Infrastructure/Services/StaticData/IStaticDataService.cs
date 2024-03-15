using StaticData;

namespace Infrastructure.Services.StaticData
{
	public interface IStaticDataService
	{
		HeroStaticData ForHero { get; }
		AsteroidsStaticData ForAsteroids { get; }
		OrbitsStaticData ForOrbits { get; }
		StarStaticData ForStar { get; }
		void  Load();
	}
}