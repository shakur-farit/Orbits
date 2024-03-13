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
		private bool _isCollidedWithNeedle;
		private bool _isCollidedWithBuff;
		private bool _isCollidedWithDebuff;

		private void Start()
		{
			_bubbleDeath = GetComponent<BubbleDeath>();

			StaticEventsHandler.OnBuffSpawned += InformAboutNewBuff;
			StaticEventsHandler.OnDebuffSpawned += InformAboutNewDebuff;
		}

		private void OnDestroy()
		{
			StaticEventsHandler.OnBuffSpawned -= InformAboutNewBuff;
			StaticEventsHandler.OnDebuffSpawned -= InformAboutNewDebuff;
		}

		private void OnTriggerEnter2D(Collider2D other)
		{
			if (other.GetComponent<NeedleRotator>())
				CollideWithNeedle();

			if (other.GetComponent<Debuff>())
			{
				CollideWithDebuff();
				Destroy(other.gameObject);
			}

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

		private void CollideWithDebuff()
		{
			if(_isCollidedWithDebuff)
				return;

			_isCollidedWithDebuff = true;
			StaticEventsHandler.CallPickedUpDebuffEvent();
		}

		private void CollideWithNeedle()
		{
			if(_isCollidedWithNeedle)
				return; 

			_isCollidedWithNeedle = true;
			_bubbleDeath.StopTheGame();
			
		}

		private void InformAboutNewBuff() =>
			_isCollidedWithBuff = false;

		private void InformAboutNewDebuff() => 
			_isCollidedWithDebuff = false;
	}
}