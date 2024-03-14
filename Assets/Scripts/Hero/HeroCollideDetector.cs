using Rotators;
using StaticEvents;
using UnityEngine;

namespace Hero
{
	[RequireComponent(typeof(HeroDeath))]
	public class HeroCollideDetector : MonoBehaviour
	{
		private HeroDeath _heroDeath;
		private bool _isCollidedWithAsteroid;
		private bool _isCollidedWithStar;

		private void Start()
		{
			_heroDeath = GetComponent<HeroDeath>();

			StaticEventsHandler.OnStarSpawned += InformAboutNewStar;
		}

		private void OnDestroy() => 
			StaticEventsHandler.OnStarSpawned -= InformAboutNewStar;

		private void OnTriggerEnter2D(Collider2D other)
		{
			if (other.GetComponent<AsteroidRotator>())
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