using Infrastructure.Services.PersistentProgress;
using Infrastructure.Services.SaveLoadService;
using StaticEvents;
using UI.Services.Window;
using UnityEngine;
using Zenject;

namespace Hero
{
	public class HeroDeath : MonoBehaviour
	{
		private WindowService _windowService;
		private PersistentProgressService _progressService;
		private ISaveService _saveService;

		[Inject]
		public void Construct(WindowService windowService,
			PersistentProgressService progressService, ISaveService saveService)
		{
			_windowService = windowService;
			_progressService = progressService;
			_saveService = saveService;
		}

		public void StopTheGame()
		{
			SaveBestScore();
			OpenGameOverWindow();
			DestroyHero();
		}


		private void SaveBestScore()
		{
			int currentScore = _progressService.Progress.ScoreData.CurrentScore;
			int bestScore = _progressService.Progress.ScoreData.BestScore;

			if (currentScore > bestScore)
				_progressService.Progress.ScoreData.BestScore = currentScore;

			_saveService.SaveProgress();
		}

		private void OpenGameOverWindow() =>
			_windowService.Open(WindowId.GameOver);

		private void DestroyHero()
		{
			StaticEventsHandler.CallPlayerDiedEvent();
			Destroy(gameObject);
		}
	}
}