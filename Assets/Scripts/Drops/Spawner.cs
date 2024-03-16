using System.Collections;
using Infrastructure.Factory;
using Infrastructure.Services.Randomizer;
using Infrastructure.Services.StaticData;
using StaticEvents;
using UnityEngine;
using Zenject;

namespace Drops
{
	public class Spawner : MonoBehaviour
	{
		private const float Radius = 1f;
		private readonly Vector2 _center = Vector2.zero;

		private IGameFactory _gameFactory;
		private IRandomService _randomService;
		private IStaticDataService _staticData;

		[Inject]
		public void Constructor(IGameFactory gameFactory, IRandomService randomService,
			IStaticDataService staticData)
		{
			_gameFactory = gameFactory;
			_randomService = randomService;
			_staticData = staticData;
		}


		private void OnEnable()
		{
			StaticEventsHandler.OnStartedToPlay += SpawnStar;
			StaticEventsHandler.OnHeroDied += StopSpawning;
		}

		private void OnDisable()
		{
			StaticEventsHandler.OnStartedToPlay -= SpawnStar;
			StaticEventsHandler.OnHeroDied -= StopSpawning;
		}

		private void SpawnStar() =>
			StartCoroutine(SpawnStarRoutine());

		private IEnumerator SpawnStarRoutine()
		{
			float spawnTime = GetStarSpawnTime();
			Vector2 position = GetPositionToSpawn();

			yield return new WaitForSeconds(spawnTime);
			_gameFactory.CreateStar(position, transform);
			StaticEventsHandler.CallStarSpawnedEvent();

			StartCoroutine(SpawnStarRoutine());
		}

		private float GetStarSpawnTime()
		{
			float minSpawnTime = _staticData.ForStar.MinSpawnCooldown;
			float maxSpawnTime = _staticData.ForStar.MaxSpawnCooldown;
			return _randomService.Next(minSpawnTime, maxSpawnTime);
		}

		private Vector2 GetPositionToSpawn() =>
			_center + new Vector2(Random.value - 0.5f, Random.value - 0.5f)
				.normalized * Radius;

		private void StopSpawning() => 
			StopAllCoroutines();
	}
}