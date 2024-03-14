using StaticData;

namespace Infrastructure.Services.StaticData
{
	public interface IStaticDataService
	{
		RotatorStaticData ForRotator { get; }
		DebuffStaticData ForDebuff { get; }
		BuffStaticData ForBuff { get; }
		void  Load();
	}
}