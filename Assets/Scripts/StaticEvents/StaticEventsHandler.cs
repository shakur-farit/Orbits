using System;

namespace StaticEvents
{
	public static class StaticEventsHandler
	{
		public static Action OnStartedToPlay;
		public static Action OnStarSpawned;
		public static Action OnPickedUpStar;
		public static Action OnPlayerDied;


		public static void CallStartedToPlayEvent() => 
			OnStartedToPlay?.Invoke();

		public static void CallPlayerDiedEvent() => 
			OnPlayerDied?.Invoke();

		public static void CallStarSpawnedEvent() => 
			OnStarSpawned?.Invoke();

		public static void CallPickedUpStarEvent() =>
			OnPickedUpStar?.Invoke();
	}
}