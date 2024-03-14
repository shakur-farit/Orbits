using System.Collections;
using Infrastructure.Services.StaticData;
using StaticEvents;
using UnityEngine;
using Zenject;

namespace Drops
{
	public  abstract class Drop : MonoBehaviour
	{
		protected int _timeToDestroy;

		protected IStaticDataService _staticData;

		[Inject]
		protected void Constructor(IStaticDataService staticData) => 
			_staticData = staticData;

		protected void Start()
		{
			StaticEventsHandler.OnPlayerDied += DestroyDrop;

			StartCoroutineOnStart();
		}

		protected void OnDestroy()
		{
			StaticEventsHandler.OnPlayerDied -= DestroyDrop;

			StopAllCoroutines();
		}

		protected abstract void StartCoroutineOnStart();

		private void DestroyDrop() =>
			Destroy(gameObject);

		protected IEnumerator DestroyRoutine(int timeToDestroy)
		{
			yield return new WaitForSeconds(timeToDestroy);
			Destroy(gameObject);
		}
	}
}