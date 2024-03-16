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
		private bool _isCollidedWithDebuff;

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
			StaticEventsHandler.OnDebuffSpawned += InformAboutNewDebuff;
		}

		private void OnDestroy()
		{
			StaticEventsHandler.OnStarSpawned -= InformAboutNewStar;
			StaticEventsHandler.OnDebuffSpawned -= InformAboutNewDebuff;
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

			if (other.GetComponent<Debuff>())
			{
				CollideWithDebuff();
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
			StaticEventsHandler.CallPickedUpStarEvent();
		}

		private void InformAboutNewStar() =>
			_isCollidedWithStar = false;

		private void CollideWithDebuff()
		{
			if (_isCollidedWithDebuff)
				return;

			_isCollidedWithDebuff = true;
			StaticEventsHandler.CallPickedUpDebuffEvent();
			Debug.Log("Collide");
		}

		private void InformAboutNewDebuff() =>
			_isCollidedWithDebuff = false;
	}
}