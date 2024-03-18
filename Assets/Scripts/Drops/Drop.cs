using System.Collections;
using Infrastructure.Services.StaticData;
using StaticEvents;
using UnityEngine;
using Zenject;

namespace Drops
{
	public  abstract class Drop : MonoBehaviour
	{
		protected int TimeToDestroy;

		protected IStaticDataService StaticData;

		[Inject]
		protected void Constructor(IStaticDataService staticData) => 
			StaticData = staticData;

		protected void Start()
		{
			StaticEventsHandler.OnHeroDied += DestroyDrop;

			StartCoroutineOnStart();
		}

		protected void OnDestroy()
		{
			StaticEventsHandler.OnHeroDied -= DestroyDrop;

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