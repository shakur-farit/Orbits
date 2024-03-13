using Infrastructure.AssetsManagement;
using UnityEngine;

namespace Infrastructure.Factory
{
	public class GameFactory : IGameFactory
	{
		private readonly IAssets _assets;

		public GameObject Bubble { get; private set; }
		public GameObject Needle { get; private set; }
		public GameObject Buff { get; private set; }
		public GameObject Debuff { get; private set; }
		public GameObject DebuffSpawner { get; private set; }


		public GameFactory(IAssets assets) => 
			_assets = assets;

		public void CreateBubble() => 
			Bubble = _assets.Instantiate(AssetPath.BubblePath);

		public void CreateNeedle() =>
			Needle = _assets.Instantiate(AssetPath.AsteroidBigPath);

		public void CreateDebuff(Vector2 position, Transform parentTransform) =>
			Debuff = _assets.Instantiate(AssetPath.DebuffPath, position, parentTransform);

		public void CreateBuff(Vector2 position, Transform parentTransform) => 
			Buff = _assets.Instantiate(AssetPath.BuffPath, position, parentTransform);

		public void CreateDebuffSpawner() =>
			DebuffSpawner = _assets.Instantiate(AssetPath.SpawnerPath);

		public void CreateHud() =>
			_assets.Instantiate(AssetPath.HudPath);
	}
}
