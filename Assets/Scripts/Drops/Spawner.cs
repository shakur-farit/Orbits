using System;
using System.Collections;
using Infrastructure.Factory;
using Infrastructure.Services.Randomizer;
using Infrastructure.Services.StaticData;
using StaticEvents;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

namespace Drops
{
	public class Spawner : MonoBehaviour
	{
		private readonly Vector2 _center = Vector2.zero;

		private GameFactory _gameFactory;
		private RandomService _randomService;
		private StaticDataService _staticData;

		[Inject]
		public void Constructor(GameFactory gameFactory, RandomService randomService,
			StaticDataService staticData)
		{
			_gameFactory = gameFactory;
			_randomService = randomService;
			_staticData = staticData;
		}

		private void OnEnable()
		{
			StaticEventsHandler.OnStartedToPlay += SpawnStar;
			StaticEventsHandler.OnStartedToPlay += SpawnSpeedUpper;
			StaticEventsHandler.OnHeroDied += StopSpawning;
		}

		private void OnDisable()
		{
			StaticEventsHandler.OnStartedToPlay -= SpawnStar;
			StaticEventsHandler.OnStartedToPlay -= SpawnSpeedUpper;
			StaticEventsHandler.OnHeroDied -= StopSpawning;
		}

		private void SpawnStar()
		{
			float minSpawnTime = _staticData.ForStar.MinSpawnCooldown;
			float maxSpawnTime = _staticData.ForStar.MaxSpawnCooldown;
			Action<Vector2, Transform> createAction = _gameFactory.CreateStar;
			Action eventCallAction = StaticEventsHandler.CallStarSpawnedEvent;

			StartCoroutine(SpawnRoutine(minSpawnTime, maxSpawnTime, createAction, eventCallAction));
		}

		private void SpawnSpeedUpper()
		{
			float minSpawnTime = _staticData.ForStar.MinSpawnCooldown;
			float maxSpawnTime = _staticData.ForStar.MaxSpawnCooldown;
			Action<Vector2,Transform> createAction = _gameFactory.CreateSpeedUpper;
			Action eventCallAction = StaticEventsHandler.CallSpeedUpperSpawnedEvent;

			StartCoroutine(SpawnRoutine(minSpawnTime, maxSpawnTime, createAction, eventCallAction));
		}

		private IEnumerator SpawnRoutine(float minSpawnTime, float maxSpawnTime, 
			Action<Vector2, Transform> createAction, Action eventCallAction)
		{
			while (true)
			{
				float spawnTime = GetSpawnTime(minSpawnTime, maxSpawnTime);
				Vector2 position = GetPositionToSpawn();

				yield return new WaitForSeconds(spawnTime);
				createAction(position, transform);
				eventCallAction();
			}
		}

		private float GetSpawnTime(float minSpawnTime, float maxSpawnTime) => 
			_randomService.Next(minSpawnTime, maxSpawnTime);

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