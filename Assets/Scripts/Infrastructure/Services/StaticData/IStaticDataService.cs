using StaticData;

namespace Infrastructure.Services.StaticData
{
	public interface IStaticDataService
	{
		RotatorStaticData ForRotator { get; }
		StarStaticData ForStar { get; }
		void  Load();
	}
}