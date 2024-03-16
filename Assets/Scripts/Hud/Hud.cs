using Infrastructure.Services.PersistentProgress;
using StaticEvents;
using TMPro;
using UnityEngine;
using Zenject;

namespace Hud
{
	public class Hud : MonoBehaviour
	{
		public TextMeshProUGUI ScoreText;

		private IPersistentProgressService _progressService;

		[Inject]
		private void Constructor(IPersistentProgressService progressService) =>
			_progressService = progressService;

		private void Start()
		{
			UpdateScoreText();

			StaticEventsHandler.OnPickedUpStar += UpdateScoreText;
		}

		private void UpdateScoreText()
		{
			ScoreText.text = _progressService.Progress.ScoreData.CurrentScore.ToString();
		}
	}
}