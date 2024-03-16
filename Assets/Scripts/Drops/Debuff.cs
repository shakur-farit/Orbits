namespace Drops
{
	public class Debuff : Drop
	{
		protected override void StartCoroutineOnStart()
		{
			_timeToDestroy = _staticData.ForDebuff.TimeToDestroy;

			StartCoroutine(DestroyRoutine(_timeToDestroy));
		}
	}
}