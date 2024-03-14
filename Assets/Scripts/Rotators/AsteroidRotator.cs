using Infrastructure.Services.StaticData;
using Zenject;

namespace Rotators
{
	public class AsteroidRotator : Rotator
	{
		[Inject]
		public void Constructor(IStaticDataService staticData) =>
			_staticDataService = staticData;

		protected override void StartRotate() => 
			SetupAngleAndSpeed();

		protected virtual void SetupAngleAndSpeed()
		{

		}
	}
}