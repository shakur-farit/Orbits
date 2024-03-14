using Infrastructure.Services.PersistentProgress;
using Infrastructure.Services.SceneManagement;
using StaticEvents;
using TMPro;
using UnityEngine.Serialization;
using UnityEngine.UI;
using Zenject;

namespace UI.Windows
{
	public class MainMenuWindow : WindowBase
	{
		public Button QuitButton;
		
		public TextMeshProUGUI BestScoreText;

		private IPersistentProgressService _progressService;
		private IQuitable _quitService;

		[Inject]
		private void Constructor(IPersistentProgressService progressService, IQuitable quitService)
		{
			_progressService = progressService;
			_quitService = quitService;
		}

		protected override void OnAwake()
		{
			CloseButton.onClick.AddListener(() => Play());
			QuitButton.onClick.AddListener(() => Quit());
			BestScoreTextUpdate();
		}

		private void Quit() => 
			_quitService.Quit();

		private void Play()
		{
			StaticEventsHandler.CallStartedToPlayEvent();
			CloseWindow();
		}

		private void BestScoreTextUpdate() =>
			BestScoreText.text = _progressService.Progress.scoreData.GetBestScore().ToString();
	}
}