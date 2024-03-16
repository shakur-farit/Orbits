using Infrastructure.AssetsManagement;
using Infrastructure.Factory;
using Infrastructure.Services.AngleSwitcher;
using Infrastructure.Services.Input;
using Infrastructure.Services.OrbitSwitcher;
using Infrastructure.Services.PersistentProgress;
using Infrastructure.Services.Randomizer;
using Infrastructure.Services.SaveLoadService;
using Infrastructure.Services.SceneManagement;
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
			Container.BindInterfacesAndSelfTo<StaticDataService>().AsSingle();

		private void RegisterSaveLoadService() => 
			Container.BindInterfacesAndSelfTo<SaveLoadService>().AsSingle();

		private void RegisterPersistentProgressService() => 
			Container.BindInterfacesAndSelfTo<PersistentProgressService>().AsSingle();

		private void RegisterSceneService() => 
			Container.BindInterfacesAndSelfTo<SceneService>().AsSingle();

		private void RegisterAssetsService() => 
			Container.BindInterfacesAndSelfTo<Assets>().AsSingle();

		private void RegisterGameFactory() => 
			Container.BindInterfacesAndSelfTo<GameFactory>().AsSingle();

		private void RegisterRandomService() => 
			Container.BindInterfacesAndSelfTo<RandomService>().AsSingle();

		private void RegisterInputService() => 
			Container.BindInterfacesAndSelfTo<InputService>().AsSingle();

		private void RegisterAngleSwitcher() =>
			Container.BindInterfacesAndSelfTo<AngleSwitcherService>().AsSingle();

		private void RegisterOrbitSwitcher() =>
			Container.BindInterfacesAndSelfTo<OrbitSwitcherService>().AsSingle();

		private void RegisterUIFactory() => 
			Container.BindInterfacesAndSelfTo<UIFactory>().AsSingle();

		private void RegisterWindowService() => 
			Container.BindInterfacesAndSelfTo<WindowService>().AsSingle();
	}
}
