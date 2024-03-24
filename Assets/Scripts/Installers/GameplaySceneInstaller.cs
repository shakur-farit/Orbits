using Infrastructure.AssetsManagement;
using Infrastructure.Factory;
using Infrastructure.Services.AngleSwitcher;
using Infrastructure.Services.Input;
using Infrastructure.Services.OrbitSwitcher;
using Infrastructure.Services.PersistentProgress;
using Infrastructure.Services.Randomizer;
using Infrastructure.Services.SaveLoadService;
using Infrastructure.Services.SceneManagement;
using Infrastructure.Services.Score;
using Infrastructure.Services.StaticData;
using UI.Services.Factory;
using UI.Services.Window;
using Zenject;

namespace Installers
{
	public class GameplaySceneInstaller : MonoInstaller
	{
		public override void InstallBindings()
		{
			RegisterInputService();
			RegisterAssetsService();
			RegisterRandomService();
			RegisterAngleSwitcher();
			RegisterScoreService();
			RegisterOrbitSwitcher();
			RegisterGameFactory();
			RegisterUIFactory();
			RegisterWindowService();
			RegisterSceneService();
			RegisterPersistentProgressService();
			RegisterSaveLoadService();
			RegisterStaticDataService();
		}

		private void RegisterStaticDataService() => 
			Container.Bind<StaticDataService>().AsSingle();

		private void RegisterSaveLoadService() => 
			Container.BindInterfacesAndSelfTo<SaveLoadService>().AsSingle();

		private void RegisterPersistentProgressService() => 
			Container.Bind<PersistentProgressService>().AsSingle();

		private void RegisterScoreService() =>
			Container.Bind<ScoreService>().AsSingle();

		private void RegisterSceneService() => 
			Container.BindInterfacesAndSelfTo<SceneService>().AsSingle();

		private void RegisterAssetsService() => 
			Container.Bind<Assets>().AsSingle();

		private void RegisterGameFactory() => 
			Container.Bind<GameFactory>().AsSingle();

		private void RegisterRandomService() => 
			Container.Bind<RandomService>().AsSingle();

		private void RegisterInputService() => 
			Container.Bind<InputService>().AsSingle();

		private void RegisterAngleSwitcher() =>
			Container.Bind<AngleSwitcherService>().AsSingle();

		private void RegisterOrbitSwitcher() =>
			Container.Bind<OrbitSwitcherService>().AsSingle();

		private void RegisterUIFactory() => 
			Container.Bind<UIFactory>().AsSingle();

		private void RegisterWindowService() => 
			Container.Bind<WindowService>().AsSingle();
	}
}
