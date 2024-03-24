using Infrastructure.Factory;
using Infrastructure.Services.PersistentProgress;
using Infrastructure.Services.SaveLoadService;
using Infrastructure.Services.StaticData;
using Infrastructure.States;
using UI.Services.Factory;
using UI.Services.Window;

namespace Infrastructure
{
	public class Game
	{
		public GameStateMachine StateMachine;

		public Game(StaticDataService staticDataService, PersistentProgressService progressService,
			ILoadService loadService, GameFactory gameFactory, UIFactory uiFactory, 
			WindowService windowService)
		{
			StateMachine = new GameStateMachine(staticDataService, progressService, 
				loadService, gameFactory, uiFactory, windowService);
		}
	}
}