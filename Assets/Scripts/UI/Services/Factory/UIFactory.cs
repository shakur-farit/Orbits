using Infrastructure.AssetsManagement;
using UnityEngine;

namespace UI.Services.Factory
{
	public class UIFactory : IUIFactory
	{
		private readonly IAssets _assets;

		public Transform UIRoot { get; private set; }

		public UIFactory(IAssets assets) => 
			_assets = assets;

		public void CreateUIRoot() => 
			UIRoot = _assets.Instantiate(AssetPath.UIRootPath).transform;

		public void CreateGameOverWindow(Transform parentTransform) => 
			_assets.Instantiate(AssetPath.GameOverWindowPath, parentTransform);

		public void CreateMainMenuWindow(Transform parentTransform) =>
			_assets.Instantiate(AssetPath.MainMenuWindowPath, parentTransform);
	}
}