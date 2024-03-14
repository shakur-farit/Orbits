using Drops;
using Rotators;
using StaticEvents;
using UnityEngine;

namespace Bubble
{
	[RequireComponent(typeof(BubbleDeath))]
	public class BubbleCollideDetector : MonoBehaviour
	{
		private BubbleDeath _bubbleDeath;
		private bool _isCollidedWithAsteroid;
		private bool _isCollidedWithBuff;

		private void Start()
		{
			_bubbleDeath = GetComponent<BubbleDeath>();

			StaticEventsHandler.OnBuffSpawned += InformAboutNewBuff;
		}

		private void OnDestroy() => 
			StaticEventsHandler.OnBuffSpawned -= InformAboutNewBuff;

		private void OnTriggerEnter2D(Collider2D other)
		{
			if (other.GetComponent<AsteroidRotator>())
				CollideWithAsteroid();

			if (other.GetComponent<Buff>())
			{
				CollideWithBuff();
				Destroy(other.gameObject);
			}
		}

		private void CollideWithBuff()
		{
			if (_isCollidedWithBuff)
				return;

			_isCollidedWithBuff = true;
			StaticEventsHandler.CallPickedUpBuffEvent();
		}
		private void CollideWithAsteroid()
		{
			if(_isCollidedWithAsteroid)
				return; 

			_isCollidedWithAsteroid = true;
			_bubbleDeath.StopTheGame();
			
		}

		private void InformAboutNewBuff() =>
			_isCollidedWithBuff = false;
	}
}