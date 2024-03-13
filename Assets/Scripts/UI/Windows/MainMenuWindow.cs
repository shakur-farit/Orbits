using Infrastructure.Services.PersistentProgress;
using Infrastructure.Services.SceneManagement;
using StaticEvents;
using TMPro;
using UnityEngine.UI;
using Zenject;

namespace UI.Windows
{
	public class MainMenuWindow : WindowBase
	{
		public Button QuitButton;
		
		public TextMeshProUGUI BestTimeText;

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
			BestTimeTextUpdate();
		}

		private void Quit() => 
			_quitService.Quit();

		private void Play()
		{
			StaticEventsHandler.CallStartedToPlayEvent();
			CloseWindow();
		}

		private void BestTimeTextUpdate() =>
			BestTimeText.text = _progressService.Progress.TimeData.GetBestTime().ToString();
	}
}