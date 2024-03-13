using Infrastructure.Services.PersistentProgress;
using Infrastructure.Services.SaveLoadService;
using StaticEvents;
using UI.Services.Window;
using UnityEngine;
using Zenject;

namespace Bubble
{
	public class BubbleDeath : MonoBehaviour
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
			SaveBestTime();
			OpenGameOverWindow();
			DestroyBubble();
		}


		private void SaveBestTime()
		{
			int currentTime = _progressService.Progress.TimeData.CurrentTime;
			int bestTime = _progressService.Progress.TimeData.BestTime;

			if (currentTime > bestTime)
				_progressService.Progress.TimeData.BestTime = currentTime;

			_saveService.SaveProgress();
		}

		private void OpenGameOverWindow() =>
			_windowService.Open(WindowId.GameOver);

		private void DestroyBubble()
		{
			StaticEventsHandler.CallPlayerDiedEvent();
			Destroy(gameObject);
		}
	}
}