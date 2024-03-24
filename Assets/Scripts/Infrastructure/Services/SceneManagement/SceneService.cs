using Infrastructure.Factory;
using UnityEngine;

namespace Infrastructure.Services.SceneManagement
{
	public class SceneService : IRestartable, IQuitable
	{
		private readonly GameFactory _gameFactory;

		public SceneService(GameFactory gameFactory)
		{
			_gameFactory = gameFactory;
		}

		public void RestartScene()
		{
			ClearScene();
			CreateGameObjects();
		}

		public void Quit()
		{
#if UNITY_EDITOR
			UnityEditor.EditorApplication.isPlaying =false;
#else
			Application.Quit();
#endif
		}

		private void ClearScene()
		{
			DestroyHero();
			DestroyAsteroids();
			DestroyStar();
			DestroySpeedUpper();
			DestroySpawner();
		}

		private void CreateGameObjects()
		{
			CreateHero();
			CreateAsteroids();
			CreateSpawner();
		}

		private void CreateHero() => 
			_gameFactory.CreateHero();

		private void CreateAsteroids()
		{
			_gameFactory.CreateBigAsteroid();
			_gameFactory.CreateMiddleAsteroid();
			_gameFactory.CreateSmallAsteroid();
		}

		private void CreateSpawner() => 
			_gameFactory.CreateSpawner();

		private void DestroyHero() => 
			Object.Destroy(_gameFactory.Hero);

		private void DestroyAsteroids()
		{
			Object.Destroy(_gameFactory.BigAsteroid);
			Object.Destroy(_gameFactory.MiddleAsteroid);
			Object.Destroy(_gameFactory.SmallAsteroid);
		}

		private void DestroyStar() =>
			Object.Destroy(_gameFactory.Star);

		private void DestroySpeedUpper() =>
			Object.Destroy(_gameFactory.SpeedUpper);

		private void DestroySpawner() => 
			Object.Destroy(_gameFactory.Spawner);
	}
}