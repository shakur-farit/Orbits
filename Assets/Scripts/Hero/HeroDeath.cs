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
		private IWindowService _windowService;
		private IPersistentProgressService _progressService;
		private ISaveService _saveService;

		[Inject]
		public void Construct(IWindowService windowService,
			IPersistentProgressService progressService, ISaveService saveService)
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
			int currentTime = _progressService.Progress.scoreData.CurrentScore;
			int bestTime = _progressService.Progress.scoreData.BestScore;

			if (currentTime > bestTime)
				_progressService.Progress.scoreData.BestScore = currentTime;

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