using Asteroids;
using StaticEvents;
using UnityEngine;

namespace Hero
{
	public class HeroCollideDetector : MonoBehaviour
	{
		private HeroDeath _heroDeath;
		private bool _isCollidedWithAsteroid;
		private bool _isCollidedWithStar;

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

			if (other.GetComponent<Drops.Star>())
			{
				CollideWithBuff();
				Destroy(other.gameObject);
			}
		}

		private void CollideWithBuff()
		{
			if (_isCollidedWithStar)
				return;

			_isCollidedWithStar = true;
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