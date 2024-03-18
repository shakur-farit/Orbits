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
		private bool _isCollidedWithSpeedUpper;
		private bool _isCollidedWithAngleSwitcher;

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
			StaticEventsHandler.OnSpeedUpperSpawned += InformAboutNewSpeedUpper;
			StaticEventsHandler.OnAngleSwitcherSpawned += InformAboutNewAngleSwitcher;
		}

		private void OnDestroy()
		{
			StaticEventsHandler.OnStarSpawned -= InformAboutNewStar;
			StaticEventsHandler.OnSpeedUpperSpawned -= InformAboutNewSpeedUpper;
		}

		private void OnTriggerEnter2D(Collider2D other)
		{
			if (other.GetComponent<Asteroid>())
				CollideWithAsteroid();

			if (other.GetComponent<Star>())
			{
				CollideWithStar();
				Destroy(other.gameObject);
			}

			if (other.GetComponent<SpeedUpper>())
			{
				CollideWithSpeedUpper();
				Destroy(other.gameObject);
			}

			if (other.GetComponent<AngleSwitcher>())
			{
				CollideWithAngleSwitcher();
				Destroy(other.gameObject);
			}
		}

		private void CollideWithAsteroid()
		{
			if(_isCollidedWithAsteroid)
				return;

			_isCollidedWithAsteroid = true;
			_heroDeath.StopTheGame();
		}

		private void CollideWithStar()
		{
			if (_isCollidedWithStar)
				return;

			_isCollidedWithStar = true;
			StaticEventsHandler.CallStarPickedUpEvent();
		}

		private void InformAboutNewStar() =>
			_isCollidedWithStar = false;

		private void CollideWithSpeedUpper()
		{
			if (_isCollidedWithSpeedUpper)
				return;

			_isCollidedWithSpeedUpper = true;
			StaticEventsHandler.CallSpeedUpperPickedUpEvent();
		}

		private void InformAboutNewSpeedUpper() =>
			_isCollidedWithSpeedUpper = false;

		private void CollideWithAngleSwitcher()
		{
			if (_isCollidedWithAngleSwitcher)
				return;

			_isCollidedWithAngleSwitcher = true;
			StaticEventsHandler.CallAngleSwitcherPickedUpEvent();
		}
		
		private void InformAboutNewAngleSwitcher() => 
			_isCollidedWithAngleSwitcher = false;
	}
}