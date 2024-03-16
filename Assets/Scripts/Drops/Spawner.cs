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
			StaticEventsHandler.OnStartedToPlay += SpawnDebuff;
			StaticEventsHandler.OnHeroDied += StopSpawning;
		}

		private void OnDisable()
		{
			StaticEventsHandler.OnStartedToPlay -= SpawnStar;
			StaticEventsHandler.OnStartedToPlay -= SpawnDebuff;
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

		private Vector2 GetPositionToSpawn()
		{
			float radius = GetRadiusToSpawn();

			return _center + new Vector2(Random.value - 0.5f, Random.value - 0.5f)
				.normalized * radius;
		}

		private float GetRadiusToSpawn()
		{
			float[] radius =
			{
				_staticData.ForOrbits.SmallOrbitRadius,
				_staticData.ForOrbits.MiddleOrbitRadius,
				_staticData.ForOrbits.BigOrbitRadius
			};

			int randomIndex = _randomService.Next(0, radius.Length);

			return radius[randomIndex];
		}

		private void StopSpawning() => 
			StopAllCoroutines();
	}
}