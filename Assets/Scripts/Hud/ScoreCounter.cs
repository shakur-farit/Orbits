using Infrastructure.Services.PersistentProgress;
using Infrastructure.Services.Score;
using Infrastructure.Services.StaticData;
using StaticEvents;
using UnityEngine;
using Zenject;

namespace Hud
{
	public class ScoreCounter : MonoBehaviour
	{
		private const int CurrentScoreOnStart = 0;

		private ScoreService _scoreService;
		private StaticDataService _staticData;
		private PersistentProgressService _progressService;

		[Inject]
		public void Constructor(ScoreService scoreService, StaticDataService staticData,
			PersistentProgressService progressService)
		{
			_scoreService = scoreService;
			_staticData = staticData;
			_progressService = progressService;
		}

		private void OnEnable()
		{
			StaticEventsHandler.OnStarPickedUp += AddScore;
			StaticEventsHandler.OnStartedToPlay += ResetCurrentScore;
		}

		private void OnDisable()
		{
			StaticEventsHandler.OnStarPickedUp -= AddScore;
			StaticEventsHandler.OnStartedToPlay -= ResetCurrentScore;
		}

		private void AddScore()
		{
			_scoreService.IncreaseScore(_staticData.ForStar.ScoreValue);
			StaticEventsHandler.CallScoreChangedEvent();
		}

		private void ResetCurrentScore() => 
			_progressService.Progress.ScoreData.CurrentScore = CurrentScoreOnStart;
	}
}