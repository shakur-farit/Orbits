namespace Drops
{
	public class SpeedUpper : Drop
	{
		protected override void StartCoroutineOnStart()
		{
			TimeToDestroy = StaticData.ForSpeedUpper.TimeToDestroy;

			StartCoroutine(DestroyRoutine(TimeToDestroy));
		}
	}
}