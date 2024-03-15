using Infrastructure.Services.PersistentProgress;
using Infrastructure.Services.SceneManagement;
using StaticEvents;
using TMPro;
using UnityEngine.Serialization;
using Zenject;

namespace UI.Windows
{
	public class GameOverWindow : WindowBase
	{
		public TextMeshProUGUI CurrentScoreText;
		public TextMeshProUGUI BestScoreText;

		private IRestartable _restartable;
		private IPersistentProgressService _progressService;

		[Inject]
		private void Constructor(IRestartable restartable,IPersistentProgressService progressService)
		{
			_restartable = restartable;
			_progressService = progressService;
		}

		protected override void OnAwake()
		{
			CloseButton.onClick.AddListener(() => Restart());
			CurrentTimeTextUpdate();
			BestTimeTextUpdate();
		}

		private void CurrentTimeTextUpdate() => 
			CurrentScoreText.text = _progressService.Progress.ScoreData.CurrentScore.ToString();

		private void BestTimeTextUpdate() => 
			BestScoreText.text = _progressService.Progress.ScoreData.GetBestScore().ToString();

		private void Restart()
		{
			_restartable.RestartScene();
			CloseWindow();
			StaticEventsHandler.CallStartedToPlayEvent();
		}
	}
}