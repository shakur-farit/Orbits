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
			DestroyDebuff();
			DestroyBuff();
			DestroyDebuffSpawner();
		}

		private void CreateGameObjects()
		{
			CreateBubble();
			CreateNeedle();
			CreateDebuffSpawner();
		}

		private void CreateBubble() => 
			_gameFactory.CreateBubble();

		private void CreateNeedle() => 
			_gameFactory.CreateNeedle();

		private void CreateDebuffSpawner() => 
			_gameFactory.CreateDebuffSpawner();

		private void DestroyBubble() => 
			Object.Destroy(_gameFactory.Bubble);

		private void DestroyNeedle() =>
			Object.Destroy(_gameFactory.Needle);

		private void DestroyBuff() =>
			Object.Destroy(_gameFactory.Buff);

		private void DestroyDebuff() => 
			Object.Destroy(_gameFactory.Debuff);

		private void DestroyDebuffSpawner() => 
			Object.Destroy(_gameFactory.DebuffSpawner);
	}
}