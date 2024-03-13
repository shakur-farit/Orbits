using Infrastructure.Services.PersistentProgress;
using Infrastructure.Services.SceneManagement;
using StaticEvents;
using TMPro;
using Zenject;

namespace UI.Windows
{
	public class GameOverWindow : WindowBase
	{
		public TextMeshProUGUI CurrentTimeText;
		public TextMeshProUGUI BestTimeText;

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
			CurrentTimeText.text = _progressService.Progress.TimeData.CurrentTime.ToString();

		private void BestTimeTextUpdate() => 
			BestTimeText.text = _progressService.Progress.TimeData.GetBestTime().ToString();

		private void Restart()
		{
			_restartable.RestartScene();
			CloseWindow();
			StaticEventsHandler.CallStartedToPlayEvent();
		}
	}
}