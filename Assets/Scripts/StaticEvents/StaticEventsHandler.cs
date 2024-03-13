using System;

namespace StaticEvents
{
	public static class StaticEventsHandler
	{
		public static Action OnStartedToPlay;
		public static Action OnBuffSpawned;
		public static Action OnPickedUpBuff;
		public static Action OnDebuffSpawned;
		public static Action OnPickedUpDebuff;
		public static Action OnPlayerDied;


		public static void CallStartedToPlayEvent() => 
			OnStartedToPlay?.Invoke();

		public static void CallPlayerDiedEvent() => 
			OnPlayerDied?.Invoke();

		public static void CallBuffSpawnedEvent() => 
			OnBuffSpawned?.Invoke();

		public static void CallPickedUpBuffEvent() =>
			OnPickedUpBuff?.Invoke();

		public static void CallDebuffSpawnedEvent() => 
			OnDebuffSpawned?.Invoke();

		public static void CallPickedUpDebuffEvent() => 
			OnPickedUpDebuff?.Invoke();
	}
}