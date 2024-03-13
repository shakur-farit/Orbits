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
			StaticEventsHandler.OnStartedToPlay += SpawnDebuff;
			StaticEventsHandler.OnStartedToPlay += SpawnBuff;
			StaticEventsHandler.OnPlayerDied += StopSpawning;
		}

		private void OnDisable()
		{
			StaticEventsHandler.OnStartedToPlay -= SpawnDebuff;
			StaticEventsHandler.OnStartedToPlay -= SpawnBuff;
			StaticEventsHandler.OnPlayerDied -= StopSpawning;
		}

		private void SpawnBuff() =>
			StartCoroutine(SpawnBuffRoutine());

		private IEnumerator SpawnBuffRoutine()
		{
			float spawnTime = GetBuffSpawnTime();
			Vector2 position = GetPositionToSpawn();

			yield return new WaitForSeconds(spawnTime);
			_gameFactory.CreateBuff(position, transform);
			StaticEventsHandler.CallBuffSpawnedEvent();

			StartCoroutine(SpawnBuffRoutine());
		}

		private float GetBuffSpawnTime()
		{
			float minSpawnTime = _staticData.ForBuff.MinSpawnCooldown;
			float maxSpawnTime = _staticData.ForBuff.MaxSpawnCooldown;
			return _randomService.Next(minSpawnTime, maxSpawnTime);
		}

		private void SpawnDebuff() => 
			StartCoroutine(SpawnDebuffRoutine());

		private IEnumerator SpawnDebuffRoutine()
		{
			float spawnTime = GetDebuffSpawnTime();
			Vector2 position = GetPositionToSpawn();

			yield return new WaitForSeconds(spawnTime);
			_gameFactory.CreateDebuff(position, transform);
			StaticEventsHandler.CallDebuffSpawnedEvent();
		
			StartCoroutine(SpawnDebuffRoutine());
		}

		private float GetDebuffSpawnTime()
		{
			float minSpawnTime = _staticData.ForDebuff.MinSpawnCooldown;
			float maxSpawnTime = _staticData.ForDebuff.MaxSpawnCooldown;
			return _randomService.Next(minSpawnTime, maxSpawnTime);
		}

		private Vector2 GetPositionToSpawn() =>
			_center + new Vector2(Random.value - 0.5f, Random.value - 0.5f)
				.normalized * Radius;

		private void StopSpawning() => 
			StopAllCoroutines();
	}
}