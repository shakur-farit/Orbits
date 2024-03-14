using Infrastructure.Factory;
using UnityEngine;

namespace Infrastructure.Services.SceneManagement
{
	public class SceneService : IRestartable, IQuitable
	{
		private readonly IGameFactory _gameFactory;

		public SceneService(IGameFactory gameFactory)
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
			DestroyBubble();
			DestroyNeedle();
			DestroyBuff();
			DestroySpawner();
		}

		private void CreateGameObjects()
		{
			CreateBubble();
			CreateNeedle();
			CreateSpawner();
		}

		private void CreateBubble() => 
			_gameFactory.CreateBubble();

		private void CreateNeedle() => 
			_gameFactory.CreateBigAsteroid();

		private void CreateSpawner() => 
			_gameFactory.CreateSpawner();

		private void DestroyBubble() => 
			Object.Destroy(_gameFactory.Bubble);

		private void DestroyNeedle() =>
			Object.Destroy(_gameFactory.BigAsteroid);

		private void DestroyBuff() =>
			Object.Destroy(_gameFactory.Buff);

		private void DestroySpawner() => 
			Object.Destroy(_gameFactory.Spawner);
	}
}