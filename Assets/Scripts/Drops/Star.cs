namespace Drops
{
	public class Star : Drop
	{
		protected override void StartCoroutineOnStart()
		{
			_timeToDestroy = _staticData.ForStar.TimeToDestroy;

			StartCoroutine(DestroyRoutine(_timeToDestroy));
		}
	}
}