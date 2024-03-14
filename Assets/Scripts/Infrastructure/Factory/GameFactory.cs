using Infrastructure.AssetsManagement;
using UnityEngine;

namespace Infrastructure.Factory
{
	public class GameFactory : IGameFactory
	{
		private readonly IAssets _assets;

		public GameObject Bubble { get; private set; }
		public GameObject BigAsteroid { get; private set; }
		public GameObject MiddleAsteroid { get; set; }
		public GameObject SmallAsteroid { get; set; }
		public GameObject Buff { get; private set; }
		public GameObject Spawner { get; private set; }


		public GameFactory(IAssets assets) => 
			_assets = assets;

		public void CreateBubble() => 
			Bubble = _assets.Instantiate(AssetPath.BubblePath);

		public void CreateBigAsteroid() =>
			BigAsteroid = _assets.Instantiate(AssetPath.BigAsteroidPath);

		public void CreateMiddleAsteroid() =>
			MiddleAsteroid = _assets.Instantiate(AssetPath.MiddleAsteroidPath);

		public void CreateSmallAsteroid() =>
			SmallAsteroid = _assets.Instantiate(AssetPath.SmallAsteroidPath);

		public void CreateBuff(Vector2 position, Transform parentTransform) => 
			Buff = _assets.Instantiate(AssetPath.BuffPath, position, parentTransform);

		public void CreateSpawner() =>
			Spawner = _assets.Instantiate(AssetPath.SpawnerPath);

		public void CreateHud() =>
			_assets.Instantiate(AssetPath.HudPath);
	}
}
