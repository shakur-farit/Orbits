namespace Drops
{
	public class SpeedUpper : Drop
	{
		protected override void StartCoroutineOnStart()
		{
			_timeToDestroy = _staticData.ForSpeedUpper.TimeToDestroy;

			StartCoroutine(DestroyRoutine(_timeToDestroy));
		}
	}
}