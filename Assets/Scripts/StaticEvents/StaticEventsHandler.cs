using System;

namespace StaticEvents
{
	public static class StaticEventsHandler
	{
		public static Action OnStartedToPlay;
		public static Action OnStarSpawned;
		public static Action OnSpeedUpperSpawned;
		public static Action OnAngleSwitcherSpawned;
		public static Action OnStarPickedUp;
		public static Action OnSpeedUpperPickedUp;
		public static Action OnAngleSwitcherPickedUp;
		public static Action OnHeroDied;
		public static Action OnScoreChanged;


		public static void CallStartedToPlayEvent() => 
			OnStartedToPlay?.Invoke();

		public static void CallPlayerDiedEvent() => 
			OnHeroDied?.Invoke();

		public static void CallStarSpawnedEvent() => 
			OnStarSpawned?.Invoke();

		public static void CallSpeedUpperSpawnedEvent() => 
			OnSpeedUpperSpawned?.Invoke();

		public static void CallAngleSwitcherSpawnedEvent() => 
			OnAngleSwitcherSpawned?.Invoke();

		public static void CallStarPickedUpEvent() =>
			OnStarPickedUp?.Invoke();

		public static void CallSpeedUpperPickedUpEvent() => 
			OnSpeedUpperPickedUp?.Invoke();

		public static void CallAngleSwitcherPickedUpEvent() =>
			OnAngleSwitcherPickedUp?.Invoke();
		
		public static void CallScoreChangedEvent() => 
			OnScoreChanged?.Invoke();
	}
}