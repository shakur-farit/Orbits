namespace Drops
{
	public class Star : Drop
	{
		protected override void StartCoroutineOnStart()
		{
			TimeToDestroy = StaticData.ForStar.TimeToDestroy;

			StartCoroutine(DestroyRoutine(TimeToDestroy));
		}
	}
}