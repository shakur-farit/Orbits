using Infrastructure.Factory;
using Infrastructure.Services.PersistentProgress;
using Infrastructure.Services.SaveLoadService;
using Infrastructure.Services.StaticData;
using Infrastructure.States;
using UI.Services.Factory;
using UI.Services.Window;
using UnityEngine;

namespace Infrastructure
{
	public class Game
	{
		public GameStateMachine StateMachine;

		public Game(IStaticDataService staticDataService, IPersistentProgressService progressService,
			ILoadService loadService, IGameFactory gameFactory, IUIFactory uiFactory, 
			IWindowService windowService)
		{
			StateMachine = new GameStateMachine(staticDataService, progressService, 
				loadService, gameFactory, uiFactory, windowService);
		}
	}
}