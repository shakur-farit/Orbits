namespace Drops
{
	public class AngleSwitcher : Drop
	{
		protected override void StartCoroutineOnStart()
		{
			TimeToDestroy = StaticData.ForAngleSwitcher.TimeToDestroy;

			StartCoroutine(DestroyRoutine(TimeToDestroy));
		}
	}
}