using Infrastructure.Services.Score;
using Infrastructure.Services.StaticData;
using StaticEvents;
using UnityEngine;
using Zenject;

namespace Hud
{
	public class ScoreCounter : MonoBehaviour
	{
		private IScoreService _scoreService;
		private IStaticDataService _staticData;

		[Inject]
		public void Constructor(IScoreService scoreService, IStaticDataService staticData)
		{
			_scoreService = scoreService;
			_staticData = staticData;
		}

		private void Start() => 
			StaticEventsHandler.OnPickedUpStar += AddScore;

		private void OnDestroy() => 
			StaticEventsHandler.OnPickedUpStar -= AddScore;

		private void AddScore()
		{
			_scoreService.IncreaseScore(_staticData.ForStar.ScoreValue);
			StaticEventsHandler.CallScoreChangedEvent();
		}
	}
}