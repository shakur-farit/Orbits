using Asteroids;
using Drops;
using Infrastructure.Services.Score;
using Infrastructure.Services.StaticData;
using StaticEvents;
using UnityEngine;
using Zenject;

namespace Hero
{
	public class HeroCollideDetector : MonoBehaviour
	{
		private HeroDeath _heroDeath;
		private bool _isCollidedWithAsteroid;
		private bool _isCollidedWithStar;

		private IScoreService _scoreService;
		private IStaticDataService _staticData;

		[Inject]
		public void Construct(IScoreService scoreService, IStaticDataService staticData)
		{
			_scoreService = scoreService;
			_staticData = staticData;
		}

		private void Start()
		{
			_heroDeath = GetComponentInParent<HeroDeath>();

			StaticEventsHandler.OnStarSpawned += InformAboutNewStar;
		}

		private void OnDestroy() => 
			StaticEventsHandler.OnStarSpawned -= InformAboutNewStar;

		private void OnTriggerEnter2D(Collider2D other)
		{
			if (other.GetComponent<Asteroid>())
				CollideWithAsteroid();

			if (other.GetComponent<Star>())
			{
				CollideWithStar();
				Destroy(other.gameObject);
			}
		}

		private void CollideWithStar()
		{
			if (_isCollidedWithStar)
				return;

			_isCollidedWithStar = true;
			_scoreService.IncreaseScore(_staticData.ForStar.ScoreValue);
			StaticEventsHandler.CallPickedUpStarEvent();
		}
		private void CollideWithAsteroid()
		{
			if(_isCollidedWithAsteroid)
				return;

			_isCollidedWithAsteroid = true;
			_heroDeath.StopTheGame();
		}

		private void InformAboutNewStar() =>
			_isCollidedWithStar = false;
	}
}