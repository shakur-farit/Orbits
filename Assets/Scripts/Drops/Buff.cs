namespace Drops
{
	public class Buff : Drop
	{
		protected override void StartCoroutineOnStart()
		{
			_timeToDestroy = _staticData.ForBuff.TimeToDestroy;

			StartCoroutine(DestroyRoutine(_timeToDestroy));
		}
	}
}