using Infrastructure.AssetsManagement;
using UnityEngine;

namespace Infrastructure.Factory
{
	public class GameFactory : IGameFactory
	{
		private readonly IAssets _assets;

		public GameObject Hero { get; private set; }
		public GameObject BigAsteroid { get; private set; }
		public GameObject MiddleAsteroid { get; set; }
		public GameObject SmallAsteroid { get; set; }
		public GameObject Star { get; private set; }
		public GameObject SpeedUpper { get; private set; }
		public GameObject AngleSwitcher { get; private set; }
		public GameObject Spawner { get; private set; }


		public GameFactory(IAssets assets) => 
			_assets = assets;

		public void CreateHero() => 
			Hero = _assets.Instantiate(AssetPath.HeroPath);

		public void CreateBigAsteroid() =>
			BigAsteroid = _assets.Instantiate(AssetPath.BigAsteroidPath);

		public void CreateMiddleAsteroid() =>
			MiddleAsteroid = _assets.Instantiate(AssetPath.MiddleAsteroidPath);

		public void CreateSmallAsteroid() =>
			SmallAsteroid = _assets.Instantiate(AssetPath.SmallAsteroidPath);

		public void CreateStar(Vector2 position, Transform parentTransform) => 
			Star = _assets.Instantiate(AssetPath.StarPath, position, parentTransform);

		public void CreateSpeedUpper(Vector2 position, Transform parentTransform) =>
			SpeedUpper = _assets.Instantiate(AssetPath.SpeedUpperPath, position, parentTransform);

		public void CreateAngleSwitcher(Vector2 position, Transform parentTransform) =>
			AngleSwitcher = _assets.Instantiate(AssetPath.AngleSwitcherPath, position, parentTransform);

		public void CreateSpawner() =>
			Spawner = _assets.Instantiate(AssetPath.SpawnerPath);

		public void CreateHud() =>
			_assets.Instantiate(AssetPath.HudPath);
	}
}
