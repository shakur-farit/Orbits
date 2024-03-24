using System;
using Asteroids;
using Drops;
using StaticEvents;
using UnityEngine;

namespace Hero
{
	public class HeroCollideDetector : MonoBehaviour
	{
		private HeroDeath _heroDeath;
		private bool _isCollidedWithAsteroid;
		private bool _isCollidedWithStar;
		private bool _isCollidedWithSpeedUpper;


		private void Start()
		{
			_heroDeath = GetComponentInParent<HeroDeath>();

			StaticEventsHandler.OnStarSpawned += InformAboutNewStar;
			StaticEventsHandler.OnSpeedUpperSpawned += InformAboutNewSpeedUpper;
		}

		private void OnDestroy()
		{
			StaticEventsHandler.OnStarSpawned -= InformAboutNewStar;
			StaticEventsHandler.OnSpeedUpperSpawned -= InformAboutNewSpeedUpper;
		}

		private void OnTriggerEnter2D(Collider2D other)
		{
			if (other.GetComponent<Asteroid>())
				Collide(_isCollidedWithAsteroid, _heroDeath.StopTheGame);

			if (other.GetComponent<Star>())
			{
				Collide(_isCollidedWithStar, StaticEventsHandler.CallStarPickedUpEvent);
				Destroy(other.gameObject);
			}

			if (other.GetComponent<SpeedUpper>())
			{
				Collide(_isCollidedWithSpeedUpper, StaticEventsHandler.CallSpeedUpperPickedUpEvent);
				Destroy(other.gameObject);
			}
		}

		private void Collide(bool isCollided, Action action)
		{
			if (isCollided)
				return;

			isCollided = true;
			action();
		}

		private void InformAboutNewStar() =>
			_isCollidedWithStar = false;

		private void InformAboutNewSpeedUpper() =>
			_isCollidedWithSpeedUpper = false;
	}
}