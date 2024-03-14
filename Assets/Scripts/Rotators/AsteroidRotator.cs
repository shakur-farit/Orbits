using Infrastructure.Services.StaticData;
using Zenject;

namespace Rotators
{
	public class AsteroidRotator : Rotator
	{
		[Inject]
		public void Constructor(IStaticDataService staticData) =>
			StaticDataService = staticData;

		protected override void StartRotate() => 
			SetupAngleAndSpeed();

		protected virtual void SetupAngleAndSpeed()
		{

		}
	}
}